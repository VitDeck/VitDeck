using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VitDeck.Validator.Test
{
    /// <summary>
    /// PrefabLimitRuleが入れ子になったPrefabインスタンスも数えることを検証する。
    /// </summary>
    public class TestPrefabLimitRuleNested
    {
        private const string TempFolderPath = "Assets/VitDeckPrefabLimitRuleNestedTemp";
        private string innerPrefabPath;
        private string innerPrefabGuid;
        private string outerPrefabPath;

        [SetUp]
        public void SetUp()
        {
            if (!AssetDatabase.IsValidFolder(TempFolderPath))
            {
                AssetDatabase.CreateFolder("Assets", "VitDeckPrefabLimitRuleNestedTemp");
            }

            // 内側のPrefab(カウント対象)
            var inner = new GameObject("Inner");
            innerPrefabPath = TempFolderPath + "/Inner.prefab";
            PrefabUtility.SaveAsPrefabAsset(inner, innerPrefabPath);
            Object.DestroyImmediate(inner);
            innerPrefabGuid = AssetDatabase.AssetPathToGUID(innerPrefabPath);

            // 外側のPrefab(内側のPrefabインスタンスを1つ含む)
            var innerAsset = AssetDatabase.LoadAssetAtPath<GameObject>(innerPrefabPath);
            var outer = new GameObject("Outer");
            var nested = (GameObject)PrefabUtility.InstantiatePrefab(innerAsset);
            nested.transform.SetParent(outer.transform);
            outerPrefabPath = TempFolderPath + "/Outer.prefab";
            PrefabUtility.SaveAsPrefabAsset(outer, outerPrefabPath);
            Object.DestroyImmediate(outer);

            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        }

        [TearDown]
        public void TearDown()
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            AssetDatabase.DeleteAsset(TempFolderPath);
        }

        private ValidationTarget BuildTarget(int outerCount, int directInnerCount)
        {
            var innerAsset = AssetDatabase.LoadAssetAtPath<GameObject>(innerPrefabPath);
            var outerAsset = AssetDatabase.LoadAssetAtPath<GameObject>(outerPrefabPath);
            var roots = new List<GameObject>();
            for (var i = 0; i < outerCount; i++)
            {
                roots.Add((GameObject)PrefabUtility.InstantiatePrefab(outerAsset));
            }
            for (var i = 0; i < directInnerCount; i++)
            {
                roots.Add((GameObject)PrefabUtility.InstantiatePrefab(innerAsset));
            }

            var allObjects = roots
                .SelectMany(root => root.GetComponentsInChildren<Transform>(true))
                .Select(t => t.gameObject)
                .ToArray();

            return new ValidationTarget(TempFolderPath,
                scenes: new[] { SceneManager.GetActiveScene() },
                rootObjects: roots.ToArray(),
                allObjects: allObjects);
        }

        [Test]
        public void NestedInstancesAreCounted_OverLimit()
        {
            // Outer x3(それぞれInnerを1つ内包) + Inner x1 = Inner 4個
            var target = BuildTarget(outerCount: 3, directInnerCount: 1);
            var rule = new PrefabLimitRule("", new[] { innerPrefabGuid }, 3);

            var result = rule.Validate(target);

            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
        }

        [Test]
        public void NestedInstancesAreCounted_UnderLimit()
        {
            var target = BuildTarget(outerCount: 3, directInnerCount: 1);
            var rule = new PrefabLimitRule("", new[] { innerPrefabGuid }, 4);

            var result = rule.Validate(target);

            Assert.That(result.Issues.Count, Is.Zero);
        }

        [Test]
        public void OnlyNestedInstances_OverLimit()
        {
            // 直接配置がなく、全て入れ子経由のケース
            var target = BuildTarget(outerCount: 2, directInnerCount: 0);
            var rule = new PrefabLimitRule("", new[] { innerPrefabGuid }, 1);

            var result = rule.Validate(target);

            Assert.That(result.Issues.Count, Is.EqualTo(1));
        }

        [Test]
        public void OuterPrefabIsCountedOncePerInstance()
        {
            // 外側Prefabを対象にした場合、内側の子オブジェクトで二重カウントされない
            var outerGuid = AssetDatabase.AssetPathToGUID(outerPrefabPath);
            var target = BuildTarget(outerCount: 2, directInnerCount: 0);
            var rule = new PrefabLimitRule("", new[] { outerGuid }, 2);

            var result = rule.Validate(target);

            Assert.That(result.Issues.Count, Is.Zero);
        }
    }
}
