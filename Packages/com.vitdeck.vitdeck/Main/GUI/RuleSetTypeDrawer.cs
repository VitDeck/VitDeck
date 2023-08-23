using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Validator;

namespace VitDeck.Main.GUI
{
    [CustomPropertyDrawer(typeof(RuleSetTypeAttribute))]
    public class RuleSetTypeDrawer : PropertyDrawer
    {
        private static string[] ruleSetTypeNameList = null;
        private static string[] ruleSetTypeShortNameList = null;

        static RuleSetTypeDrawer()
        {
            InitializeRuleSetTypeNameList();
        }

        private static void InitializeRuleSetTypeNameList()
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

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var ruleSetTypeName = property.stringValue;
            var index = Array.IndexOf(ruleSetTypeNameList, ruleSetTypeName);
            index = EditorGUI.Popup(position, label.text, index, ruleSetTypeShortNameList);
            property.stringValue = index >= 0 ? ruleSetTypeNameList[index] : "";
        }
    }
}