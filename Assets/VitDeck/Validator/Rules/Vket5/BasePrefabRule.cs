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
            if (PrefabUtility.GetPrefabInstanceStatus(gameObject) != PrefabInstanceStatus.Connected)
            {
                return false;
            }

            if (PrefabUtility.GetOutermostPrefabInstanceRoot(gameObject) != gameObject)
            {
                return false;
            }

            var prefabObject = PrefabUtility.GetCorrespondingObjectFromSource(gameObject);

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
            var rootGameObject = PrefabUtility.GetOutermostPrefabInstanceRoot(gameObject);

            return gameObject.GetComponentsInChildren<Transform>(includeInactive)
                .Where(tf => PrefabUtility.GetOutermostPrefabInstanceRoot(tf.gameObject) == rootGameObject)
                .SelectMany(tf => tf.GetComponents<T>())
                .ToArray();
        }
    }
}