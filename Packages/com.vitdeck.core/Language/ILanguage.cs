using System.Collections.Generic;

namespace VitDeck.Language
{
    /// <summary>
    /// 言語辞書を表すインターフェイス。
    /// </summary>
    public interface ILanguage: IEnumerable<KeyValuePair<string, string>>
    {
        bool TryGetValue(string key, out string value);
    }
}
