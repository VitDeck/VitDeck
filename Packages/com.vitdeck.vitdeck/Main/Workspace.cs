using UnityEngine;

namespace VitDeck.Main
{
    [CreateAssetMenu(menuName = "VitDeck/Workspace")]
    public class Workspace : ScriptableObject
    {
        [SerializeField] private Workflow workflow;
    }
}