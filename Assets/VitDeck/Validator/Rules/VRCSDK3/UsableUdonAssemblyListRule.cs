#if VRC_SDK_VRCSDK3
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;
using VRC.Udon;

namespace VitDeck.Validator
{
    /// <summary>
    /// UdonAssemblyの中で使用禁止処理の有無を検証する。
    /// </summary>
    /// <remarks>
    /// 複数のアセンブリリストを持ち、リストの設定に応じて許可/許否/要申請を決定します。
    /// また、プレハブをGUIDで与えることで、そのプレハブに元から追加してあるコンポーネントを許可されているものとして無視します。
    /// UsableComponentListRule と同じ使い方です。
    /// </remarks>
    internal class UsableUdonAssemblyListRule : BaseUdonBehaviourRule
    {
        private readonly UdonAssemblyReference[] references;

        private readonly ValidationLevel unregisteredAssemblyValidationLevel;

        private readonly HashSet<string> ignorePrefabs;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="references">アセンブリリスト</param>
        /// <param name="ignorePrefabGUIDs">例外Prefabのリスト</param>
        /// <param name="unregisteredAssembly">リストにないアセンブリの扱い</param>
        public UsableUdonAssemblyListRule(string name,
            UdonAssemblyReference[] references,
            string[] ignorePrefabGUIDs = null,
            ValidationLevel unregisteredAssembly = ValidationLevel.ALLOW)
            : base(name)
        {
            this.references = references ?? new UdonAssemblyReference[] { };
            if (ignorePrefabGUIDs == null)
            {
                ignorePrefabGUIDs = new string[0];
            }
            ignorePrefabs = new HashSet<string>(ignorePrefabGUIDs);
            unregisteredAssemblyValidationLevel = unregisteredAssembly;
        }

        protected override void ComponentLogic(UdonBehaviour component)
        {
            bool isIgnorePrefabInstance = IsIgnoredPrefab(component.gameObject);
            var isPrefabComponent = !PrefabUtility.IsAddedComponentOverride(component);
            if (isIgnorePrefabInstance && isPrefabComponent) return;
            // ProgramSource が null の場合はスルー
            if (component.programSource == null) return;
            
            // UdonProgramName
            var programName = component.programSource.name;

            // コード
            var code = GetDisassembleCode(component);

            // 探索
            bool found = false;
            foreach (var reference in references)
            {
                if (reference != null && reference.Exists(code))
                {
                    found = true;
                    AddAssemblyIssue(reference.name, component.gameObject, programName, reference.level);
                }
            }

            if (!found)
            {
                AddAssemblyIssue(LocalizedMessage.Get("UsableUdonAssemblyListRule.DefaultComponentGroupName"), component.gameObject, programName, unregisteredAssemblyValidationLevel);
            }
        }


        private bool IsIgnoredPrefab(GameObject obj)
        {
            if (PrefabUtility.GetPrefabType(obj) != PrefabType.PrefabInstance)
            {
                return false;
            }

            var asset = PrefabUtility.GetPrefabParent(obj);
            var path = AssetDatabase.GetAssetPath(asset);
            var guid = AssetDatabase.AssetPathToGUID(path);

            if (ignorePrefabs.Contains(guid))
            {
                return true;
            }


            return false;
        }

        private void AddAssemblyIssue(string name, GameObject obj, string AssemblyName, ValidationLevel level)
        {
            string message;

            switch (level)
            {
                case ValidationLevel.ALLOW:
                    break;
                case ValidationLevel.DISALLOW:
                    message = LocalizedMessage.Get("UsableUdonAssemblyListRule.Disallow", AssemblyName, name);
                    AddIssue(new Issue(obj, IssueLevel.Error, message, string.Empty, string.Empty));
                    break;
            }
        }
    }
}
#endif
