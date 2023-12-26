using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.PostProcessor
{
    /// <summary>
    /// インポート時と削除時にシンボルを追加するクラス
    /// </summary>
    public class VitDeckPostProcessor : AssetPostprocessor
    {
        private static readonly string VitDeckRootFolderPath = "Packages/com.vitdeck.core";
        private const string DefineName = "VIT_DECK";

        public override int GetPostprocessOrder()
        {
            return int.MaxValue;
        }

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (var importedAssetPath in importedAssets)
            {
                if (importedAssetPath == VitDeckRootFolderPath)
                {
                    AddSymbol(DefineName);
                    return;
                }
            }
            foreach (var deletedAssetPath in deletedAssets)
            {
                if (deletedAssetPath == VitDeckRootFolderPath)
                {
                    DeleteSymbol(DefineName);
                    return;
                }
            }
        }

        /// <summary>
        /// シンボルの追加
        /// </summary>
        /// <param name="defineName">シンボル名</param>
        private static void AddSymbol(string defineName)
        {
            Debug.Log($"Add:{defineName}");
            var currentDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            var split = currentDefines.Split(';').ToList();
            if (!split.Contains(defineName))
                split.Add(defineName);

            var resultDefines = string.Join(";", split);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, resultDefines);
        }

        /// <summary>
        /// シンボルの削除
        /// </summary>
        /// <param name="defineName">シンボル名</param>
        private static void DeleteSymbol(string defineName)
        {
            Debug.Log($"Delete:{defineName}");
            var currentDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            var split = currentDefines.Split(';').ToList();
            if (split.Contains(defineName))
                split.Remove(defineName);

            var resultDefines = string.Join(";", split);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, resultDefines);
        }
    }
}
