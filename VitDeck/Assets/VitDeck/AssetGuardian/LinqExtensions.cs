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
    }
}