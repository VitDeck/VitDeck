using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;
using VitDeck.Exporter;

namespace VitDeck.Main.ValidatedExporter.Tests
{
    /*
    public class TestValidatedExporter
    {
        private string testExportFolder = "Assets/VitDeckTestExport";
        [Test]
        public void TestExport()
        {
            var filename = "test.unitypackage";
            var baseFolderPath = "Assets/VitDeck/Exporter/Tests/TestBaseFolder";
            var setting = ScriptableObject.CreateInstance(typeof(ExportSetting)) as ExportSetting;
            setting.SettingName = "";
            setting.Description = "";
            setting.ExportFolderPath = testExportFolder;
            setting.fileNameFormat = filename;
            setting.ruleSetName = "PassRuleSet";
            var result = ValidatedExporter.ValidatedExport(baseFolderPath, setting, false, true);
            Assert.That(result.forceExport, Is.False);
            Assert.That(result.exportResult, Is.Not.Null);
            Assert.That(result.validationResults, Is.Not.Empty);
            Assert.That(string.IsNullOrEmpty(result.log));
            Assert.That(File.Exists(result.exportResult.exportFilePath));
        }
        [Test]
        public void TestExportError()
        {
            var filename = "testError.unitypackage";
            var baseFolderPath = "Assets/VitDeck/Exporter/Tests/TestBaseFolder";
            var setting = new ExportSetting();
            setting.SettingName = "";
            setting.Description = "";
            setting.ExportFolderPath = testExportFolder;
            setting.fileNameFormat = filename;
            setting.ruleSetName = "";
            ValidatedExporter.ValidatedExport(baseFolderPath, setting, false);
            //ファイル重複していた場合
            ValidatedExportResult willFailResult = new ValidatedExportResult(false);
            LogAssert.Expect(LogType.Error, new Regex(@"^System\.IO\.IOException.*"));
            Assert.DoesNotThrow(() => willFailResult = ValidatedExporter.ValidatedExport(baseFolderPath, setting, false));
            Assert.That(willFailResult.exportResult, Is.Not.Null);
            var willPassResult = ValidatedExporter.ValidatedExport(baseFolderPath, setting, true);
            Assert.That(willPassResult.exportResult.exportResult, Is.True);
        }
        [Test]
        public void TestExportException()
        {
            var filename = "testException.unitypackage";
            var baseFolderPath = "Assets/VitDeck/Exporter/Tests/TestBaseFolder";
            var setting = new ExportSetting();
            setting.SettingName = "";
            setting.Description = "";
            setting.ExportFolderPath = testExportFolder;
            setting.fileNameFormat = filename;
            setting.ruleSetName = "";
            //setting null
            Assert.That(() => ValidatedExporter.ValidatedExport(baseFolderPath, null, false), Throws.ArgumentNullException);
            //basefolder null
            Assert.That(() => ValidatedExporter.ValidatedExport(null, setting, false), Throws.ArgumentNullException);
            //exportFolderPath empty
            setting.ExportFolderPath = "";
            Assert.That(() => ValidatedExporter.ValidatedExport(null, setting, false), Throws.ArgumentNullException);
            //exportFolderPath does not start with `Assets`
            setting.ExportFolderPath = "InvalidPath/Export";
            Assert.That(() => ValidatedExporter.ValidatedExport(null, setting, false), Throws.ArgumentNullException);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (Directory.Exists(testExportFolder))
                Directory.Delete(testExportFolder, true);
        }
    }
    */
}
