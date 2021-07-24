using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Utilities
{
    /// <summary>
    /// エディタでの作業に対する操作を提供するクラス。
    /// </summary>
    public static class UnityEditorUtility
    {
        private class DummyEditorWindow : EditorWindow
        {
            internal static Action Action;

            private void Update()
            {
                Debug.Log("1: " + (Action != null ? "true" : "false"));
                DummyEditorWindow.Action?.Invoke();
                Debug.Log("2: " + (Action != null ? "true" : "false"));
            }
        }

        private static readonly IList<IEnumerator> Coroutines = new List<IEnumerator>();

        /// <summary>
        /// コルーチンを実行する。
        /// </summary>
        /// <remarks>
        /// asyncメソッドを利用すると、<see cref="BuildPipeline.BuildAssetBundles"/>時にasyncメソッドがが二重実行されてしまう問題の回避のため。
        /// </remarks>
        /// <param name="coroutine"></param>
        public static void StartCoroutine(IEnumerator coroutine)
        {
            Coroutines.Add(coroutine);
            if (Coroutines.Count == 1)
            {
                //EditorApplication.update += MoveNext;
                DummyEditorWindow.Action = MoveNext;
                var window = EditorWindow.GetWindow<DummyEditorWindow>();
                //window.position = new Rect(position: new Vector3(-1000, -1000), size: new Vector2(0, 0));
                
            }
        }

        private static void MoveNext()
        {
            var endCoroutines = new List<IEnumerator>();
            Debug.Log("1 / Coroutines.Count(): " + Coroutines.Count() + " / endCoroutines.Count(): " + endCoroutines.Count());

            foreach (var coroutine in Coroutines)
            {
                if (!coroutine.MoveNext())
                {
                    endCoroutines.Add(coroutine);
                }
            }

            Debug.Log("2 / Coroutines.Count(): " + Coroutines.Count() + " / endCoroutines.Count(): " + endCoroutines.Count());

            foreach (var coroutine in endCoroutines)
            {
                Coroutines.Remove(coroutine);
            }

            if (Coroutines.Count == 0)
            {
                //EditorApplication.update -= MoveNext;
                EditorWindow.GetWindow<DummyEditorWindow>().Close();
            }
            Debug.Log("3 / Coroutines.Count(): " + Coroutines.Count() + " / endCoroutines.Count(): " + endCoroutines.Count());
        }
    }
}
