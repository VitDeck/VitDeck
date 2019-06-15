using UnityEngine;
using UnityEngine.SceneManagement;

namespace VitDeck.Validator
{
    public interface IValidationTargetFinder
    {
        ValidationTarget Find(string baseFolder, bool forceOpenScene = false);
        GameObject[] FindAllObjects(string baseFolderPath, bool forceOpenScene = false);
        string[] FindAssetGuids(string baseFolderPath);
        Object[] FindAssetObjects(string baseFolderPath);
        string[] FindAssetPaths(string baseFolderPath);
        GameObject[] FindRootObjects(string baseFolderPath,bool forceOpenScene = false);
        Scene[] FindScenes(string baseFolderPath,bool forceOpenScene = false);
    }
}