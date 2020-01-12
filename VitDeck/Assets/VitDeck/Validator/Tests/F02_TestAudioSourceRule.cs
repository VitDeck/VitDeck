using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestAudioSourceRule
    {
        [Test]
        public void TestLoopValidate()
        {
            var guid = AssetDatabase.AssetPathToGUID("Assets/VitDeck/Validator/Tests/Data/F02_AudioSourcePrefabRule/ForLoopValidation.prefab");
            var target = new ValidationTargetFinder().Find("Assets/VitDeck/Validator/Tests/Data/F02_AudioSourcePrefabRule", true);
            var result = new F02_AudioSourcePrefabRule("", new string[] { guid }).Validate(target);


            var issues = result.Issues;
            Assert.That(issues.Count, Is.EqualTo(2));
            Assert.That(issues[0].target, Is.Not.EqualTo(issues[1].target));

            foreach (var issue in issues)
            {
                var audioSource = (AudioSource)issue.target;
                Assert.That(audioSource.loop, Is.True);
            }
        }

        [Test]
        public void TestMaxDistanceValidate()
        {
            var guid = AssetDatabase.AssetPathToGUID("Assets/VitDeck/Validator/Tests/Data/F02_AudioSourcePrefabRule/ForMaxDistanceValidation.prefab");
            var target = new ValidationTargetFinder().Find("Assets/VitDeck/Validator/Tests/Data/F02_AudioSourcePrefabRule", true);
            var result = new F02_AudioSourcePrefabRule("", new string[] { guid }).Validate(target);

            var prefabMaxDistanceValue = 10f;

            var issues = result.Issues;
            Assert.That(issues.Count, Is.EqualTo(1));

            foreach (var issue in issues)
            {
                var audioSource = (AudioSource)issue.target;
                Assert.That(audioSource.maxDistance, Is.GreaterThan(prefabMaxDistanceValue));
            }
        }
    }
}
