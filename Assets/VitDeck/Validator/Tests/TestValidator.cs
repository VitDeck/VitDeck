using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestValidator
    {
        [Test]
        public void TestValidate()
        {
            var ruleSet = new SampleRuleSet();
            var results = Validator.Validate(ruleSet, "Assets/VitDeck/Validator/Tests/Validate", true);
            foreach (var result in results)
            {
                Debug.Log(result.GetResultLog());
            }
            Assert.That(results.Length, Is.AtLeast(1));
        }
        [Test]
        public void TestValidateException()
        {
            var ruleSet = new ExceptionRuleSet();
            //Find中の例外
            var results = Validator.Validate(ruleSet, "invalid", true);
            LogAssert.Expect(LogType.Error, new Regex(@".*"));
            Assert.That(results.Length, Is.AtLeast(1));
            Assert.That(results[0].Issues.Count, Is.EqualTo(1));
            Assert.That(results[0].Issues[0].target, Is.EqualTo(null));
            Assert.That(results[0].Issues[0].level, Is.EqualTo(IssueLevel.Fatal));
            Assert.That(results[0].Issues[0].message, Is.EqualTo("正しいベースフォルダを指定してください。:invalid"));
            Assert.That(results[0].Issues[0].solution, Is.EqualTo(""));
            Assert.That(results[0].Issues[0].solutionURL, Is.EqualTo(""));
            //Validate中の例外
            results = Validator.Validate(ruleSet, "Assets/VitDeck/Validator/Tests/Validate", true);
            LogAssert.Expect(LogType.Error, new Regex(@".*"));
        }
        [Test]
        public void TestRuleSet()
        {
            var ruleSet = new SampleRuleSet();
            Assert.That(ruleSet.RuleSetName, Is.EqualTo("サンプルルールセット"));
            Assert.That(ruleSet.GetRules().Length, Is.AtLeast(1));
        }
        [Test]
        public void TestValidationtarget()
        {
            var baseFolderPath = "Assets/VitDeck/Validator/Tests";
            var assetGuids = new string[] { "testguid" };
            var assetPaths = new string[] { "testPath", "testPath2" };
            var assetObjects = new Object[] { };
            var scenes = new Scene[] { new Scene() };
            var rootObjects = new GameObject[] { };
            var allObjects = new GameObject[] { };
            var target = new ValidationTarget(baseFolderPath,
                assetGuids,
                assetPaths,
                assetObjects,
                scenes,
                rootObjects,
                allObjects);
            Assert.That(target.GetBaseFolderPath(), Is.EqualTo(baseFolderPath));
            Assert.That(target.GetAllAssetGuids(), Is.EqualTo(assetGuids));
            Assert.That(target.GetAllAssetPaths(), Is.EqualTo(assetPaths));
            Assert.That(target.GetAllAssets(), Is.EqualTo(assetObjects));
            Assert.That(target.GetScenes(), Is.EqualTo(scenes));
            Assert.That(target.GetRootObjects(), Is.EqualTo(rootObjects));
            Assert.That(target.GetAllObjects(), Is.EqualTo(allObjects));
        }
        [Test]
        public void TestValidationtargetError()
        {
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests");
            Assert.That(() => target.GetAllAssetGuids(),
                Throws.Exception.TypeOf<FatalValidationErrorException>()
                .And.Message.EqualTo("Faild to get asset GUIDs."));
            Assert.That(() => target.GetAllAssetPaths(),
                Throws.Exception.TypeOf<FatalValidationErrorException>()
                .And.Message.EqualTo("Faild to get asset Paths."));
            Assert.That(() => target.GetAllAssets(),
                Throws.Exception.TypeOf<FatalValidationErrorException>()
                .And.Message.EqualTo("Faild to get asset Objects."));
            Assert.That(() => target.GetScenes(),
                Throws.Exception.TypeOf<FatalValidationErrorException>()
                .And.Message.EqualTo("Faild to get scenes."));
            Assert.That(() => target.GetRootObjects(),
                 Throws.Exception.TypeOf<FatalValidationErrorException>()
                 .And.Message.EqualTo("Faild to get root objects."));
            Assert.That(() => target.GetAllObjects(),
                 Throws.Exception.TypeOf<FatalValidationErrorException>()
                 .And.Message.EqualTo("Faild to get all objects."));
        }
    }
}
