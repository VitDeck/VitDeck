using System;
using UnityEngine;

namespace VitDeck.Validator
{
    /// <summary>
    ///コンポーネントの使用可否についての参照情報を定義する
    /// </summary>
    public class ComponentReference
    {
        public string name;
        public string[] fullNames;
        public ValidationLevel level;

        /// <summary>
        /// コンポーネントの検証レベル定義
        /// </summary>
        /// <param name="name">検証対象コンポーネントの種類</param>
        /// <param name="fullNames">対象コンポーネントのクラス完全名の配列</param>
        /// <param name="level">検証レベル</param>
        public ComponentReference(string name, string[] fullNames, ValidationLevel level)
        {
            this.name = name;
            this.fullNames = fullNames;
            this.level = level;
        }
        /// <summary>
        /// 引数のコンポーネントが対象コンポーネントに含まれるか調べる。
        /// </summary>
        /// <param name="comp">一致するか調べるコンポーネント</param>
        /// <returns>存在する場合はtrueを返す</returns>
        public bool Exists(Component comp)
        {
            return Array.Exists(fullNames, name => name == comp.GetType().FullName);
        }
    }
    /// <summary>
    ///使用可能コンポーネントの判定
    /// ALLOW：許可
    /// DISALLOW：禁止
    /// </summary>
    public enum ValidationLevel
    {
        ALLOW,
        DISALLOW
    }
}