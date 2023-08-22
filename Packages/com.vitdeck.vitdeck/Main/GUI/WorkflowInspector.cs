using System;
using System.Linq;
using UnityEditor;
using VitDeck.Main;
using VitDeck.Validator;

namespace Main.GUI
{
    [CustomEditor(typeof(Workflow))]
    public class WorkflowInspector : Editor
    {
        private string[] ruleSetTypeNameList = null;
        private string[] ruleSetTypeShortNameList = null;

        public override void OnInspectorGUI()
        {
            if (ruleSetTypeNameList == null)
            {
                InitializeRuleSetTypeNameList();
            }

            var ruleSetNameProperty = serializedObject.FindProperty("ruleSetTypeFullName");
            RuleSetSelectorField("RuleSet", ruleSetNameProperty);

            serializedObject.ApplyModifiedProperties();
        }

        private void InitializeRuleSetTypeNameList()
        {
            var interfaceType = typeof(IRuleSet);
            var ruleSets = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(t =>
                    interfaceType.IsAssignableFrom(t) && // IRuleSetを実装している
                    !t.IsInterface && // インターフェースではない
                    !t.IsAbstract && // 抽象クラスではない
                    t.GetConstructor(Type.EmptyTypes) != null) // デフォルトコンストラクタを持つ
                .ToArray();

            ruleSetTypeNameList = ruleSets.Select(t => t.AssemblyQualifiedName).ToArray();
            ruleSetTypeShortNameList = ruleSets.Select(t => t.Name).ToArray();
        }

        private void RuleSetSelectorField(string label, SerializedProperty ruleSetTypeNameProperty)
        {
            var ruleSetTypeName = ruleSetTypeNameProperty.stringValue;
            var index = Array.IndexOf(ruleSetTypeNameList, ruleSetTypeName);
            index = EditorGUILayout.Popup(label, index, ruleSetTypeShortNameList);
            ruleSetTypeNameProperty.stringValue = index >= 0 ? ruleSetTypeNameList[index] : "";
        }
    }
}