using System.Linq;
using UnityEditor;

namespace VitDeck.Validator
{
    /// <summary>
    /// アセット内のモデルで、MaterialsのLocationがUse Embedded Materialsになっていることを確認する。
    /// </summary>
    public class EmbeddedMaterialsRule : BaseRule
    {
        public EmbeddedMaterialsRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var pathPrefix = target.GetBaseFolderPath() + "/";
            var paths = target.GetAllAssetPaths().Where(path => path.StartsWith(pathPrefix)).Distinct();
            foreach (var path in paths)
            {
                LogicForPath(path);
            }
        }

        private void LogicForPath(string path)
        {
            var importer = AssetImporter.GetAtPath(path) as ModelImporter;
            if (importer == null
                || importer.materialLocation != ModelImporterMaterialLocation.External)
            {
                return;
            }
            UnityEngine.Debug.Log(path);

            AddIssue(new Issue(
                AssetDatabase.LoadMainAssetAtPath(path),
                IssueLevel.Error,
                "モデルのマテリアルがUse Embedded Materialsになっていません。",
                "モデルを選択した状態で、MaterialsタブのLocationから「Use Embedded Materials」を選択し、「Apply」してください。"));
        }
    }
}
