using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using VitDeck.Language;

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
                .SelectMany(FindColliderReferenceInAnimationClip)
                .Distinct();

            foreach (var movableCollider in movableColliders)
            {
                AddIssue(new Issue(
                        movableCollider.collider,
                        IssueLevel.Error,
                        LocalizedMessage.Get("AnimationMakesMoveCollidersRule.WillMakesMove", movableCollider.rootObject.name),
                        LocalizedMessage.Get("AnimationMakesMoveCollidersRule.WillMakesMove.Solution")));
            }
        }


        private static IEnumerable<ColliderContext> FindColliderReferenceInAnimationClip(
            AnimationClipContext context)
        {
            var rootObject = context.rootObject;
            var animationClip = context.clip;

            var bindings = AnimationUtility.GetCurveBindings(animationClip);
            foreach (var binding in bindings)
            {
                if (binding.type == typeof(Transform))
                {
                    var target = rootObject.transform.Find(binding.path);
                    if (target == null)
                    {
                        continue;
                    }

                    var parentRigid = target.GetComponentInParent<Rigidbody>();
                    if (parentRigid != null)
                    {
                        continue;
                    }

                    var colliders = target.GetComponentsInChildren<Collider>(true);
                    foreach (var collider in colliders)
                    {
                        yield return new ColliderContext(collider, rootObject, animationClip); ;
                    }
                }
                else if (binding.type.IsSubclassOf(typeof(Collider)))
                {
                    var target = rootObject.transform.Find(binding.path);
                    if (target == null)
                    {
                        continue;
                    }

                    var parentRigid = target.GetComponentInParent<Rigidbody>();
                    if (parentRigid != null)
                    {
                        continue;
                    }

                    var colliders = target.GetComponents<Collider>();
                    foreach (var collider in colliders)
                    {
                        yield return new ColliderContext(collider, rootObject, animationClip);
                    }
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
                .Select(animationClip => new AnimationClipContext(gameObject, animationClip));
        }

        private static IEnumerable<AnimationClip> EnumerateAllAnimationClips(GameObject gameObject)
        {
            if (gameObject == null)
            {
                throw new System.ArgumentNullException("gameObject");
            }

            foreach (var animator in gameObject.GetComponents<Animator>())
            {
                foreach (var animationClip in EnumerateAllAnimationClips(animator))
                {
                    yield return animationClip;
                }
            }

            foreach (var animation in gameObject.GetComponents<Animation>())
            {
                foreach (var animationClip in EnumerateAllAnimationClips(animation))
                {
                    yield return animationClip;
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