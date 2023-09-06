using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class StaticFlagRule : BaseRule
    {

        private const StaticEditorFlags mustFlag = StaticEditorFlags.OccludeeStatic | StaticEditorFlags.ReflectionProbeStatic;
        private const StaticEditorFlags shouldFlag = StaticEditorFlags.BatchingStatic;

        public StaticFlagRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootObjects = target.GetRootObjects();

            foreach(var rootObject in rootObjects)
            {
                LogicForDynamicObjects(new[] { rootObject });

                var staticRoot = rootObject.transform.Find("Static");
                if (staticRoot != null)
                {
                    LogicForStaticObjects(GetGameObjectsInChildren(staticRoot));
                }

                var dynamicRoot = rootObject.transform.Find("Dynamic");
                if (dynamicRoot != null)
                {
                    LogicForDynamicObjects(GetGameObjectsInChildren(dynamicRoot));
                }
            }
        }

        private IEnumerable<GameObject> GetGameObjectsInChildren(Transform transform)
        {
            return transform.GetComponentsInChildren<Transform>(includeInactive: true)
                .Select(t => t.gameObject);
        }

        private void LogicForStaticObjects(IEnumerable<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                var flag = GameObjectUtility.GetStaticEditorFlags(gameObject);

                if ((flag & StaticEditorFlags.OccludeeStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("StaticFlagRule.OccludeeStaticNotSet"),
                        LocalizedMessage.Get("StaticFlagRule.OccludeeStaticNotSet.Solution"),
                        resolver: () =>
                        {
                            GameObjectUtility.SetStaticEditorFlags(gameObject, flag | StaticEditorFlags.OccludeeStatic);
                            return ResolverResult.Resolved("StaticEditorFlags is set.");
                        }));
                }

                if ((flag & StaticEditorFlags.ReflectionProbeStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("StaticFlagRule.ReflectionProveStaticNotSet"),
                        LocalizedMessage.Get("StaticFlagRule.ReflectionProveStaticNotSet.Solution"),
                        resolver: () =>
                        {
                            GameObjectUtility.SetStaticEditorFlags(gameObject, flag | StaticEditorFlags.ReflectionProbeStatic);
                            return ResolverResult.Resolved("StaticEditorFlags is set.");
                        }));
                }

                if ((flag & StaticEditorFlags.BatchingStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Warning,
                        LocalizedMessage.Get("StaticFlagRule.BatchingStaticNotSet"),
                        LocalizedMessage.Get("StaticFlagRule.BatchingStaticNotSet.Solution"),
                        resolver: () =>
                        {
                            GameObjectUtility.SetStaticEditorFlags(gameObject, flag | StaticEditorFlags.BatchingStatic);
                            return ResolverResult.Resolved("StaticEditorFlags is set.");
                        }));
                }

                if ((flag & StaticEditorFlags.OccluderStatic) != 0)
                {
                    var message = LocalizedMessage.Get("StaticFlagRule.OccluderStaticNotAllowed");
                    var solution = LocalizedMessage.Get("StaticFlagRule.OccluderStaticNotAllowed.Solution");
                    var solutionURL = LocalizedMessage.Get("StaticFlagRule.OccluderStaticNotAllowed.SolutionURL");

                    ResolverResult Resolver()
                    {
                        GameObjectUtility.SetStaticEditorFlags(gameObject, flag & ~StaticEditorFlags.OccluderStatic);
                        return ResolverResult.Resolved("StaticEditorFlags is reset.");
                    }

                    AddIssue(new Issue(gameObject, IssueLevel.Error, message, solution, solutionURL, Resolver));
                }

                if ((flag & StaticEditorFlags.ContributeGI) != 0)
                {
                    foreach (var filter in gameObject.GetComponents<MeshFilter>())
                    {
                        if (filter == null)
                            continue;

                        var mesh = filter.sharedMesh;
                        if (mesh == null) // メッシュが設定されていない場合はチェック対象外
                            continue;

                        if (mesh.uv2.Length != 0) // uv2があればLightmapとして利用できる為問題なし
                            continue;

                        var assetPath = AssetDatabase.GetAssetPath(mesh);
                        if (string.IsNullOrWhiteSpace(assetPath)) // 対象のメッシュがアセットでない
                        {
                            AddIssueForIndependentMeshWithoutUV2(filter);
                            continue;
                        }

                        var importer = AssetImporter.GetAtPath(assetPath) as ModelImporter;
                        if (importer == null) // 対象のメッシュのimporterがない（モデルインポートでないメッシュアセット）
                        {
                            AddIssueForIndependentMeshWithoutUV2(filter);
                            continue;
                        }

                        if (!importer.generateSecondaryUV) // 対象のメッシュアセットのgenerateSecondaryUVが無効になっている
                        {
                            var message = LocalizedMessage.Get("StaticFlagRule.LightmapStaticMeshAssetShouldGenerateLightmap");
                            var solution = LocalizedMessage.Get("StaticFlagRule.LightmapStaticMeshAssetShouldGenerateLightmap.Solution");
                            var solutionURL = LocalizedMessage.Get("StaticFlagRule.LightmapStaticMeshAssetShouldGenerateLightmap.SolutionURL");

                            ResolverResult Resolver()
                            {
                                importer.generateSecondaryUV = true;
                                importer.SaveAndReimport();
                                return ResolverResult.Resolved("UV2 is generated.");
                            }

                            AddIssue(new Issue(filter, IssueLevel.Warning, message, solution, solutionURL, Resolver));
                        }
                    }
                }
            }
        }

        private void LogicForDynamicObjects(IEnumerable<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                var flag = GameObjectUtility.GetStaticEditorFlags(gameObject);

                if (flag != 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("StaticFlagRule.StaticNotAllowed"),
                        LocalizedMessage.Get("StaticFlagRule.StaticNotAllowed.Solution"),
                        resolver: () =>
                        {
                            GameObjectUtility.SetStaticEditorFlags(gameObject, 0);
                            return ResolverResult.Resolved("StaticEditorFlags is reset.");
                        }));
                }
            }
        }

        private void AddIssueForIndependentMeshWithoutUV2(MeshFilter filter)
        {
            var message = LocalizedMessage.Get("StaticFlagRule.LightmapStaticMeshShouldHaveUV2");
            var solution = LocalizedMessage.Get("StaticFlagRule.LightmapStaticMeshShouldHaveUV2.Solution");
            var solutionURL = LocalizedMessage.Get("StaticFlagRule.LightmapStaticMeshShouldHaveUV2.SolutionURL");
            
            ResolverResult Resolver()
            {
                var mesh = filter.sharedMesh;
                if (mesh == null) return ResolverResult.Failed("Mesh is null.");

                var assetPath = AssetDatabase.GetAssetPath(mesh);
                if (string.IsNullOrWhiteSpace(assetPath)) return ResolverResult.Failed("AssetPath is null or empty.");

                var importer = AssetImporter.GetAtPath(assetPath) as ModelImporter;
                if (importer == null) return ResolverResult.Failed("ModelImporter is null.");

                importer.generateSecondaryUV = true;
                importer.SaveAndReimport();
                return ResolverResult.Resolved("UV2 is generated.");
            }
            
            AddIssue(new Issue(filter, IssueLevel.Warning, message, solution, solutionURL, Resolver));
        }
    }
}