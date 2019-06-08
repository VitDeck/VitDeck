using System;
using UnityEngine;

namespace VitDeck.Utilities
{
    [CreateAssetMenu]
    public class ProductInfo : ScriptableObject
    {
        [SerializeField]
        public string version = "";
    }
}