using System.Collections.Generic;
using System.IO;

namespace VitDeck.TemplateLoader
{
    /// <summary>
    /// アセットのguid参照を置換する機能を提供する。
    /// </summary>
    internal class GuidReferenceModifier : IReferenceModifier
    {
        Dictionary<string, string> replaceGuidPairDictionary;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_replaceGuidPairDictionary">置換前guid、置換後guidをペアとする辞書</param>
        public GuidReferenceModifier(Dictionary<string, string> _replaceGuidPairDictionary)
        {
            replaceGuidPairDictionary = _replaceGuidPairDictionary;
        }

        public void Modify(string path)
        {
            if (replaceGuidPairDictionary == null)
                return;
            string s = string.Empty;
            using (StreamReader sr = new StreamReader(Path.GetFullPath(path)))
            {
                s = sr.ReadToEnd();
                sr.Close();
            }
            string replaced = s;
            foreach (var guid in replaceGuidPairDictionary.Keys)
            {
                replaced = replaced.Replace(guid, replaceGuidPairDictionary[guid]);
            }
            if (s != replaced)
            {
                using (StreamWriter sw = new StreamWriter(Path.GetFullPath(path)))
                {
                    sw.Write(replaced);
                    sw.Close();
                }
            }
        }
    }
}