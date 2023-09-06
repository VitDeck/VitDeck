#if VRC_SDK_VRCSDK3
using System;

namespace VitDeck.Validator
{
    /// <summary>
    /// UdonAssemblyの使用可否についての参照情報を定義する
    /// </summary>
    public class UdonAssemblyFunctionEssentialArgumentReference
    {
        public string name;
        public string essentialsName;
        public string[] fullNames;
        public string essentialArgument;

        /// <summary>
        /// アセンブリの検証レベル定義
        /// </summary>
        /// <param name="name">検証対象アセンブリの種類</param>
        /// <param name="essentialsName">必要な引数の名称</param>
        /// <param name="fullNames">対象アセンブリの配列</param>
        /// <param name="essentialArgument">必要な引数</param>
        public UdonAssemblyFunctionEssentialArgumentReference(string name, string essentialsName, string[] fullNames, string essentialArgument)
        {
            this.name = name;
            this.essentialsName = essentialsName;
            this.fullNames = fullNames;
            this.essentialArgument = essentialArgument;
        }
        /// <summary>
        /// 関数が対象のアセンブリに含まれるか調べる。
        /// </summary>
        /// <param name="code">調査対象のアセンブリコード</param>
        /// <returns>存在する場合はtrueを返す</returns>
        public bool ExistsTargetFunction(string code)
        {
            return Array.Exists(fullNames, checkFunctionName => code.IndexOf(checkFunctionName, StringComparison.Ordinal) != -1);
        }
        /// <summary>
        /// 必須引数が対象のアセンブリに含まれるか調べる。
        /// </summary>
        /// <param name="code">一致するか調べるアセンブリ</param>
        /// <returns>存在する場合はtrueを返す</returns>
        public bool ExistsEssentialArguments(string code)
        {
            return code.IndexOf(essentialArgument, StringComparison.Ordinal) != -1;
        }
    }
}
#endif
