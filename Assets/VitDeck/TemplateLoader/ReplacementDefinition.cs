using System;
using UnityEngine;

namespace VitDeck.TemplateLoader
{
    /// <summary>
    /// テンプレート置換ルール定義情報クラス
    /// </summary>
    [Serializable]
    public class ReplacementDefinition
    {
        [SerializeField]
        public string ID;
        [SerializeField]
        public string searchString;
        [SerializeField]
        public string label;
    }
}