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
            Protector.OnSaveCancelled += Guardian_OnSaveCancelled;
            Protector.OnDeleteCancelled += Guardian_OnDeleteCancelled;
            Protector.OnMoveCancelled += Guardian_OnMoveCancelled;

            EditorApplication.update += EditorApplicaton_Update;
        }

        private static void EditorApplicaton_Update()
        {
            if (SaveCancelledAssetList.Count > 0)
            {
                EditorUtility.DisplayDialog("VitDeck Asset Guardian", "以下のアセットの変更は許可されていません。\n" + Digest(SaveCancelledAssetList), "ok");

                SaveCancelledAssetList.Clear();
            }
            if (DeleteCancelledAssetList.Count > 0)
            {
                EditorUtility.DisplayDialog("VitDeck Asset Guardian", "以下のアセットの削除は許可されていません。\n" + Digest(DeleteCancelledAssetList), "ok");
                DeleteCancelledAssetList.Clear();
            }
            if (MoveCancelledAssetList.Count > 0)
            {
                EditorUtility.DisplayDialog("VitDeck Asset Guardian", "以下のアセットの移動または名前の変更は許可されていません。\n" + Digest(MoveCancelledAssetList), "ok");
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
