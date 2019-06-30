using UnityEditor;

namespace VitDeck.Main.GUI
{
    /// <summary>
    /// Unityメニューバー上のメインメニュー。
    /// </summary>
    public static class MainMenu
    {
        const string prefix = "VitDeck/";

        [MenuItem(prefix + "Settings", priority = 0)]
        static void ProjectSettings()
        {
            // グローバルな設定画面を開く
        }

        [MenuItem(prefix + "Info", priority = 200)]
        static void Information()
        {
            InfoWindow.ShowWindow();
        }
    }
}
