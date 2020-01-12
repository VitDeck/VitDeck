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

        protected override string[] TargetPrefabGUIDs
        {
            get
            {
                return new string[]
                {
                    "2ddf6495f088e214894068e967b329a6",
                    "d6df6cb557aadb34db36e3e1f504a4db",
                    "e92515ba689fb0b4f8d45b7f2e3e8f46",
                    "29904c5b13768154bb4056beab9fa3d1",
                    "bc67edeb6db9ffb438e33ad436221244",
                    "1c13412f710ee6f429cde5858575c225",
                };
            }
        }

        public F02_PickupObjectSyncPrefabRule(string name) : base(name)
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