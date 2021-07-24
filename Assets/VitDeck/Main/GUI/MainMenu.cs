using UnityEditor;

namespace VitDeck.Main.GUI
{
    /// <summary>
    /// Unityメニューバー上のメインメニュー。
    /// </summary>
    public static class MainMenu
    {
        const string prefix = "VitDeck/";

        [MenuItem(prefix + "Info", priority = 200)]
        static void Information()
        {
            InfoWindow.ShowWindow();
        }
    }
}
