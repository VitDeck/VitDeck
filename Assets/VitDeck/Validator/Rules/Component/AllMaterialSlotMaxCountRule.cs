using System.Linq;
using UnityEngine;

namespace VitDeck.Validator
{
    /// <summary>
    /// すべての<see cref="SkinnedMeshRenderer"/>、<see cref="MeshRenderer"/>の、マテリアルスロットの合計数を制限します。
    /// </summary>
	public class AllMaterialSlotMaxCountRule : BaseRule
    {
        private readonly int limit;

        public AllMaterialSlotMaxCountRule(string name, int limit) : base(name)
        {
            this.limit = limit;
        }

		protected override void Logic(ValidationTarget target)
		{
			var renderers = target
				.GetAllObjects()
				.SelectMany(x => x.GetComponents<Renderer>());

            var count = renderers.Sum(renderer => renderer.sharedMaterials.Length);

			if (count > limit)
			{
                var message = string.Format("すべてのSkinnedMeshRenderer、MeshRendererコンポーネントの、マテリアルスロットの合計が{0}です。", count);
                var solution = string.Format("{0}以下になるよう減らしてください。", limit);

                foreach (var renderer in renderers)
				{
                    AddIssue(new Issue(renderer, IssueLevel.Error, message, solution));
				}
			}
		}
	}
}
