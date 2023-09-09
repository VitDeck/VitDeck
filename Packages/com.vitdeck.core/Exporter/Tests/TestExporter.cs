using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Exporter.Tests
{
    public class TestExporter
    {
        private string testExportFolder = "Assets/VitDeckTestExport";
        [Test]
        public void TestExport()
        {
            var filename = "test.unitypackage";
            var baseFolderPath = "Packages/com.vitdeck.core/Exporter/Tests/TestBaseFolder";
            var setting = new ExportSetting();
            setting.SettingName = "";
            setting.Description = "";
            setting.ExportFolderPath = testExportFolder;
            setting.fileNameFormat = filename;
            setting.ruleSetName = "";
            var result = Exporter.Export(baseFolderPath, setting, false);
            Assert.That(result.exportResult, Is.True);
            Assert.That(result.exportFilePath, Is.EqualTo(testExportFolder + Path.AltDirectorySeparatorChar + filename));
            Assert.That(result.log, Is.Not.Empty);
            Assert.That(File.Exists(result.exportFilePath));
        }
        [Test]
        public void TestExportError()
        {
            var filename = "testError.unitypackage";
            var baseFolderPath = "Packages/com.vitdeck.core/Exporter/Tests/TestBaseFolder";
            var setting = new ExportSetting();
            setting.SettingName = "";
            setting.Description = "";
            setting.ExportFolderPath = testExportFolder;
            setting.fileNameFormat = filename;
            setting.ruleSetName = "";
            Exporter.Export(baseFolderPath, setting, false);
            //ファイル重複していた場合
            ExportResult willFailResult = new ExportResult();
            willFailResult.exportResult = true;
            LogAssert.Expect(LogType.Error, new Regex(@"^System\.IO\.IOException.*"));
            Assert.DoesNotThrow(() => willFailResult = Exporter.Export(baseFolderPath, setting, false));
            Assert.That(willFailResult.exportResult, Is.False);
            Assert.That(willFailResult.exportFilePath, Is.Null);
            Assert.That(willFailResult.log, Is.Not.Empty);
            var willPassResult = Exporter.Export(baseFolderPath, setting, true);
            Assert.That(willPassResult.exportResult, Is.True);
        }
        [Test]
        public void TestExportException()
        {
            var filename = "testException.unitypackage";
            var baseFolderPath = "Packages/com.vitdeck.core/Exporter/Tests/TestBaseFolder";
            var setting = new ExportSetting();
            setting.SettingName = "";
            setting.Description = "";
            setting.ExportFolderPath = testExportFolder;
            setting.fileNameFormat = filename;
            setting.ruleSetName = "";
            //setting null
            Assert.That(() => Exporter.Export(baseFolderPath, null, false), Throws.ArgumentNullException);
            //basefolder null
            Assert.That(() => Exporter.Export(null, setting, false), Throws.ArgumentNullException);
            //exportFolderPath empty
            setting.ExportFolderPath = "";
            Assert.That(() => Exporter.Export(null, setting, false), Throws.ArgumentNullException);
            //exportFolderPath does not start with `Assets`
            setting.ExportFolderPath = "InvalidPath/Export";
            Assert.That(() => Exporter.Export(null, setting, false), Throws.ArgumentNullException);
        }
        [Test]
        public void TestExportSettingValue()
        {
            var baseFolderPath = "Packages/com.vitdeck.core/Exporter/Tests/TestBaseFolder";
            var setting = new ExportSetting();
            setting.SettingName = "";
            setting.Description = "";
            setting.ExportFolderPath = testExportFolder;
            setting.fileNameFormat = null;
            setting.ruleSetName = "";
            var result = Exporter.Export(baseFolderPath, setting, true);
            Assert.That(result.exportResult, Is.True);
            Assert.That(result.exportFilePath, Is.EqualTo(testExportFolder+Path.AltDirectorySeparatorChar+"export.unitypackage"));
            Assert.That(File.Exists(result.exportFilePath));
        }

        [Test]
        public void TestGetExportSettings()
        {
            Assert.That(Exporter.GetExportSettings(), Is.Not.Null);
            Assert.That(Exporter.GetExportSettings().Length, Is.AtLeast(2));
            var firstSetting = Exporter.GetExportSettings().First();
            Assert.That(firstSetting.name, Is.Not.Null);
            Assert.That(firstSetting.SettingName, Is.Not.Null);
            Assert.That(firstSetting.Description, Is.Not.Null);
            Assert.That(firstSetting.ExportFolderPath, Is.Not.Null);
            Assert.That(firstSetting.fileNameFormat, Is.Not.Null);
            Assert.That(firstSetting.ruleSetName, Is.Not.Null);
            Assert.That(firstSetting.ignoreValidationWarning, Is.Not.Null);
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            if (Directory.Exists(testExportFolder))
                Directory.Delete(testExportFolder, true);
        }
    }
}