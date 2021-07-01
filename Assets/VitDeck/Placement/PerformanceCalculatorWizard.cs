using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using VitDeck.Utilities;
using VitDeck.Validator;
using VitDeck.PerformanceCalculator;
using VitDeck.Exporter;
using VitDeck.Language;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

namespace VitDeck.Placement
{
    /// <summary>
    /// パフォーマンスの一括計算。再生中にのみ起動可能。
    /// </summary>
    public class PerformanceCalculatorWizard : EditorWindow
    {
        private static readonly Regex IdPattern = new Regex("^[1-9][0-9]*$");
        private static readonly TimeSpan Frame = TimeSpan.FromSeconds(1f / 60);

        private string ids;
        private Calculator.SpaceSize spaceSize;
        private string tsv;

        [MenuItem("VitDeck/Batch Performance Calculator Tool", priority = 121)]
        public static void Open()
        {
            GetWindow<PerformanceCalculatorWizard>("VitDeck");
        }

        private void OnGUI()
        {
            this.ids = EditorGUILayout.TextField("IDs", this.ids);
            EditorGUILayout.HelpBox(
                "半角スペース、または「,」区切りのID一覧を指定します。未指定時はプロジェクト内のすべてのブースをチェックします。",
                MessageType.None
            );
            
            this.spaceSize = (Calculator.SpaceSize)EditorGUILayout.EnumPopup("Space Size", this.spaceSize);

            EditorGUI.BeginDisabledGroup(!EditorApplication.isPlaying);
                if (GUILayout.Button("Calculate Peformance"))
                {
                    var ids = this.GetExhibitIdsInProject();

                    if (!string.IsNullOrWhiteSpace(this.ids))
                    {
                        var selectedIds = this.ids.Split(new[] { ',', ' ' }).Select(id => id.Trim());
                        var notExistIds = selectedIds.Except(ids);
                        if (notExistIds.Count() > 0)
                        {
                            throw new Exception("次のIDのフォルダはプロジェクトに存在しません:\n" + string.Join("\n", notExistIds));
                        }
                        ids = selectedIds;
                    }

                    this.Calculate(ids);
                }
            EditorGUI.EndDisabledGroup();

            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("再生状態で実行する必要があります。", MessageType.Error);
            }

            EditorGUILayout.LabelField("結果");
            EditorGUILayout.TextArea(this.tsv);
            EditorGUI.BeginDisabledGroup(this.tsv == null);
                if (GUILayout.Button("Copy Result TSV"))
                {
                    GUIUtility.systemCopyBuffer = this.tsv;
                }
            EditorGUI.EndDisabledGroup();
        }

        private async Task Calculate(IEnumerable<string> ids)
        {
            this.tsv = "ID\tsetPassCalls\tbatches\n";

            foreach (var id in ids)
            {
                await this.OpenSceneInPlayMode(id);

                var coroutine = Calculator.Calculate(exhibitId: id, Calculator.SpaceSize.Small);
                try
                {
                    while (coroutine.MoveNext())
                    {
                        await Task.Delay(Frame);
                    }
                }
                catch (Exception exception)
                {
                    EditorUtility.ClearProgressBar();
                    Debug.Log(exception);
                    //EditorApplication.isPlaying = false;
                    throw;
                }

                var result = coroutine.Current;
                if (result == null)
                {
                    throw new Exception($"「{id}」のパフォーマンス計算に失敗しました。");
                }

                var (setPassCalls, batches) = ((int, int))result;
                tsv += $"{id}\t{setPassCalls}\t{batches}\n";
            }
        }

        /// <summary>
        /// 再生中に指定したIDのシーンを開き、読み込みが完了するまで待機します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task OpenSceneInPlayMode(string id)
        {
            var scene = EditorSceneManager.LoadSceneInPlayMode($"Assets/{id}/{id}.unity", new LoadSceneParameters(LoadSceneMode.Single));
            while (!scene.isLoaded)
            {
                await Task.Delay(Frame);
            }
        }

        /// <summary>
        /// プロジェクト内のブースのIDを取得します。
        /// </summary>
        /// <remarks>
        /// Assets直下の数字のみのフォルダを入稿されたフォルダとして扱います。
        /// </remarks>
        /// <returns></returns>
        private IEnumerable<string> GetExhibitIdsInProject()
        {
            var ids = AssetDatabase.GetSubFolders("Assets")
                .Select(path => Path.GetFileName(path))
                .Where(folderName => IdPattern.IsMatch(folderName));
            
            foreach (var id in ids)
            {
                var scenePath = $"Assets/{id}/{id}.unity";
                var scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
                if (scene == null)
                {
                    throw new Exception($"「{scenePath}」が存在しません。");
                }
            }

            return ids;
        }
    }
}
