using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator
{
    public abstract class BasePrefabRule : BaseRule
    {

        private readonly HashSet<string> targetGUIDs;

        public BasePrefabRule(string name, string[] targetPrefabGUIDs) : base(name)
        {
            targetGUIDs = new HashSet<string>(targetPrefabGUIDs);
        }

        protected override void Logic(ValidationTarget target)
        {
            var objs = target.GetAllObjects()
                .Where(IsTargetPrefabInstanceRoot);

            foreach (var obj in objs)
            {
                LogicForPrefabInstanceRoot(obj);
            }
        }

        protected abstract void LogicForPrefabInstanceRoot(GameObject gameObject);

        protected bool IsTargetPrefabInstanceRoot(GameObject gameObject)
        {
            if (PrefabUtility.GetPrefabType(gameObject) != PrefabType.PrefabInstance)
            {
                return false;
            }

            if (PrefabUtility.FindPrefabRoot(gameObject) != gameObject)
            {
                return false;
            }

            var prefabObject = PrefabUtility.GetPrefabParent(gameObject);

            var prefabPath = AssetDatabase.GetAssetPath(prefabObject);

            var prefabGUID = AssetDatabase.AssetPathToGUID(prefabPath);

            if (!targetGUIDs.Contains(prefabGUID))
            {
                return false;
            }

            return true;
        }

        protected T[] GetComponentsInChildrenSamePrefabInstance<T>(GameObject gameObject, bool includeInactive = false)
        {
            var rootGameObject = PrefabUtility.FindPrefabRoot(gameObject);

            return gameObject.GetComponentsInChildren<Transform>(includeInactive)
                .Where(tf => PrefabUtility.FindPrefabRoot(tf.gameObject) == rootGameObject)
                .SelectMany(tf => tf.GetComponents<T>())
                .ToArray();
        }
    }
}