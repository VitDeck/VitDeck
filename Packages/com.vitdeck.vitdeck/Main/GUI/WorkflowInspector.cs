using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using VitDeck.Main;
using VitDeck.Validator;

namespace Main.GUI
{
    [CustomEditor(typeof(Workflow))]
    public class WorkflowInspector : Editor
    {
        private string[] ruleSetTypeList = null;
        private string[] ruleSetTypeShortNameList = null;

        public override void OnInspectorGUI()
        {
            if (ruleSetTypeList == null)
            {
                InitializeRuleSetTypeList();
            }

            var ruleSetNameProperty = serializedObject.FindProperty("ruleSetTypeFullName");
            RuleSetSelectorField("RuleSet", ruleSetNameProperty);

            serializedObject.ApplyModifiedProperties();
        }

        private void InitializeRuleSetTypeList()
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

            ruleSetTypeList = ruleSets.Select(t => t.AssemblyQualifiedName).ToArray();
            ruleSetTypeShortNameList = ruleSets.Select(t => t.Name).ToArray();
        }


        private void RuleSetSelectorField(string label, SerializedProperty ruleSetNameField)
        {
            var name = ruleSetNameField.stringValue;
            var index = Array.IndexOf(ruleSetTypeList, name);
            index = EditorGUILayout.Popup(label, index, ruleSetTypeShortNameList);
            ruleSetNameField.stringValue = index >= 0 ? ruleSetTypeList[index] : "";
        }
    }
}