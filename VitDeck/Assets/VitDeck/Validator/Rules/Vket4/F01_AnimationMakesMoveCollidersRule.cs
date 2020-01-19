using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;

namespace VitDeck.Validator
{
    public class AnimationMakesMoveCollidersRule : BaseRule
    {
        private struct AnimationClipContext
        {
            public readonly GameObject rootObject;
            public readonly AnimationClip clip;

            public AnimationClipContext(GameObject rootObject, AnimationClip clip)
            {
                this.rootObject = rootObject;
                this.clip = clip;
            }
        }

        private struct ColliderContext
        {
            public readonly Collider collider;
            public readonly GameObject rootObject;
            public readonly AnimationClip clip;

            public ColliderContext(Collider collider, GameObject rootObject, AnimationClip clip)
            {
                this.collider = collider;
                this.rootObject = rootObject;
                this.clip = clip;
            }
        }

        public AnimationMakesMoveCollidersRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var movableColliders = target.GetAllObjects()
                .SelectMany(EnumerateAttachedAnimationClips)
                .Distinct()
                .SelectMany(FindColliderReferenceInAnimationClip);

            foreach (var movableCollider in movableColliders)
            {
                AddIssue(new Issue(
                        movableCollider.collider,
                        IssueLevel.Error,
                        string.Format("親オブジェく({0})が持つAnimationによってColliderが動く可能性があります。", movableCollider.rootObject.name),
                        "Colliderを削除するか、オブジェクトをAnimationの対象から外すか、どうしてもアニメーションするColliderが必要な場合は申請を行ってください。"));
            }
        }


        private static IEnumerable<ColliderContext> FindColliderReferenceInAnimationClip(
            AnimationClipContext context)
        {
            var rootObject = context.rootObject;
            var motionSerialized = new SerializedObject(context.clip);

            var list = FindColliderReferenceInCurve(rootObject, motionSerialized.FindProperty("m_PositionCurves"))
                .Concat(FindColliderReferenceInCurve(rootObject, motionSerialized.FindProperty("m_EulerCurves")))
                .Concat(FindColliderReferenceInCurve(rootObject, motionSerialized.FindProperty("m_ScaleCurves")));

            foreach (var collider in list)
            {
                yield return new ColliderContext(collider, context.rootObject, context.clip);
            }
        }

        private static IEnumerable<Collider> FindColliderReferenceInCurve(
            GameObject rootObject,
            SerializedProperty positionCurves)
        {
            for (var i = 0; i < positionCurves.arraySize; i++)
            {
                var curve = positionCurves.GetArrayElementAtIndex(i);

                var path = curve.FindPropertyRelative("path");

                var target = rootObject.transform.Find(path.stringValue);

                if (target == null)
                {
                    yield break;
                }

                var colliders = target.GetComponentsInChildren<Collider>();
                foreach (var collider in colliders)
                {
                    yield return collider;
                }
            }
        }


        private static IEnumerable<AnimationClipContext> EnumerateAttachedAnimationClips(GameObject gameObject)
        {
            if (gameObject == null)
            {
                throw new System.ArgumentNullException("gameObject");
            }

            return EnumerateAllAnimationClips(gameObject)
                .Select(motion => new AnimationClipContext(gameObject, motion));
        }

        private static IEnumerable<AnimationClip> EnumerateAllAnimationClips(GameObject gameObject)
        {
            if (gameObject == null)
            {
                throw new System.ArgumentNullException("gameObject");
            }

            foreach (var animator in gameObject.GetComponents<Animator>())
            {
                foreach (var motion in EnumerateAllAnimationClips(animator))
                {
                    yield return motion;
                }
            }

            foreach (var animation in gameObject.GetComponents<Animation>())
            {
                foreach (var motion in EnumerateAllAnimationClips(animation))
                {
                    yield return motion;
                }
            }
        }

        private static IEnumerable<AnimationClip> EnumerateAllAnimationClips(Animation animation)
        {
            if (animation == null)
            {
                throw new System.ArgumentNullException("animation");
            }

            if (animation.clip != null)
            {
                yield return animation.clip;
            }

            var animationSerialized = new SerializedObject(animation);
            var animationsProperty = animationSerialized.FindProperty("m_Animations");

            for (int i = 0; i < animationsProperty.arraySize; i++)
            {
                var clip = animationsProperty.GetArrayElementAtIndex(i)
                    .objectReferenceValue
                    as AnimationClip;

                if (clip != null)
                {
                    yield return clip;
                }

            }
        }

        private static IEnumerable<AnimationClip> EnumerateAllAnimationClips(Animator animator)
        {
            if (animator == null)
            {
                throw new System.ArgumentNullException("animator");
            }
            var controller = animator.runtimeAnimatorController;

            if (controller == null)
            {
                yield break;
            }

            foreach (var clip in controller.animationClips)
            {
                yield return clip;
            }
        }
    }
}