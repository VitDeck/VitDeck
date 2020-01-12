using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VRCSDK2;

namespace VitDeck.Validator
{
    public class F02_PickupObjectSyncPrefabRule : BasePrefabRule
    {

        public F02_PickupObjectSyncPrefabRule(string name, string[] targetPrefabGUIDs) : base(name, targetPrefabGUIDs)
        {
        }

        protected override void LogicForPrefabInstanceRoot(GameObject gameObject)
        {
            var objectSyncComponents = gameObject.GetComponentsInChildren<VRC_ObjectSync>(true);
            foreach (var objectSync in objectSyncComponents)
            {
                if (!objectSync.isActiveAndEnabled)
                {
                    AddIssue(new Issue(
                        objectSync,
                        IssueLevel.Error,
                        "VRC_ObjectSyncを非アクティブにすることは出来ません。"));
                }

                if (objectSync.AllowCollisionTransfer)
                {
                    AddIssue(new Issue(
                        objectSync,
                        IssueLevel.Error,
                        "VRC_ObjectSyncのAllowCollisionTransferを使用することは出来ません。"));
                }
            }

            var rigidbodies = GetComponentsInChildrenSamePrefabInstance<Rigidbody>(gameObject, true);
            foreach (var rigidbody in rigidbodies)
            {
                if (!rigidbody.isKinematic)
                {
                    AddIssue(new Issue(
                        rigidbody,
                        IssueLevel.Error,
                        "RigidbodyのIsKinematicは必ず有効にして下さい。"));
                }
            }

            ValidateParent(gameObject.transform.parent, gameObject);
        }

        private void ValidateParent(Transform transform, GameObject targetGameObject)
        {
            if (transform == null)
            {
                return;
            }

            if (PrefabUtility.GetPrefabType(transform) != PrefabType.PrefabInstance)
            {
                ValidateParent(transform.parent, targetGameObject);
            }

            var prefabRoot = PrefabUtility.FindPrefabRoot(transform.gameObject);
            if (IsTargetPrefabInstanceRoot(prefabRoot))
            {
                AddIssue(new Issue(
                    targetGameObject,
                    IssueLevel.Error,
                    "PickupObjectSyncを入れ子にすることは出来ません。"));
            }
        }
    }
}