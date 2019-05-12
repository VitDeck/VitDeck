using NUnit.Framework;

namespace VitDeck.TemplateLoader.Test
{
    public class TemplateLoaderTest
    {
        [Test]
        public void TestGetTemplateFolders()
        {
            Assert.That(TemplateLoader.GetTemplateFolders().Length, Is.EqualTo(1));
            Assert.That(TemplateLoader.GetTemplateFolders()[0], Is.EqualTo("Sample_template"));
        }
    }
}
