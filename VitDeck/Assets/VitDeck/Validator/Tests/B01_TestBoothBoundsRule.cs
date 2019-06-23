using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace VitDeck.Validator.Test
{
    public class B01_TestBoothBoundsRule
    {
        ValidationTarget targetContainer;

        [SetUp]
        public void SetUp()
        {
            var targetObjects = new GameObject[]
            {
                CreateSimpleGameObject("TestTargetObject0", true, Vector3.zero),
                CreateSimpleGameObject("TestTargetObject1", true, new Vector3(1, 0, 0)),
                CreateSimpleGameObject("TestTargetObject2", false, new Vector3(1000, 0, 0)),
                CreateRendererGameObject("TestTargetObject3", true, new Vector3(0, 1, 0), new Vector3(2, 2, 2)),
                CreateRendererGameObject("TestTargetObject4", false, new Vector3(0, 100, 0), new Vector3(200, 200, 200)),
                CreateRectGameObject("TestTargetObject5", true, new Vector3(0, 1, 0), new Vector2(2, 2) ),
                CreateRectGameObject("TestTargetObject6", false, new Vector3(0, 1, 0), new Vector2(2, 2) ),
            };

            targetContainer = new ValidationTarget("Assets/VitDeck/Validator/Tests", allObjects: targetObjects);
        }

        public static readonly object[] TestCases =
        {
            CreateTestCase( "TestRule0", Vector3.zero, new Vector3(3, 5, 4), 0f, FailedTargetObjectIndices(null) ),
            CreateTestCase( "TestRule1", Vector3.zero, new Vector3(2, 5, 4), 0f, FailedTargetObjectIndices(null) ),
            CreateTestCase( "TestRule2", Vector3.zero, new Vector3(1.9f, 5, 4), 0f, FailedTargetObjectIndices(1, 3, 5) ),
            CreateTestCase( "TestRule3", Vector3.zero, new Vector3(1.9f, 5, 4), 0.1f, FailedTargetObjectIndices(null) ),
        };

        [TestCaseSource("TestCases")]
        public void TestValidation(string ruleName, Vector3 pivot, Vector3 size, float margin, int[] willFailedTargetIndices)
        {
            var rule = new BoothBoundsRule(ruleName, size, margin, pivot);

            var result = rule.Validate(targetContainer);

            if (willFailedTargetIndices.Length == 0)
            {
                Assert.That(result.Issues.Count, Is.Zero);
            }
            else
            {
                Assert.That(result.Issues.Count, Is.GreaterThanOrEqualTo(willFailedTargetIndices.Length));

                var targets = targetContainer.GetAllObjects();

                foreach (var targetIndex in willFailedTargetIndices)
                {
                    var targetObject = targets[targetIndex];
                    var issue = result.Issues.Find(i => ((Component)i.target).gameObject == targetObject);

                    Assert.That(issue, Is.Not.Null);
                    Assert.That(issue.level, Is.EqualTo(IssueLevel.Error));
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var gameObject in targetContainer.GetAllObjects())
            {
                Object.DestroyImmediate(gameObject);
            }
            targetContainer = null;
        }

        #region Utils

        public static GameObject CreateSimpleGameObject(string name, bool isActive, Vector3 position)
        {
            var gameObject = new GameObject(name);
            gameObject.SetActive(isActive);
            gameObject.transform.position = position;

            return gameObject;
        }

        public static GameObject CreateRendererGameObject(string name, bool isActive, Vector3 position, Vector3 meshSize)
        {
            var mesh = new Mesh();
            mesh.bounds = new Bounds(Vector3.zero, meshSize);

            var gameObject = CreateSimpleGameObject(name, isActive, position);
            gameObject.AddComponent<MeshRenderer>();
            gameObject.AddComponent<MeshFilter>().mesh = mesh;

            return gameObject;
        }

        public static GameObject CreateRectGameObject(string name, bool isActive, Vector3 position, Vector2 size)
        {
            var gameObject = CreateSimpleGameObject(name, isActive, position);
            var transform = gameObject.AddComponent<RectTransform>();
            transform.sizeDelta = size;

            return gameObject;
        }

        public static int[] FailedTargetObjectIndices(params int[] failedTargets)
        {
            return failedTargets ?? new int[] { };
        }

        public static object[] CreateTestCase(string ruleName, Vector3 pivot, Vector3 size, float margin, int[] failedTargets)
        {
            return new object[] { ruleName, pivot, size, margin, failedTargets };
        }

        #endregion
    }
}