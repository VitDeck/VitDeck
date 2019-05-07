using UnityEngine;

[CreateAssetMenu(menuName = "VitDeck/Template Property")]
public class TemplateProperty : ScriptableObject
{
    [SerializeField]
    string templateName;
    [SerializeField]
    string description;
    [SerializeField]
    TextAsset lisenseFile;
    [SerializeField]
    string developperUrl;
}