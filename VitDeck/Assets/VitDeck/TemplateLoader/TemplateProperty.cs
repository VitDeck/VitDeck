using UnityEngine;

namespace VitDeck.TemplateLoader
{
    [CreateAssetMenu(fileName = "Property.asset", menuName = "VitDeck/Template Property")]
    public class TemplateProperty : ScriptableObject
    {
        [SerializeField]
        public string templateName;
        [SerializeField]
        public string description;
        [SerializeField]
        public TextAsset lisenseFile;
        [SerializeField]
        public string developer;
        [SerializeField]
        public string developerUrl;
    }
}