using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace VitDeck.Validator
{
    /// <summary>
    /// ブースのサイズ制限を調べるルール
    /// </summary>
    public class BoothBoundsRule : BaseRule
    {
        private const HideFlags DefaultFlagsForIndicator = HideFlags.DontSave | HideFlags.HideInInspector;

        private readonly Bounds limit;
        private readonly float margin;
        private readonly string floatToStringArgument;

        // ルールをValidation毎に生成する場合indicatorResetter.Reset()が叩かれなくなってしまう為、staticに設定
        private static BoundsIndicators.ResetTokenSource indicatorResetter = null;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="name">ルールの名前</param>
        /// <param name="size">バウンディングボックスの大きさ</param>
        /// <param name="margin">制限に持たせる余裕</param>
        public BoothBoundsRule(string name, Vector3 size, float margin)
            : this(name, size, margin, pivot: Vector3.zero) { }

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="name">ルールの名前</param>
        /// <param name="size">バウンディングボックスの大きさ</param>
        /// <param name="margin">制限に持たせる余裕</param>
        /// <param name="pivot">バウンディングボックスの原点（中心下）</param>
        public BoothBoundsRule(string name, Vector3 size, float margin, Vector3 pivot) : base(name)
        {
            var center = pivot + (Vector3.up * size.y * 0.5f);
            var limit = new Bounds(center, size);
            this.limit = limit;
            this.margin = margin;

            var maxDecimalPlaces = new float[] { size.x, size.y, size.z, margin }
                .Select(ToDecimalPlaces)
                .Max();
            floatToStringArgument = string.Format("f{0}", maxDecimalPlaces + 1);
        }

        private int ToDecimalPlaces(float val)
        {
            var pointIndex = val.ToString().IndexOf(".");
            if (pointIndex == -1)
                return 0;
            else
                return val.ToString().Substring(pointIndex).Length - 1;
        }

        protected override void Logic(ValidationTarget target)
        {
            if (indicatorResetter != null)
            {
                indicatorResetter.Reset();
            }
            indicatorResetter = new BoundsIndicators.ResetTokenSource();

            var rootObjects = target.GetRootObjects();

            foreach (var rootObject in rootObjects)
            {
                LogicForRootObject(rootObject);
            }
        }

        private void LogicForRootObject(GameObject rootObject)
        {
            var rootTransform = rootObject.transform;

            var rootTransformMemory = BoundsIndicators.TransformMemory.SaveAndReset(rootTransform);

            var validationLimit = new Bounds(limit.center + rootTransform.position, limit.size);
            validationLimit.Expand(margin);

            var exceeds = rootObject
                .GetComponentsInChildren<Transform>(true)
                .Select(transform => transform.gameObject)
                .SelectMany(GetObjectBounds)
                .Where(data => IsExceeded(data.bounds, validationLimit));

            var boundsIndicator = rootObject.AddComponent<BoundsIndicators.BoothRangeIndicator>();
            boundsIndicator.hideFlags = DefaultFlagsForIndicator;
            boundsIndicator.Initialize(validationLimit, indicatorResetter.Token);

            foreach (var exceed in exceeds)
            {
                var rectTransform = exceed.objectReference as RectTransform;
                if (rectTransform != null)
                {
                    var indicator = rectTransform.gameObject.AddComponent<BoundsIndicators.RectTransformRangeOutIndicator>();
                    indicator.hideFlags = DefaultFlagsForIndicator;
                    indicator.Initialize(boundsIndicator, rectTransform, indicatorResetter.Token);
                }
                else
                {
                    var transform = exceed.objectReference as Transform;
                    if (transform != null)
                    {
                        var indicator = transform.gameObject.AddComponent<BoundsIndicators.TransformRangeOutIndicator>();
                        indicator.hideFlags = DefaultFlagsForIndicator;
                        indicator.Initialize(boundsIndicator, indicatorResetter.Token);
                    }
                }

                var renderer = exceed.objectReference as Renderer;
                if (renderer != null)
                {
                    var indicator = renderer.gameObject.AddComponent<BoundsIndicators.RendererRangeOutIndicator>();
                    indicator.hideFlags = DefaultFlagsForIndicator;
                    indicator.Initialize(boundsIndicator, renderer, indicatorResetter.Token);
                }

                var limitSize = limit.size.ToString();
                var message = string.Format("オブジェクトがブースサイズ制限{0}の外に出ています。\n" +
                    "制限={1}\n" +
                    "対象={2}\n" +
                    "オブジェクトの種類={3}",
                    limitSize,
                    limit.ToString(floatToStringArgument),
                    exceed.bounds.ToString(floatToStringArgument),
                    exceed.objectReference.GetType().Name);

                AddIssue(new Issue(exceed.objectReference, IssueLevel.Error, message));
            }

            rootTransformMemory.Apply(rootTransform);
        }

        private bool IsExceeded(Bounds bounds, Bounds limit)
        {
            return
                !limit.Contains(bounds.min) ||
                !limit.Contains(bounds.max);
        }

        private static IEnumerable<BoundsData> GetObjectBounds(GameObject gameObject)
        {
            var transform = gameObject.transform;
            if (transform is RectTransform)
            {
                yield return BoundsData.FromRectTransform((RectTransform)transform);
            }
            else
            {
                yield return BoundsData.FromTransform(transform);
            }

            foreach (var renderer in gameObject.GetComponents<Renderer>())
            {
                yield return BoundsData.FromRenderer(renderer);
            }
        }

        private struct BoundsData
        {
            public readonly Object objectReference;
            public readonly Bounds bounds;

            public BoundsData(Object objectReference, Vector3 center)
                : this(objectReference, center, Vector3.zero) { }

            public BoundsData(Object objectReference, Vector3 center, Vector3 size)
                : this(objectReference, new Bounds(center, size)) { }

            public BoundsData(Object objectReference, Bounds bounds)
            {
                if (objectReference == null)
                    throw new System.ArgumentNullException("objectReference");
                this.objectReference = objectReference;
                this.bounds = bounds;
            }

            public static BoundsData FromTransform(Transform transform)
            {
                return new BoundsData(transform, transform.position);
            }

            public static BoundsData FromRectTransform(RectTransform transform)
            {
                var bounds = new Bounds(transform.position, Vector3.zero);

                var corners = new Vector3[4];
                transform.GetWorldCorners(corners);
                foreach (var corner in corners)
                {
                    bounds.Encapsulate(corner);
                }

                return new BoundsData(transform, bounds);
            }

            public static BoundsData FromRenderer(Renderer renderer)
            {
                //Recalculate bounds for ParticleSystem
                var particleSystem = renderer.gameObject.GetComponent<ParticleSystem>();
                if (particleSystem != null)
                    particleSystem.Simulate(0f);
                //Reculculate bounds for TrailRenderer
                if (renderer is TrailRenderer)
                {
                    var originalFlag = renderer.enabled;
                    renderer.enabled = !originalFlag;
                    renderer.enabled = originalFlag;
                }
                return new BoundsData(renderer, renderer.bounds);
            }
        }
    }
}
