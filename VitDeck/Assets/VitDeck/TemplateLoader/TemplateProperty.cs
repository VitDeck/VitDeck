using UnityEngine;

namespace VitDeck.TemplateLoader
{
    [CreateAssetMenu(fileName = "Property.asset", menuName = "VitDeck/Template Property")]
    public class TemplateProperty : ScriptableObject
    {
        [SerializeField]
        string templateName;
        [SerializeField]
        string description;
        [SerializeField]
        TextAsset lisenseFile;
        [SerializeField]
        string developer;
        [SerializeField]
        string developerUrl;
    }
}