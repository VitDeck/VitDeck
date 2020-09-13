using NUnit.Framework;
using System.Collections.Generic;
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
            var replaceList = new Dictionary<string, string>();
            replaceList.Add("BOOTHID", "id");
            replaceList.Add("NAME", "name");
            Assert.That(TemplateLoader.Load("Sample_template", replaceList, "Assets"), Is.True);
            AssetDatabase.CreateFolder("Assets", "TestTemplateLoad");
            Assert.That(TemplateLoader.Load("Sample_template", replaceList, "Assets/TestTemplateLoad"), Is.True);
            LogAssert.Expect(LogType.Error, new Regex("^Template load failed.*"));
            TemplateLoader.Load("Sample_template", replaceList, "Assets/TestTemplateLoad/invalid");
            LogAssert.Expect(LogType.Error, new Regex("^Template load failed.*"));
            TemplateLoader.Load("Sample_template", replaceList, "invalid");
            var invalidReplaceList = new Dictionary<string, string>();
            invalidReplaceList.Add("BOOTHID", "/");
            invalidReplaceList.Add("NAME", "test2");
            AssetDatabase.CreateFolder("Assets", "TestTemplateLoad2");
            LogAssert.Expect(LogType.Error, new Regex("^入力した文字列に使えない文字が含まれています。.*"));
            TemplateLoader.Load("Sample_template", invalidReplaceList, "Assets/TestTemplateLoad2");
        }
        [Test]
        public void TestFbxReferenceModifier()
        {
            var replaceList = new Dictionary<string, string>();
            replaceList.Add("BOOTHID", "id");
            replaceList.Add("NAME", "name");
            AssetDatabase.CreateFolder("Assets", "TestTemplateLoad");
            Assert.That(TemplateLoader.Load("Sample_template", replaceList, "Assets/TestTemplateLoad"), Is.True);
            var modelImporter = ModelImporter.GetAtPath("Assets/TestTemplateLoad/id_name/Models/Sample_object.fbx");
            var map = modelImporter.GetExternalObjectMap();
            foreach (var pair in map)
            {
                if (pair.Value is Material)
                {
                    var mat = pair.Value as Material;
                    var matPath = AssetDatabase.GetAssetPath(mat.GetInstanceID());
                    Assert.That(matPath, Is.EqualTo("Assets/TestTemplateLoad/id_name/Materials/Sample Material.mat"));
                }
            }
        }
        [Ignore("Vket用のテンプレートが用意され、制限に一致しなくなった為")]
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
            Assert.That(TemplateLoader.GetTemplateProperty("Sample_template").developerUrl, Is.EqualTo("https://github.com/vitdeck/VitDeck"));
            Assert.That(TemplateLoader.GetTemplateProperty("Sample_template").lisenseFile.name, Is.EqualTo("LICENSE"));
        }
        [TearDown]
        public void Destoroy()
        {
            AssetDatabase.DeleteAsset("Assets/id_name");
            AssetDatabase.DeleteAsset("Assets/TestTemplateLoad");
            AssetDatabase.DeleteAsset("Assets/TestTemplateLoad2");
        }
    }
}
