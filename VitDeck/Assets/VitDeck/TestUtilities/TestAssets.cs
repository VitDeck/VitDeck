#pragma warning disable SA1402 // FileMayOnlyContainASingleType
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Linq;
using UnityEditor.Animations;

namespace VitDeck.TestUtilities
{
    public interface ITestAsset : IDisposable
    {
        string Path { get; }
        UnityEngine.Object Instance { get; }
    }

    public abstract class TestAsset<T> : ITestAsset where T : UnityEngine.Object
    {
        public string Path { get; protected set; }

        public T Instance { get; protected set; }

        UnityEngine.Object ITestAsset.Instance
        {
            get { return Instance; }
        }

        protected string GeneratePath(string parentPath, string defaultName)
        {
            return AssetDatabase.GenerateUniqueAssetPath(System.IO.Path.Combine(parentPath, defaultName));
        }

        public virtual void Dispose()
        {
            AssetDatabase.DeleteAsset(Path);
        }
    }

    public class TestFolderAsset : TestAsset<DefaultAsset>
    {
        public TestFolderAsset(string parentPath = "Assets")
        {
            var guid = AssetDatabase.CreateFolder(parentPath, "TestFolder");
            Path = AssetDatabase.GUIDToAssetPath(guid);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as DefaultAsset;
        }

        public override void Dispose()
        {
            base.Dispose();

            // Shaderをフォルダ内に含む場合、フォルダの削除が行われない場合があるので二回削除する。
            base.Dispose();
        }
    }

    public class TestPrefabAsset : TestAsset<GameObject>
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

    public class TestAnimationClipAsset : TestAsset<AnimationClip>
    {
        public TestAnimationClipAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestAnimationClip.anim");
            Instance = new AnimationClip();
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestAnimationOverrideControllerAsset : TestAsset<AnimatorOverrideController>
    {
        public TestAnimationOverrideControllerAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestAnimatorOverrideController.overrideController");
            Instance = new AnimatorOverrideController();
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestAudioClipAsset : TestAsset<AudioClip>
    {
        public TestAudioClipAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestAudioClip.mp3");
            TestDataBinary.WriteAudio(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as AudioClip;
        }
    }

    public class TestModelAsset : TestAsset<GameObject>
    {
        public TestModelAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestModel.fbx");
            TestDataBinary.WriteFbx(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as GameObject;
        }
    }

    public class TestLightMapDataAsset : TestAsset<LightingDataAsset>
    {
        public TestLightMapDataAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestLightMapAsset.asset");
            TestDataBinary.WriteLightingData(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as LightingDataAsset;
        }
    }

    public class TestMaterialAsset : TestAsset<Material>
    {
        public TestMaterialAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestMaterial.mat");
            Instance = new Material(Shader.Find("Specular"));
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestMeshAsset : TestAsset<GameObject>
    {
        public TestMeshAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestMesh.obj");
            TestDataBinary.WriteObj(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as GameObject;
        }
    }

    public class TestReflectionProbeAsset : TestAsset<Cubemap>
    {
        public TestReflectionProbeAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestReflectionProbe.exr");
            TestDataBinary.WriteCubeMap(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as Cubemap;
        }
    }

    public class TestScriptableObjectAsset<T> : TestAsset<T>
        where T : ScriptableObject
    {
        public TestScriptableObjectAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestScriptableObject.asset");
            Instance = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestShaderAsset : TestAsset<Shader>
    {
        public TestShaderAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestShader.shader");
            TestDataBinary.WriteShader(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as Shader;
        }
    }

    public class TestSkyboxAsset : TestAsset<Material>
    {
        public TestSkyboxAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestSkybox.mat");
            Instance = new Material(Shader.Find("Specular"));
            AssetDatabase.CreateAsset(Instance, Path);
        }
    }

    public class TestSpriteAsset : TestAsset<Sprite>
    {
        public TestSpriteAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestSprite.png");
            TestDataBinary.WriteSprite(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadAssetAtPath<Sprite>(Path);
        }
    }

    public class TestTextAsset : TestAsset<TextAsset>
    {
        public TestTextAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestTextAsset.txt");
            TestDataBinary.WriteText(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as TextAsset;
        }
    }

    public class TestTextureAsset : TestAsset<Texture>
    {
        public TestTextureAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestTexture.png");
            TestDataBinary.WriteImage(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as Texture;
        }
    }

    public class TestAnimatiorControllerAsset : TestAsset<AnimatorController>
    {
        public TestAnimatiorControllerAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestAnimatiorController.controller");
            TestDataBinary.WriteAnimatorController(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as AnimatorController;
        }
    }

    public class TestSceneAsset : TestAsset<SceneAsset>
    {
        public TestSceneAsset(string parentPath)
        {
            Path = GeneratePath(parentPath, "TestScene.unity");
            TestDataBinary.WriteScene(Path);
            AssetDatabase.ImportAsset(Path, ImportAssetOptions.ForceSynchronousImport);
            Instance = AssetDatabase.LoadMainAssetAtPath(Path) as SceneAsset;
        }
    }

}
#pragma warning restore SA1402 // FileMayOnlyContainASingleType