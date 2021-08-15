using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace VitDeck.Validator
{
    /// <summary>
    /// 使用可能なシェーダーをホワイトリスト検証します。
    /// </summary>
    public class ShaderWhitelistRule : BaseRule
    {
        private readonly IDictionary<string, string> shaderNameGUIDPairs;
        private readonly string solution;
        private readonly string solutionURL;

        /// <param name="name">ルール名</param>
        /// <param name="shaderNameGUIDPairs">キーにシェーダー名、値にシェーダーのGUIDを持つ連想配列。ビルトインシェーダーは常に許可。</param>
        public ShaderWhitelistRule(
            string name,
            IDictionary<string, string> shaderNameGUIDPairs,
            string solution = "",
            string solutionURL = ""
        ) : base(name)
        {
            this.shaderNameGUIDPairs = shaderNameGUIDPairs;
            this.solution = solution;
            this.solutionURL = solutionURL;
        }

        protected override void Logic(ValidationTarget target)
        {
            foreach (var gameObject in target.GetAllObjects())
            {
                foreach (var shader in this.GetShaders(gameObject))
                {
                    if (shader.name == "Hidden/InternalErrorShader") {
                        continue;
                    }

                    var path = AssetDatabase.GetAssetPath(Shader.Find(shader.name));
                    if (path == "Resources/unity_builtin_extra")
                    {
                        continue;
                    }

                    if (!this.shaderNameGUIDPairs.ContainsKey(shader.name))
                    {
                        this.AddIssue(new Issue(
                            gameObject,
                            IssueLevel.Error,
                            string.Format("シェーダー「{0}」の使用は許可されていません。", shader.name),
                            solution,
                            solutionURL
                        ));
                        continue;
                    }

                    var guid = AssetDatabase.AssetPathToGUID(path);
                    if (guid != this.shaderNameGUIDPairs[shader.name])
                    {
                        this.AddIssue(new Issue(gameObject, IssueLevel.Error, string.Format(
                            "シェーダー「{0}」のGUID「{1}」が「{2}」と一致しません。",
                            shader.name,
                            guid,
                            this.shaderNameGUIDPairs[shader.name]
                        ), solution, solutionURL));
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 指定されたオブジェクトが参照するシェーダーを取得します。
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        private IEnumerable<Shader> GetShaders(GameObject gameObject)
        {
            return gameObject.GetComponents<Renderer>()
                .SelectMany(renderer => renderer.sharedMaterials)
                .Where(material => material)
                .Select(material => material.shader);
        }
    }
}
