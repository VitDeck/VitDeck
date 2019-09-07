using UnityEngine;

namespace VitDeck.Utilities
{
    public class ProductInfo : ScriptableObject
    {
        [SerializeField]
        public string version = "";
        [SerializeField]
        public string developerLinkTitle = "VitDeck on GitHub";
        [SerializeField]
        public string developerLinkURL = "https://github.com/vitdeck/VitDeck";
    }
}