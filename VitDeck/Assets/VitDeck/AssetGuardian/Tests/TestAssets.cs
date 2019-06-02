#pragma warning disable SA1402 // FileMayOnlyContainASingleType
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Linq;
using UnityEditor.Animations;

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

        [MenuItem("Assets/Create/CreateAllTestAssets")]
        private static void CreateAllTestAssets()
        {
            var baseObj = Selection.activeContext;
            var basePath = AssetDatabase.GetAssetPath(baseObj);
            var folder = System.IO.Path.GetDirectoryName(basePath);

            var assets = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(TestAsset)))
                .Select(type => (TestAsset)Activator.CreateInstance(type, folder));

            foreach (var asset in assets)
            {
                Debug.Log("Create " + asset.Instance);
            }
        }
    }

    public class TestFolderAsset : TestAsset
    {
        public TestFolderAsset(string parentPath = "Assets")
        {
            var guid = AssetDatabase.CreateFolder(parentPath, "TestFolder");
            Path = AssetDatabase.GUIDToAssetPath(guid);
            Instance = AssetDatabase.LoadAssetAtPath<DefaultAsset>(Path);
        }

        public override void Dispose()
        {
            base.Dispose();

            // Shaderをフォルダ内に含む場合、フォルダの削除が行われない場合があるので二回削除する。
            base.Dispose();
        }
    }

    public class TestPrefabAsset : TestAsset
    {
        public TestPrefabAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestPrefab.prefab");

            var rootGameObject = new GameObject("root");

            var childGameObject = new GameObject("child");
            childGameObject.transform.SetParent(rootGameObject.transform);

            var grandChildGameObject = new GameObject("grandChild");
            grandChildGameObject.transform.SetParent(childGameObject.transform);

            var grandChildCanvasGameObject = new GameObject("grandChildCanvas",
                typeof(RectTransform),
                typeof(Canvas),
                typeof(UnityEngine.UI.CanvasScaler),
                typeof(UnityEngine.UI.GraphicRaycaster));
            grandChildCanvasGameObject.transform.SetParent(childGameObject.transform);

            Instance = PrefabUtility.CreatePrefab(Path, rootGameObject);
        }
    }

    public class TestAnimationClipAsset : TestAsset
    {
        public TestAnimationClipAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestAnimationClip.anim");
            Instance = new AnimationClip();
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestAnimationOverrideControllerAsset : TestAsset
    {
        public TestAnimationOverrideControllerAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestAnimatorOverrideController.overrideController");
            Instance = new AnimatorOverrideController();
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestAudioClipAsset : TestAsset
    {
        public TestAudioClipAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestAudioClip.mp3");
            TestDataBinary.WriteAudio(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<AudioClip>(Path);
        }
    }

    public class TestModelAsset : TestAsset
    {
        public TestModelAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestModel.fbx");
            TestDataBinary.WriteFbx(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<GameObject>(Path);
        }
    }

    public class TestLightMapDataAsset : TestAsset
    {
        public TestLightMapDataAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestLightMapAsset.asset");
            TestDataBinary.WriteLightingData(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<LightingDataAsset>(Path);
        }
    }

    public class TestMaterialAsset : TestAsset
    {
        public TestMaterialAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestMaterial.mat");
            Instance = new Material(Shader.Find("Specular"));
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestMeshAsset : TestAsset
    {
        public TestMeshAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestMesh.obj");
            TestDataBinary.WriteObj(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<GameObject>(Path);
        }
    }

    //public class TestMonoBehaviourAsset : TestAsset
    //{
    //    public TestMonoBehaviourAsset(string parentPath)
    //    {
    //        Path = GeneratePath(parentPath, "TestMonoBehaviourAsset.cs");
    //        System.IO.File.WriteAllText(Path, "// This is a test file.\nusing System;");
    //        AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
    //        Instance = AssetDatabase.LoadAssetAtPath<MonoScript>(Path);
    //    }
    //}

    public class TestReflectionProbeAsset : TestAsset
    {
        public TestReflectionProbeAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestReflectionProbe.exr");
            TestDataBinary.WriteCubeMap(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<Cubemap>(Path);
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

    public class TestShaderAsset : TestAsset
    {
        public TestShaderAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestShader.shader");
            TestDataBinary.WriteShader(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<Shader>(Path);
        }
    }

    public class TestSkyboxAsset : TestAsset
    {
        public TestSkyboxAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestSkybox.mat");
            Instance = new Material(Shader.Find("Specular"));
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestSpriteAsset : TestAsset
    {
        public TestSpriteAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestSprite.png");
            TestDataBinary.WriteSprite(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<Sprite>(Path);
        }
    }

    public class TestTextAsset : TestAsset
    {
        public TestTextAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestTextAsset.txt");
            TestDataBinary.WriteText(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<TextAsset>(Path);
        }
    }

    public class TestTextureAsset : TestAsset
    {
        public TestTextureAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestTexture.png");
            TestDataBinary.WriteImage(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<Texture>(Path);
        }
    }

    public class TestAnimatiorControllerAsset : TestAsset
    {
        public TestAnimatiorControllerAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestAnimatiorController.controller");
            Instance = new AnimatorController();
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestSceneAsset : TestAsset
    {
        public TestSceneAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestScene.unity");
            TestDataBinary.WriteScene(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(Path);
        }
    }

}
#pragma warning restore SA1402 // FileMayOnlyContainASingleType