using System.Collections;
using UnityEditor;
using VitDeck.Language;

namespace VitDeck.Main
{
    /// <summary>
    /// ビルドサイズ計算と負荷チェックの共通処理。
    /// </summary>
    public static class GUIUtilities
    {
        public static IEnumerator BakeCheckAndRun()
        {
            EditorUtility.DisplayProgressBar("Bake", "Baking...", 0);
            bool bakeFlag = Lightmapping.BakeAsync();
            if (!bakeFlag)
            {
                EditorUtility.DisplayDialog("Error", LocalizedMessage.Get("Main.Baker.LightBakeFailed"), "OK");
            }

            while (Lightmapping.isRunning)
            {
                EditorUtility.DisplayProgressBar("Bake", "Baking...", Lightmapping.buildProgress);
                yield return null;
            }

            EditorUtility.ClearProgressBar();

            yield return bakeFlag;
        }
    }
}
