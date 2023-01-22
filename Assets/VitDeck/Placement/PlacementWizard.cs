using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using VitDeck.Utilities;
using VitDeck.Validator;
using VitDeck.BuildSizeCalculator;
using VitDeck.Exporter;
using VitDeck.Language;

namespace VitDeck.Placement
{
    public class PlacementWizard : ScriptableWizard
    {
        private static readonly Regex FilePathPattern = new Regex(@"[/\\][^/\\]*?_([1-9][0-9]*)_[^/\\]*\.unitypackage$");

        [SerializeField]
        private ExportSetting exportSetting;

        [SerializeField]
        private SceneAsset location = null;

        [SerializeField]
        private bool forcePlace = false;

        private string folderPath;
        private Vector2 anchorListScrollPosition;
        private IDictionary<Transform, string> anchorIdPairs;

        [MenuItem("VitDeck/Placement Tool", priority = 120)]
        public static void Open()
        {
            ScriptableWizard.DisplayWizard<PlacementWizard>("VitDeck", "Select folder and Import unitypackages").LoadSettings();
        }

        protected override bool DrawWizardGUI()
        {
            base.DrawWizardGUI();
            EditorGUILayout.HelpBox(
                "選択したフォルダ内に含まれるunitypackageをインポートします。\n\nパッケージ名に含まれる「_」で囲まれた数字をIDとして扱います。",
                MessageType.None
            );

            EditorGUILayout.HelpBox(
                "「Force Place」へチェックを入れると、unitypackageの検査・GUID変更のみを行い、インポート後のバリデーション、ビルド容量チェックを行わず、強制的に配置します。",
                MessageType.None
            );

            if (this.location == null)
            {
                EditorGUILayout.HelpBox(
                    "「Location」未指定の場合、unitypackageの検査・GUID変更、インポート、インポート後のバリデーション、ビルド容量チェックを行い、自動配置を省略します。",
                    MessageType.Info
                );
            }

            using (new EditorGUI.DisabledGroupScope(this.location == null))
            {
                if (GUILayout.Button("シーン内の配置状態を表示"))
                {
                    this.anchorIdPairs = Placement.GetAnchorIdPairs(Placement.OpenScene(this.location));
                }
            }

            if (this.anchorIdPairs != null)
            {
                using (var scrollViewScope = new EditorGUILayout.ScrollViewScope(this.anchorListScrollPosition))
                {
                    this.anchorListScrollPosition = scrollViewScope.scrollPosition;
                    var i = 1;
                    foreach (var (anchor, id) in this.anchorIdPairs)
                    {
                        using (new EditorGUILayout.HorizontalScope())
                        {
                            if (GUILayout.Button(i.ToString()))
                            {
                                EditorGUIUtility.PingObject(anchor);
                            }
                            EditorGUILayout.LabelField(id);
                        }
                        i++;
                    }
                }
            }

            this.isValid = this.exportSetting != null;
            return true;
        }
        private void OnWizardCreate()
        {
            UnityEditorUtility.StartCoroutine(this.Place());
        }

        private IEnumerator Place()
        {
            this.folderPath = EditorUtility.OpenFolderPanel(title: "VitDeck", folder: this.folderPath, defaultName: null);
            if (string.IsNullOrEmpty(this.folderPath))
            {
                yield break;
            }

            this.SaveSettings();

            var allowedExtensions = this.exportSetting.GetAllowedExtensions();
            IRuleSet ruleSet = null;
            if (string.IsNullOrEmpty(this.exportSetting.ruleSetName))
            {
                Debug.LogWarning(LocalizedMessage.Get("ValidatedExporter.SkipValidation"));
            }
            else
            {
                ruleSet = Validator.Validator.GetRuleSet(this.exportSetting.ruleSetName);
                if (ruleSet == null)
                {
                    throw new Exception($"指定されたルールセット「{this.exportSetting.ruleSetName}」が見つかりません。");
                }
            }
            if (this.exportSetting.MaxBuildByteCount == 0)
            {
                Debug.LogWarning(LocalizedMessage.Get("ValidatedExporter.SkipBuildSizeCheck"));
            }

            var pathsNotMatchingPattern = new List<string>();
            var pathIdPairs = Directory.GetFiles(this.folderPath).ToDictionary(path => path, path => {
                var match = FilePathPattern.Match(path);
                if (!match.Success)
                {
                    pathsNotMatchingPattern.Add(path);
                    return null;
                }

                return FilePathPattern.Match(path).Groups[1].Value;
            });

            if (pathsNotMatchingPattern.Count > 0)
            {
                EditorUtility.DisplayDialog(
                    "VitDeck",
                    "次のファイルは入稿パッケージのファイル名パターンに一致しません:\n" + string.Join("\n", pathsNotMatchingPattern),
                    "OK"
                );
                yield break;
            }

            var pathsIncludingDuplicatedId = pathIdPairs
                .GroupBy(pathIdPair => pathIdPair.Value, pathIdPair => pathIdPair.Key)
                .Where(idPathsPair => idPathsPair.Count() > 1)
                .SelectMany(idPathsPair => idPathsPair);
            if (pathsIncludingDuplicatedId.Count() > 0)
            {
                EditorUtility.DisplayDialog(
                    "VitDeck",
                    "次のファイルはIDが重複しています:\n" + string.Join("\n", pathsIncludingDuplicatedId),
                    "OK"
                );
                yield break;
            }

            if (this.location != null)
            {
                var anchorIdPairs = Placement.GetAnchorIdPairs(Placement.OpenScene(this.location));
                var freeAnchorCount = anchorIdPairs.Values.Count(id => id == null);
                var newPackageCount = pathIdPairs.Values.Except(anchorIdPairs.Values).Count();
                if (newPackageCount > freeAnchorCount)
                {
                    EditorUtility.DisplayDialog(
                        "VitDeck",
                        $"配置先が不足しています。\n\nすべての配置場所: {anchorIdPairs.Count}\n空き配置場所: {freeAnchorCount}\nすべての入稿数: {pathIdPairs.Count}\n新規入稿数: {newPackageCount}\n",
                        "OK"
                    );
                    yield break;
                }
            }

            var idMessagePairs = new Dictionary<string, string>();
            foreach (var (path, id) in pathIdPairs)
            {
                string backupFolderPath = null;
                if (AssetDatabase.IsValidFolder($"Assets/{id}"))
                {
                    // 再入稿なら
                    // 入稿済みフォルダを退避
                    backupFolderPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                    DirectoryCopy(Path.Combine(Application.dataPath, id), backupFolderPath, copySubDirs: true);
                    AssetDatabase.DeleteAsset($"Assets/{id}");
                    AssetDatabase.Refresh();
                }

                var valid = false;

                try
                {
                    // インポート
                    try
                    {
                        PackageImporter.Import(path, id, allowedExtensions);
                    }
                    catch (FatalValidationErrorException exception)
                    {
                        idMessagePairs.Add(id, exception.Message);
                        continue;
                    };

                    // 入稿シーンを開く
                    var scenePath = $"Assets/{id}/{id}.unity";
                    if (AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath) == null)
                    {
                        idMessagePairs.Add(id, $"シーン「{scenePath}」が存在しません。");
                        continue;
                    }
                    EditorSceneManager.OpenScene(scenePath);

                    if (!this.forcePlace)
                    {
                        // バリデーション
                        if (ruleSet != null)
                        {
                            ValidationResult[] validationResults;
                            try
                            {
                                validationResults = Validator.Validator.Validate(ruleSet, "Assets/" + id, forceOpenScene: true);
                            }
                            catch (FatalValidationErrorException exception)
                            {
                                idMessagePairs.Add(id, LocalizedMessage.Get("ValidatedExporter.ProblemOccurredWhileValidating") + "\n" + exception.Message);
                                continue;
                            }
                            var minIssueLevel = this.exportSetting.ignoreValidationWarning ? IssueLevel.Error : IssueLevel.Warning;
                            if (validationResults.SelectMany(result => result.Issues).Any(issue => issue.level >= minIssueLevel))
                            {
                                idMessagePairs.Add(id, LocalizedMessage.Get("ValidatedExporter.IssueFound") + "\n" + string.Join(
                                    "\n",
                                    validationResults
                                        .Where(result => result.Issues.Any(issue => issue.level >= minIssueLevel))
                                        .Select(result => result.RuleName + ":\n"
                                            + string.Join("\n", result.Issues.Where(issue => issue.level >= minIssueLevel).Select(issue => "    " + issue.message)))));
                                continue;
                            }
                        }

                        // ビルド容量チェック
                        if (this.exportSetting.MaxBuildByteCount > 0)
                        {
                            var buildByteCountEnumerator = Calculator.ForceRebuild(id);
                            while (buildByteCountEnumerator.MoveNext())
                            {
                                yield return null;
                            }
                            if (buildByteCountEnumerator.Current == null)
                            {
                                idMessagePairs.Add(id, LocalizedMessage.Get("ValidatedExporter.ProblemOccurredWhileBuildSizeCheck"));
                                continue;
                            }
                            var buildByteCount = (int)buildByteCountEnumerator.Current;

                            if (buildByteCount > this.exportSetting.MaxBuildByteCount)
                            {
                                idMessagePairs.Add(id, $"ビルド容量 {MathUtility.FormatByteCount((int)buildByteCount)} が {MathUtility.FormatByteCount(this.exportSetting.MaxBuildByteCount)} を超過しています。");
                                continue;
                            }
                        }
                    }

                    valid = true;
                }
                finally
                {
                    if (!valid)
                    {
                        // 失敗していれば
                        // インポートしたブースを削除
                        AssetDatabase.DeleteAsset($"Assets/{id}");
                        AssetDatabase.Refresh();
                    }

                    if (backupFolderPath != null)
                    {
                        // 再配置の場合
                        if (valid)
                        {
                            // 成功していれば
                            // 配置前のブースを削除
                            Directory.Delete(backupFolderPath, recursive: true);
                        }
                        else
                        {
                            // 失敗していれば
                            // 配置前のブースを元に戻す
                            Directory.Move(backupFolderPath, Path.Combine(Application.dataPath, id));
                            AssetDatabase.ImportAsset($"Assets/{id}", ImportAssetOptions.ForceUpdate | ImportAssetOptions.ImportRecursive);
                        }
                        AssetDatabase.Refresh();
                    }
                }

                if (this.location != null)
                {
                    // 配置
                    Placement.Place(id, this.location);
                }

                idMessagePairs.Add(id, this.location != null ? "配置完了" : "バリデーション成功");
            }

            var message = string.Join("\n\n", idMessagePairs.Select(idMessagePair => $"[{idMessagePair.Key}]\n{idMessagePair.Value}"));
            Debug.Log("\n" + message);
            EditorUtility.DisplayDialog("VitDeck", message, "OK");
        }

        /// <summary>
        /// ディレクトリをコピーします。
        /// </summary>
        /// <remarks>
        /// 方法: ディレクトリをコピーする | Microsoft Docs
        /// https://docs.microsoft.com/dotnet/standard/io/how-to-copy-directories
        /// 
        /// The MIT License (MIT)
        /// https://github.com/dotnet/docs/blob/main/LICENSE-CODE
        /// Copyright (c) Microsoft Corporation
        /// 
        /// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
        /// associated documentation files (the "Software"), to deal in the Software without restriction, 
        /// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
        /// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
        /// subject to the following conditions:
        ///
        /// The above copyright notice and this permission notice shall be included in all copies or substantial 
        /// portions of the Software.
        ///
        /// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT 
        /// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
        /// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
        /// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
        /// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
        /// </remarks>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        /// <param name="copySubDirs"></param>
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private void LoadSettings()
        {
            var settings = SettingUtility.GetSettings<PlacementSettings>();
            this.exportSetting = settings.ExportSetting;
            this.location = settings.Location;
            this.folderPath = settings.FolderPath;
        }

        private void SaveSettings()
        {
            var settings = SettingUtility.GetSettings<PlacementSettings>();
            settings.ExportSetting = this.exportSetting;
            settings.Location = this.location;
            settings.FolderPath = this.folderPath;
            SettingUtility.SaveSettings(settings);
        }
    }
}
