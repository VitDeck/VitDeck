using UnityEditor;

namespace VitDeck.Validator.Test
{
    public static class ValidatorTestUtilities
    {
        private const string TestDirectoryGuid = "bd1301153fbb80c438fa49a43a95def8";
        public static string TestDirectoryPath => AssetDatabase.GUIDToAssetPath(TestDirectoryGuid);
        private const string TestDataDirectoryGuid = "52ceae726485ef84c95fddf9d8b2dea8";
        public static string DataDirectoryPath => AssetDatabase.GUIDToAssetPath(TestDataDirectoryGuid);
    }
}