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
            Assert.That(TemplateLoader.GetTemplateNames(new string[] { "invalid", "Sample_template" }), Is.EqualTo(new string[] { "No name[invalid]", "Sample Template" }));
        }
        [Test]
        public void TestGetTemplateName()
        {
            Assert.That(TemplateLoader.GetTemplateName("Sample_template"), Is.EqualTo("Sample Template"));
        }

        [Test]
        public void TestGetTemplateProperty()
        {
            Assert.That(TemplateLoader.GetTemplateProperty("Sample_template").templateName, Is.EqualTo("Sample Template"));
            Assert.That(TemplateLoader.GetTemplateProperty("Sample_template").description, Is.EqualTo("This is VitDeck sample template"));
            Assert.That(TemplateLoader.GetTemplateProperty("Sample_template").developer, Is.EqualTo("VitDeck"));
            Assert.That(TemplateLoader.GetTemplateProperty("Sample_template").developerUrl, Is.EqualTo("https://github.com/vkettools/VitDeck"));
            Assert.That(TemplateLoader.GetTemplateProperty("Sample_template").lisenseFile.name, Is.EqualTo("LICENSE"));
        }
    }
}
