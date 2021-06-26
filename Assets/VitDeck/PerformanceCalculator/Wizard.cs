using System;
using UnityEngine;
using UnityEditor;
using VitDeck.Utilities;
using VitDeck.Language;
using VitDeck.Main;
using System.Threading.Tasks;
using System.Collections;

namespace VitDeck.PerformanceCalculator
{
    /// <summary>
    /// 負荷計算機能のGUI
    /// </summary>
    public class Wizard : EditorWindow
    {
        private const string prefix = "VitDeck/";

        private DefaultAsset baseFolder;

        [SerializeField]
        private Calculator.SpaceSize spaceSize;

        [SerializeField]
        private bool calculatingReserved = false;

        [SerializeField]
        private string id;

        private IEnumerator coroutine;

#if !VITDECK_HIDE_MENUITEM
        [MenuItem(prefix + "Calculate Peformance", priority = 103)]
#endif
        public static void Open()
        {
            var wizard = GetWindow<Wizard>("VitDeck");
            wizard.LoadSettings();
        }

        private void OnGUI()
        {
            this.baseFolder = (DefaultAsset)EditorGUILayout.ObjectField("Base Folder", this.baseFolder, typeof(DefaultAsset), allowSceneObjects: false);
            this.spaceSize = (Calculator.SpaceSize)EditorGUILayout.EnumPopup("Space Size", this.spaceSize);
            EditorGUI.BeginDisabledGroup(this.baseFolder == null);
                if (GUILayout.Button("Calculate Peformance"))
                {
                    this.SaveSettings();

                    if (!AssetUtility.OpenScene(this.baseFolder))
                    {
                        EditorUtility.DisplayDialog("VitDeck", LocalizedMessage.Get("VketTargetFinder.SceneNotFound", AssetUtility.GetScenePath(this.baseFolder)), "OK");
                        return;
                    }

                    this.Calculate();
                }
            EditorGUI.EndDisabledGroup();
        }

        private void Update()
        {
            if (EditorApplication.isPlaying == true && this.calculatingReserved)
            {
                this.calculatingReserved = false;
                this.coroutine = Calculator.Calculate(this.id, this.spaceSize);
            }

            if (this.coroutine == null)
            {
                return;
            }

            if (!this.coroutine.MoveNext())
            {
                var result = this.coroutine.Current;
                this.coroutine = null;

                if (result != null)
                {
                    var (setPassCalls, batches) = ((int, int))result;
                    this.Close();
                    this.DisplayResult($"Assets/{this.id}/{this.id}.unity", setPassCalls, batches);
                }

                EditorApplication.isPlaying = false;
            }
        }

        /// <summary>
        /// VitDeckのユーザー設定を読み込む。
        /// </summary>
        private void LoadSettings()
        {
            var userSettings = SettingUtility.GetSettings<UserSettings>();
            this.baseFolder = AssetDatabase.LoadAssetAtPath<DefaultAsset>(userSettings.validatorFolderPath);
        }

        /// <summary>
        /// VitDeckのユーザー設定を保存する。
        /// </summary>
        private void SaveSettings()
        {
            var userSettings = SettingUtility.GetSettings<UserSettings>();
            userSettings.validatorFolderPath = AssetDatabase.GetAssetPath(this.baseFolder);
            SettingUtility.SaveSettings(userSettings);
        }

        private async void Calculate()
        {
            var bakeCheck = GUIUtilities.BakeCheckAndRun();
            while (bakeCheck.MoveNext())
            {
                await Task.Delay(TimeSpan.FromSeconds(0.05f));
            }

            if (!(bool)bakeCheck.Current)
            {
                return;
            }

            this.id = AssetUtility.GetId(this.baseFolder);
            this.calculatingReserved = true;
            EditorApplication.isPlaying = true;
        }

        private void DisplayResult(string scenePath, int setPassCalls, int batches)
        {
            EditorUtility.DisplayDialog(
                "VitDeck",
                LocalizedMessage.Get("PerformanceCalculator.Result", scenePath, setPassCalls, batches),
                "OK"
            );
        }
    }
}
