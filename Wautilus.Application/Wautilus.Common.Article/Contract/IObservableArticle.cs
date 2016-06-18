using System;

namespace Wautilus.Common.Article
{

	public interface IObservableArticle : IArticle
	{

		bool IsObservationEnabled { get; set; }

		event EventHandler<MovedArticleEventArgs> Moved;

	}

}
