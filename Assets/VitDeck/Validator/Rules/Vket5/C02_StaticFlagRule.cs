using UnityEngine;
using UnityEditor;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class C02_StaticFlagRule : BaseRule
    {

        private const StaticEditorFlags mustFlag = StaticEditorFlags.OccludeeStatic | StaticEditorFlags.ReflectionProbeStatic;
        private const StaticEditorFlags shouldFlag = StaticEditorFlags.BatchingStatic;

        public C02_StaticFlagRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootObjects = target.GetRootObjects();

            foreach(var rootObject in rootObjects)
            {
                var staticRoot = rootObject.transform.Find("Static");
                if (staticRoot == null)
                {
                    continue;
                }

                LogicForStaticRoot(staticRoot);
            }
        }

        private void LogicForStaticRoot(Transform staticRoot)
        {
            var children = staticRoot.GetComponentsInChildren<Transform>(true);

            foreach(var child in children)
            {
                var gameObject = child.gameObject;
                var flag = GameObjectUtility.GetStaticEditorFlags(child.gameObject);

                if((flag & StaticEditorFlags.OccludeeStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("C02_StaticFlagRule.OccludeeStaticNotSet"),
                        LocalizedMessage.Get("C02_StaticFlagRule.OccludeeStaticNotSet.Solution")));
                }

                if ((flag & StaticEditorFlags.ReflectionProbeStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("C02_StaticFlagRule.ReflectionProveStaticNotSet"),
                        LocalizedMessage.Get("C02_StaticFlagRule.ReflectionProveStaticNotSet.Solution")));
                }

                if ((flag & StaticEditorFlags.BatchingStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Warning,
                        LocalizedMessage.Get("C02_StaticFlagRule.BatchingStaticNotSet"),
                        LocalizedMessage.Get("C02_StaticFlagRule.BatchingStaticNotSet.Solution")));
                }
                
                if ((flag & StaticEditorFlags.OccluderStatic) != 0)
                {
                    var message = LocalizedMessage.Get("C02_StaticFlagRule.OccluderStaticNotAllowed");
                    var solution = LocalizedMessage.Get("C02_StaticFlagRule.OccluderStaticNotAllowed.Solution");
                    var solutionURL = LocalizedMessage.Get("C02_StaticFlagRule.OccluderStaticNotAllowed.SolutionURL");
                    
                    AddIssue(new Issue(gameObject, IssueLevel.Error, message, solution, solutionURL));
                }

                if ((flag & StaticEditorFlags.LightmapStatic) != 0)
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
                            var message = LocalizedMessage.Get("C02_StaticFlagRule.LightmapStaticMeshAssetShouldGenerateLightmap");
                            var solution = LocalizedMessage.Get("C02_StaticFlagRule.LightmapStaticMeshAssetShouldGenerateLightmap.Solution");
                            var solutionURL = LocalizedMessage.Get("C02_StaticFlagRule.LightmapStaticMeshAssetShouldGenerateLightmap.SolutionURL");
                        
                            AddIssue(new Issue(filter, IssueLevel.Error, message, solution, solutionURL));
                        }
                    }
                }
            }
        }

        private void AddIssueForIndependentMeshWithoutUV2(MeshFilter filter)
        {
            var message = LocalizedMessage.Get("C02_StaticFlagRule.LightmapStaticMeshShouldHaveUV2");
            var solution = LocalizedMessage.Get("C02_StaticFlagRule.LightmapStaticMeshShouldHaveUV2.Solution");
            var solutionURL = LocalizedMessage.Get("C02_StaticFlagRule.LightmapStaticMeshShouldHaveUV2.SolutionURL");

            AddIssue(new Issue(filter, IssueLevel.Error, message, solution, solutionURL));
        }
    }
}