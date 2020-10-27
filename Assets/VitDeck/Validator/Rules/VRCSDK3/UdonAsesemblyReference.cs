#if VRC_SDK_VRCSDK3
using System;

namespace VitDeck.Validator
{
    /// <summary>
    /// UdonAssemblyの使用可否についての参照情報を定義する
    /// </summary>
    public class UdonAssemblyReference
    {
        public string name;
        public string[] fullNames;
        public ValidationLevel level; // Reference From ComponentReference

        /// <summary>
        /// アセンブリの検証レベル定義
        /// </summary>
        /// <param name="name">検証対象アセンブリの種類</param>
        /// <param name="fullNames">対象アセンブリの配列</param>
        /// <param name="level">検証レベル</param>
        public UdonAssemblyReference(string name, string[] fullNames, ValidationLevel level)
        {
            this.name = name;
            this.fullNames = fullNames;
            this.level = level;
        }
        /// <summary>
        /// 引数のアセンブリが対象に含まれるか調べる。
        /// </summary>
        /// <param name="code">一致するか調べるアセンブリ</param>
        /// <returns>存在する場合はtrueを返す</returns>
        public bool Exists(string code)
        {
            return Array.Exists(fullNames, checkAssemblyName => code.IndexOf(checkAssemblyName, StringComparison.Ordinal) != -1 );
        }
    }
}
#endif
