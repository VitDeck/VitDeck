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
    internal class UdonAssemblyPhysicsCastFunctionRule : BaseUdonBehaviourRule
    {
        private readonly UdonAssemblyFunctionEssentialArgumentReference[] references;


        private readonly HashSet<string> ignorePrefabs;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="references">アセンブリリスト</param>
        /// <param name="ignorePrefabGUIDs">例外Prefabのリスト</param>
        public UdonAssemblyPhysicsCastFunctionRule(string name,
            UdonAssemblyFunctionEssentialArgumentReference[] references,
            string[] ignorePrefabGUIDs = null)
            : base(name)
        {
            this.references = references ?? new UdonAssemblyFunctionEssentialArgumentReference[] { };
            if (ignorePrefabGUIDs == null)
            {
                ignorePrefabGUIDs = new string[0];
            }
            ignorePrefabs = new HashSet<string>(ignorePrefabGUIDs);
        }

        protected override void ComponentLogic(UdonBehaviour component)
        {
            bool isIgnorePrefabInstance = IsIgnoredPrefab(component.gameObject);
            var isPrefabComponent = !PrefabUtility.IsAddedComponentOverride(component);
            if (isIgnorePrefabInstance && isPrefabComponent) return;
            
            // UdonProgramName
            var programName = component.programSource.name;

            // プログラム
            var program = GetUdonProgram(component);
            // コード
            var code = GetDisassembleCode(component);

            // 探索
            var rows = code.Replace("\r\n","\n").Split(new[]{'\n','\r'});
            var rowNum = 1;
            foreach (var row in rows)
            {
                foreach (var reference in references)
                {
                    if (reference != null && reference.hasInvalidArguments(row))
                    {
                        AddIssue(new Issue(component, IssueLevel.Error,
                            LocalizedMessage.Get("UdonAssemblyPhysicsCastFunctionRule.InvalidArguments", reference.name, row, rowNum),
                        LocalizedMessage.Get("UdonAssemblyPhysicsCastFunctionRule.InvalidArguments.Solution", reference.name, reference.essentialsName),
                            string.Empty));
                    }
                }

                rowNum++;
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
    }
}
#endif
