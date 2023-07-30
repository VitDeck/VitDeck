using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// 使用可能なコンポーネントを検証する。
    /// </summary>
    /// <remarks>
    /// 複数のコンポーネントリストを持ち、リストの設定に応じて許可/許否/要申請を決定します。
    /// また、プレハブをGUIDで与えることで、そのプレハブに元から追加してあるコンポーネントを許可されているものとして無視します。
    /// </remarks>
    public class UsableComponentListRule : BaseRule
    {
        private readonly IEnumerable<ComponentReference> references;

        private readonly ValidationLevel unregisteredComponentValidationLevel;

        private readonly HashSet<string> ignorePrefabs;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="references">コンポーネントリスト</param>
        /// <param name="ignorePrefabGUIDs">例外Prefabのリスト</param>
        /// <param name="unregisteredComponent">リストにないコンポーネントの扱い</param>
        public UsableComponentListRule(string name,
            IEnumerable<ComponentReference> references,
            string[] ignorePrefabGUIDs = null,
            ValidationLevel unregisteredComponent = ValidationLevel.ALLOW)
            : base(name)
        {
            this.references = references ?? new ComponentReference[] { };
            if (ignorePrefabGUIDs == null)
            {
                ignorePrefabGUIDs = new string[0];
            }
            ignorePrefabs = new HashSet<string>(ignorePrefabGUIDs);
            unregisteredComponentValidationLevel = unregisteredComponent;
        }

        protected override void Logic(ValidationTarget target)
        {
            foreach (var gameObject in target.GetAllObjects())
            {
                var components = gameObject.GetComponents<Component>();
                foreach (var component in components)
                {
                    if (component == null ||
                        component is Transform)
                        continue;

                    if ((component.hideFlags & HideFlags.DontSaveInEditor) == HideFlags.DontSaveInEditor)
                    {
                        continue;
                    }
                    var isPrefabComponent = !PrefabUtility.IsAddedComponentOverride(component);
                    if (IsIgnoredComponent(component) &&
                        isPrefabComponent)
                    {
                        continue;
                    }

                    bool found = false;
                    foreach (var reference in references)
                    {
                        if (reference != null && reference.Exists(component))
                        {
                            found = true;
                            AddComponentIssue(reference.name, gameObject, component, reference.level);
                        }
                    }

                    if (!found)
                    {
                        AddComponentIssue(LocalizedMessage.Get("UsableComponentListRule.DefaultComponentGroupName"), gameObject, component, unregisteredComponentValidationLevel);
                    }
                }
            }
        }

        private bool IsIgnoredComponent(Component cp)
        {
            if (PrefabUtility.GetPrefabInstanceStatus(cp) != PrefabInstanceStatus.Connected)
            {
                return false;
            }

            var prefabObject = PrefabUtility.GetCorrespondingObjectFromOriginalSource(cp);
            var path = AssetDatabase.GetAssetPath(prefabObject);
            var guid = AssetDatabase.AssetPathToGUID(path);

            if (ignorePrefabs.Contains(guid))
            {
                return true;
            }

            return false;
        }

        private void AddComponentIssue(string name, GameObject obj, Component component, ValidationLevel level)
        {
            string message;
            string solution;
            string solutionURL;
            
            switch (level)
            {
                case ValidationLevel.ALLOW:
                    break;
                case ValidationLevel.DISALLOW:
                    message = LocalizedMessage.Get("UsableComponentListRule.Disallow", name, component.GetType().Name);
                    solution = LocalizedMessage.Get("UsableComponentListRule.Disallow.Solution");
                    solutionURL = LocalizedMessage.Get("UsableComponentListRule.Disallow.SolutionURL");
                    
                    AddIssue(new Issue(obj, IssueLevel.Error, message, solution, solutionURL));
                    break;
            }
        }
    }
}
