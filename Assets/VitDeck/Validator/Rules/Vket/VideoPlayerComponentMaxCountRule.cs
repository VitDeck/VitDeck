using System.Linq;
using UnityEngine.Video;
using VitDeck.Language;

namespace VitDeck.Validator
{
	public class VideoPlayerComponentMaxCountRule : BaseRule
	{
		private int limit;

		public VideoPlayerComponentMaxCountRule(string name, int limit) : base(name)
		{
			this.limit = limit;
		}

		protected override void Logic(ValidationTarget target)
		{
			var allObjects = target.GetAllObjects();
			var videoPlayerObjects = target
				.GetAllObjects()
				.Where(x => x.GetComponent<VideoPlayer>() != null);

			var videoPlayerCount = videoPlayerObjects.Count();

			if (videoPlayerCount > limit)
			{
				var message = LocalizedMessage.Get("VideoPlayerComponentMaxCountRule.Exceeded", limit, videoPlayerCount);
				var solution = LocalizedMessage.Get("VideoPlayerComponentMaxCountRule.Exceeded.Solution");

				foreach (var videoPlayerObject in videoPlayerObjects)
				{
					AddIssue(new Issue(
						videoPlayerObject,
						IssueLevel.Error,
						message,
						solution));
				}
			}
		}
	}
}