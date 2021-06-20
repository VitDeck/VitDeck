using UnityEditor;

namespace VitDeck.Utilities
{
    internal class ProjectSettings : ScriptableWizard
    {
        /// <summary>
        /// <see cref="VitDeck.Placement"/>でunitypackageを操作できるように、テキスト形式のアセットを強制します。
        /// </summary>
        [InitializeOnLoadMethod]
        private static void ForceText()
        {
            if (EditorSettings.serializationMode != SerializationMode.ForceText)
            {
                EditorSettings.serializationMode = SerializationMode.ForceText;
            }
        }
    }
}
