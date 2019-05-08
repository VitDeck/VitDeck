using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Text;

namespace VitDeck.AssetGuardian.GUI
{

    public class Notificator
    {

        [InitializeOnLoadMethod]
        public static void Initialze()
        {
            Guardian.OnSaveCancelled += Guardian_OnSaveCancelled;
            Guardian.OnDeleteCancelled += Guardian_OnDeleteCancelled;
            Guardian.OnMoveCancelled += Guardian_OnMoveCancelled;

            EditorApplication.update += EditorApplicaton_Update;
        }

        private static void EditorApplicaton_Update()
        {
            if (SaveCancelledAssetList.Count > 0)
            {
                EditorUtility.DisplayDialog("保存はキャンセルされました。 - VitDeck", "以下のアセットは主催者によりロックされています。\n" + Digest(SaveCancelledAssetList), "ok");
                SaveCancelledAssetList.Clear();
            }
            if (DeleteCancelledAssetList.Count > 0)
            {
                EditorUtility.DisplayDialog("削除はキャンセルされました。 - VitDeck", "以下のアセットは主催者によりロックされています。\n" + Digest(DeleteCancelledAssetList), "ok");
                DeleteCancelledAssetList.Clear();
            }
            if (MoveCancelledAssetList.Count > 0)
            {
                EditorUtility.DisplayDialog("移動はキャンセルされました。 - VitDeck", "以下のアセットは主催者によりロックされています。\n" + Digest(MoveCancelledAssetList), "ok");
                MoveCancelledAssetList.Clear();
            }

        }

        static List<string> SaveCancelledAssetList = new List<string>();
        static List<string> DeleteCancelledAssetList = new List<string>();
        static List<string> MoveCancelledAssetList = new List<string>();

        private static string Digest(IEnumerable<string> list)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in list)
            {
                builder.AppendLine(item);
            }
            return builder.ToString();
        }

        private static void Guardian_OnSaveCancelled(string obj)
        {

            SaveCancelledAssetList.Add(obj);
        }

        private static void Guardian_OnDeleteCancelled(string obj)
        {
            DeleteCancelledAssetList.Add(obj);
        }

        private static void Guardian_OnMoveCancelled(string obj)
        {
            MoveCancelledAssetList.Add(obj);
        }
    }
}