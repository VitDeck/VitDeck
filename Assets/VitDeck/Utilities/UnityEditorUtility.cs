using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;

namespace VitDeck.Utilities
{
    /// <summary>
    /// エディタでの作業に対する操作を提供するクラス。
    /// </summary>
    public static class UnityEditorUtility
    {
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
                EditorApplication.update += MoveNext;
            }
        }

        private static void MoveNext()
        {
            var endCoroutines = new List<IEnumerator>();

            foreach (var coroutine in Coroutines)
            {
                if (!coroutine.MoveNext())
                {
                    endCoroutines.Add(coroutine);
                }
            }

            foreach (var coroutine in endCoroutines)
            {
                Coroutines.Remove(coroutine);
            }

            if (Coroutines.Count == 0)
            {
                EditorApplication.update -= MoveNext;
            }
        }
    }
}
