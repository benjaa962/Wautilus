using System;

namespace Wautilus.Common.Article
{

	public interface IObservableParentArticle : IParentArticle, IObservableArticle
	{

		event EventHandler<ChildrenModifiedArticleEventArgs> ChildrenModified;

	}

}
