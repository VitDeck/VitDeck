using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VitDeck.Validator
{

    public abstract class ComponentRuleCommonLogics : BaseRule
    {
        public ComponentRuleCommonLogics(string name) : base(name)
        {
        }

        protected static bool HasVisibleComponents(Component[] components)
        {
            int visibleComponentCount = 0;
            foreach (var component in components)
            {
                if (!IsHidden(component))
                {
                    visibleComponentCount++;
                }
            }

            bool hasVisbleComponent = visibleComponentCount != 0;
            return hasVisbleComponent;
        }

        protected static bool HasVisibleComponents<TComponent>(TComponent[] components)
        {
            int visibleComponentCount = 0;
            foreach (var component in components)
            {
                var componentObject = component as Component;

                if (!IsHidden(componentObject))
                {
                    visibleComponentCount++;
                }
            }
            bool hasVisbleComponent = visibleComponentCount != 0;
            return hasVisbleComponent;
        }

        protected static bool IsHidden(Component component)
        {
            return (component.hideFlags & HideFlags.HideInInspector) != 0;
        }
    }

    /// <summary>
    /// 特定のコンポーネントを検証するルールのベース。
    /// </summary>
    public abstract class ComponentBaseRule : ComponentRuleCommonLogics
    {
        protected abstract System.Type GetTargetType();
        private readonly System.Type targetType;

        public ComponentBaseRule(string name) : base(name)
        {
            targetType = GetTargetType();
        }

        protected override void Logic(ValidationTarget target)
        {
            if (targetType == null)
            {
                return;
            }

            foreach (var gameObject in target.GetAllObjects())
            {
                var components = gameObject.GetComponents(targetType);

                if (components.Length == 0)
                    continue;

                if (!HasVisibleComponents(components))
                    continue;

                HasComponentObjectLogic(gameObject);

                foreach (var component in components)
                {
                    ComponentLogic(component);
                }
            }
        }

        protected abstract void HasComponentObjectLogic(UnityEngine.GameObject hasComponentObject);

        protected abstract void ComponentLogic(UnityEngine.Component component);
    }

    /// <summary>
    /// 特定のコンポーネントを検証するルールのベース（ジェネリック版）。
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    public abstract class ComponentBaseRule<TComponent> : ComponentRuleCommonLogics
    {
        public ComponentBaseRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            foreach (var gameObject in target.GetAllObjects())
            {
                var components = gameObject.GetComponents<TComponent>();

                if (components.Length == 0)
                    continue;

                if (!HasVisibleComponents(components))
                    continue;

                HasComponentObjectLogic(gameObject);

                foreach (var component in components)
                {
                    ComponentLogic(component);
                }
            }
        }

        protected abstract void HasComponentObjectLogic(UnityEngine.GameObject hasComponentObject);

        protected abstract void ComponentLogic(TComponent component);
    }
}
