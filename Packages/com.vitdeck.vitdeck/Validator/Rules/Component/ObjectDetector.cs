using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator
{
    public interface IObjectDetector
    {
        bool IsTargetObject(Object target);
    }

    public class DefaultObjectDetector : IObjectDetector
    {
        public bool IsTargetObject(Object target)
        {
            return false;
        }
    }

    public class PrefabPartsDetector : IObjectDetector
    {
        private readonly HashSet<string> dictionary;

        public PrefabPartsDetector(string[] officialGUIDs)
        {
            dictionary = new HashSet<string>(officialGUIDs);
        }

        public PrefabPartsDetector(params string[][] officialGUIDs)
        {
            dictionary = new HashSet<string>(officialGUIDs.SelectMany(array => array).ToArray());
        }

        public bool IsTargetObject(Object target)
        {
            var prefab = PrefabUtility.GetCorrespondingObjectFromSource(target);
            if (prefab == null)
            {
                return false;
            }

            var guid = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(prefab));

            return dictionary.Contains(guid);
        }
    }
}
