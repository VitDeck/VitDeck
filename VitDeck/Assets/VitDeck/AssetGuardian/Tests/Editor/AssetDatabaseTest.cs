using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class AssetDatabaseTest
{

    [Test]
    public void AssetDatabaseTestSimplePasses()
    {
        var assets = AssetDatabase.GetSubFolders("Assets");
        foreach (var asset in assets)
        {
            Debug.Log(asset);
        }
    }
}
