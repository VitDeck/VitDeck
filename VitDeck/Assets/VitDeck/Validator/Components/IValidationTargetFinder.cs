using UnityEngine;
using UnityEngine.SceneManagement;

namespace VitDeck.Validator
{
    public interface IValidationTargetFinder
    {
        ValidationTarget Find(string baseFolder);
        GameObject[] FindAllObjects(string baseFolderPath);
        string[] FindAssetGuids(string baseFolderPath);
        Object[] FindAssetObjects(string baseFolderPath);
        string[] FindAssetPaths(string baseFolderPath);
        GameObject[] FindRootObjects(string baseFolderPath);
        Scene[] FindScenes(string baseFolderPath);
    }
}