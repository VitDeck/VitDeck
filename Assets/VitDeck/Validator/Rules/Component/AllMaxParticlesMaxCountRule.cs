using System.Linq;
using UnityEngine;

namespace VitDeck.Validator
{
    /// <summary>
    /// すべての<see cref="ParticleSystem"/>の、Max Particlesの合計値を制限します。
    /// </summary>
	public class AllMaxParticlesMaxCountRule : BaseRule
    {
        private readonly int limit;

        public AllMaxParticlesMaxCountRule(string name, int limit) : base(name)
        {
            this.limit = limit;
        }

		protected override void Logic(ValidationTarget target)
		{
			var particleSystems = target
				.GetAllObjects()
				.SelectMany(x => x.GetComponents<ParticleSystem>());

            var count = particleSystems.Sum(particleSystem => particleSystem.main.maxParticles);

			if (count > limit)
			{
                var message = string.Format("すべてのParticle Systemコンポーネントの、Max Particlesの合計値が{0}です。", count);
                var solution = string.Format("{0}以下になるよう減らしてください。", limit);

                foreach (var particleSystem in particleSystems)
				{
                    AddIssue(new Issue(particleSystem, IssueLevel.Error, message, solution));
				}
			}
		}
	}
}
