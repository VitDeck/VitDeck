using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class F02_AudioSourcePrefabRule : BasePrefabRule
    {

        public F02_AudioSourcePrefabRule(string name, string[] targetPrefabGUIDs) : base(name, targetPrefabGUIDs)
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
                    .Single(source => PrefabUtility.GetCorrespondingObjectFromSource<AudioSource>(source) == prefabObject);

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
                        LocalizedMessage.Get("F02_AudioSourcePrefabRule.DontLoop")
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
                            LocalizedMessage.Get("F02_AudioSourcePrefabRule.DontIncreaseMaxDistance", defaultValue, moddedValue)
                            ));
                    }
                }

            }
        }
    }
}