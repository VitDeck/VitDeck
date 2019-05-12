using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.TemplateLoader.Test
{
    public class TemplateLoaderTest
    {
        [Test]
        public void TestLoad()
        {
            Assert.That(TemplateLoader.Load("Sample_template", "Assets"), Is.True);
            //todo: #17 https://github.com/vkettools/VitDeck/issues/17
            AssetDatabase.CreateFolder("Assets", "TestTemplateLoad");
            Assert.That(TemplateLoader.Load("Sample_template", "Assets/TestTemplateLoad"), Is.True);
            LogAssert.Expect(LogType.Error, new Regex("^Template load failed.*"));
            TemplateLoader.Load("Sample_template", "Assets/TestTemplateLoad/invalid");

            AssetDatabase.DeleteAsset("Assets/{BOOTHID}_{NAME}");
            AssetDatabase.DeleteAsset("Assets/TestTemplateLoad");
        }
        [Test]
        public void TestGetTemplateFolders()
        {
            Assert.That(TemplateLoader.GetTemplateFolders().Length, Is.EqualTo(1));
            Assert.That(TemplateLoader.GetTemplateFolders()[0], Is.EqualTo("Sample_template"));
        }
        [Test]
        public void TestGetTemplateNames()
        {
            // ToDo: #18 https://github.com/vkettools/VitDeck/issues/18
            Assert.That(TemplateLoader.GetTemplateNames(new string[] { "Sample_template" }), Is.EqualTo(new string[] { "テンプレート名:Sample_template" }));
        }
        [Test]
        public void TestGetTemplateName()
        {
            // ToDo: #18 https://github.com/vkettools/VitDeck/issues/18
            Assert.That(TemplateLoader.GetTemplateName("Sample_template"), Is.EqualTo("テンプレート名:Sample_template"));
        }
    }
}
