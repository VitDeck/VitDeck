using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine;
using UnityEditor;
using VitDeck.Utilities;
using VitDeck.Validator;

namespace VitDeck.Placement
{
    public class PlacementWizard : ScriptableWizard
    {
        private static readonly Regex FilePathPattern = new Regex(@"[/\\][^/\\]*?_([1-9][0-9]*)_[^/\\]*\.unitypackage$");

        /// <summary>
        /// 「.」を含まない「,」区切りの拡張子リスト。
        /// </summary>
        [SerializeField]
        private string allowedExtensions = "unity,prefab,asset,mat,exr,fbx,png,jpg,jpeg,gif,anim,controller,overrideController";

        [SerializeField]
        private string folderPath = null;

        [MenuItem("VitDeck/Placement Tool", priority = 120)]
        public static void Open()
        {
            ScriptableWizard.DisplayWizard<PlacementWizard>("VitDeck", "Import unitypackages");
        }

        protected override bool DrawWizardGUI()
        {
            base.DrawWizardGUI();
            EditorGUILayout.HelpBox(
                "指定したフォルダ内に含まれるunitypackageをインポートします。\n\nパッケージ名に含まれる「_」で囲まれた数字をIDとして扱います。",
                MessageType.None
            );

            this.isValid = !string.IsNullOrEmpty(this.folderPath);
            return true;
        }

        private void OnWizardCreate()
        {
            var allowedExtensions = this.allowedExtensions.Split(',').Select(extension => "." + extension.ToLower());

            var pathsNotMatchingPattern = new List<string>();
            var pathIdPairs = Directory.GetFiles(folderPath).ToDictionary(path => path, path => {
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
                return;
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
                return;
            }

            var results = new List<string>();
            foreach (var (path, id) in pathIdPairs)
            {
                var result = $"[{id}]\n";
                try
                {
                    PackageImporter.Import(id, path, allowedExtensions);
                    result += "問題なし";
                }
                catch (FatalValidationErrorException exception)
                {
                    result += exception.Message;
                };
                results.Add(result);
            }

            var message = string.Join("\n\n", results);
            Debug.Log("\n" + message);
            EditorUtility.DisplayDialog("VitDeck", message, "OK");
        }
    }
}
