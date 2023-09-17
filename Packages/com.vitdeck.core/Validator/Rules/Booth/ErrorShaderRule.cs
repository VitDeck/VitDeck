using UnityEngine;
using System.Linq;

namespace VitDeck.Validator
{
    /// <summary>
    /// エラーシェーダーの検出ルール
    /// </summary>
    /// <remarks>シェーダーエラーの存在するオブジェクトを検出する。</remarks>
    public class ErrorShaderRule : BaseRule
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="name">ルール名</param>
        public ErrorShaderRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            foreach (var obj in target.GetAllObjects())
            {
                if (obj.GetComponent<Renderer>() == null)
                    continue;

                var materials = obj.GetComponent<Renderer>().sharedMaterials;

                foreach (var material in materials)
                {
                    if (material == null)
                    {
                        AddIssue(new Issue(obj, IssueLevel.Info, "オブジェクトのRendererにマテリアルの参照がありません。", string.Empty,
                            string.Empty));
                        continue;
                    }

                    if (material.shader.name == "Hidden/InternalErrorShader")
                    {
                        AddIssue(new Issue(obj, IssueLevel.Error, "オブジェクトのマテリアルで正しいシェーダーが参照されていません。", string.Empty,
                            string.Empty));
                        continue;
                    }

                    if (material.shader.name == string.Empty || material.shader.name == null)
                    {
                        AddIssue(new Issue(obj, IssueLevel.Error, "オブジェクトでシェーダーエラーが検出されました。", string.Empty,
                            string.Empty));
                    }
                }
            }
        }
    }
}
