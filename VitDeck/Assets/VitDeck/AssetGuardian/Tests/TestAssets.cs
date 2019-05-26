#pragma warning disable SA1402 // FileMayOnlyContainASingleType
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian.Tests
{
    public interface ITestAsset : IDisposable
    {
        string Path { get; }
        UnityEngine.Object Instance { get; }
    }

    public abstract class TestAsset : ITestAsset
    {
        public string Path { get; protected set; }

        public UnityEngine.Object Instance { get; protected set; }

        protected string GeneratePath(string parentPath, string defaultName)
        {
            return AssetDatabase.GenerateUniqueAssetPath(System.IO.Path.Combine(parentPath, defaultName));
        }

        public virtual void Dispose()
        {
            AssetDatabase.DeleteAsset(Path);
        }
    }

    public class TestFolderAsset : TestAsset
    {
        public TestFolderAsset()
        {
            var guid = AssetDatabase.CreateFolder("Assets", "TestFolder");
            Path = AssetDatabase.GUIDToAssetPath(guid);
            Instance = AssetDatabase.LoadAssetAtPath<DefaultAsset>(Path);
        }
    }

    public class TestScriptableObjectAsset : TestAsset
    {
        public TestScriptableObjectAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestScriptableObject.asset");
            Instance = ScriptableObject.CreateInstance<TestScriptableObject>();
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestMaterialAsset : TestAsset
    {
        public TestMaterialAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestMaterial.material");
            Instance = new Material(Shader.Find("Specular"));
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }
}
#pragma warning restore SA1402 // FileMayOnlyContainASingleType