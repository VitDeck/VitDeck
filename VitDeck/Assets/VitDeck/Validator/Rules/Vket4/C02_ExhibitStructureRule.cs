using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator
{
    public class C02_ExhibitStructureRule : BaseRule
    {
        public C02_ExhibitStructureRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootObjects = target.GetRootObjects();

            foreach (var rootObject in rootObjects)
            {
                LogicForRootObject(rootObject);
            }
        }

        void LogicForRootObject(GameObject rootObject)
        {
            GameObject staticRoot = null;
            GameObject dynamicRoot = null;

            foreach (Transform child in rootObject.transform)
            {
                if (child.name == "Static" && staticRoot == null)
                {
                    staticRoot = child.gameObject;
                }
                else if (child.name == "Dynamic" && dynamicRoot == null)
                {
                    dynamicRoot = child.gameObject;
                }
                else
                {
                    AddIssue(new Issue(
                        child,
                        IssueLevel.Error,
                        "出展物ルートオブジェクト直下に許可されていないオブジェクトが存在します。",
                        "出展物ルートオブジェクト直下には「Dynamic」「Static」という名前のオブジェクトを各1つずつ配置し、他の全てのオブジェクトはその中に入れて下さい。"
                        ));
                }
            }

            CheckRootObject(rootObject, "Static", staticRoot);
            CheckRootObject(rootObject, "Dynamic", dynamicRoot);
        }

        private void CheckRootObject(GameObject rootObject, string instanceName, GameObject instance)
        {
            if (instance == null)
            {
                AddIssue(new Issue(
                        rootObject,
                        IssueLevel.Error,
                        string.Format("{0}ルートオブジェクトが存在しません。", instanceName),
                        string.Format("出展物ルートオブジェクト直下に、「{0}」という名前のオブジェクトを作成してください。", instanceName)
                        ));
                return;
            }

            var components = instance.GetComponents<Component>();

            if (components.Length > 1 || components[0] is RectTransform)
            {
                AddIssue(new Issue(
                        instance,
                        IssueLevel.Error,
                        string.Format("{0}ルートオブジェクトにコンポーネントがアタッチされています。", instanceName),
                        string.Format("{0}ルートオブジェクトにはTransform以外のコンポーネントをアタッチしないでください。", instanceName)
                        ));
            }
        }
    }
}
