using System;

namespace Wautilus.Common.Article
{

	public interface IObservableArticle : IArticle
	{

		bool IsObservationEnabled { get; set; }

		event EventHandler<ArticleEventArgs>      Changed;
		event EventHandler<MovedArticleEventArgs> Moved  ;

	}

}
