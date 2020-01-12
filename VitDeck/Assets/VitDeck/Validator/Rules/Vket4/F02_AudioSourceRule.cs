using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator
{
    public class F02_AudioSourceRule : BasePrefabRule
    {

        protected override string[] TargetPrefabGUIDs
        {
            get
            {
                return new string[]
                {
                    "e4309533ddcc0af4d90979c8c9e4f4d4",
                    "30766b1bee81dc84789f758f8ccafc3c",
                };
            }
        }

        public F02_AudioSourceRule(string name) : base(name)
        {
        }

        protected override void LogicForPrefabInstanceRoot(GameObject gameObject)
        {
            var audioSources = GetComponentsInChildrenSamePrefabInstance<AudioSource>(gameObject, true);
            var mods = PrefabUtility.GetPropertyModifications(gameObject);
            foreach (var mod in mods)
            {

                var prefabObject = mod.target as AudioSource;
                if (prefabObject == null)
                {
                    continue;
                }

                var prefabInstance = audioSources
                    .Where(source => PrefabUtility.GetPrefabParent(source) == prefabObject)
                    .Single();

                if (mod.propertyPath == "Loop")
                {
                    var defaultValue = prefabObject.loop;
                    var moddedValue = mod.value == "1";
                    if (defaultValue != moddedValue &&
                        moddedValue == true)
                    {
                        AddIssue(new Issue(
                        prefabInstance,
                        IssueLevel.Error,
                        "loop設定をオンに変更することは出来ません。"
                        ));
                    }
                }

                if (mod.propertyPath == "MaxDistance")
                {
                    var defaultValue = prefabObject.maxDistance;
                    var moddedValue = float.Parse(mod.value);

                    if (defaultValue < moddedValue)
                    {
                        AddIssue(new Issue(
                            prefabInstance,
                            IssueLevel.Error,
                            string.Format("MaxDistanceの値をPrefabの値({0})より大きい値({1})にすることは出来ません。", defaultValue, moddedValue)
                            ));
                    }
                }

            }
        }
    }
}