using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// AssetGuardian内で使うための、Linqの拡張メソッドを定義する。
    /// </summary>
    public static class LinqExtensions
    {
        public static IEnumerable<T> LoadAssetFromPath<T>(this IEnumerable<string> paths) where T : Object
        {
            foreach (var path in paths)
                yield return AssetDatabase.LoadAssetAtPath<T>(path);
        }

        //public static IEnumerable<Object> LoadAssetFromPathWithChildren(this IEnumerable<string> paths)
        //{
        //    foreach (var path in paths)
        //    {
        //        var assets = AssetDatabase.LoadAllAssetsAtPath(path);
        //        if (assets == null || assets.Length == 0)
        //        {
        //            yield return AssetDatabase.LoadAssetAtPath<Object>(path);
        //            yield break;
        //        }
        //        foreach (var asset in assets)
        //            yield return asset;
        //    }
        //}
    }
}