using System.Collections.Generic;

namespace Wautilus.Common.Article
{

	public class ChildrenModifiedArticleEventArgs : ArticleEventArgs
	{
		
		#region constructor

		public ChildrenModifiedArticleEventArgs (IArticle article, IEnumerable<IArticle> addedChildren, IEnumerable<IArticle> removedChildren) : base(article)
		{
			AddedChildren   = addedChildren  ;
			RemovedChildren = removedChildren;
		}

		#endregion

		#region property

		public IEnumerable<IArticle> AddedChildren   { get; private set; }
		public IEnumerable<IArticle> RemovedChildren { get; private set; }

		#endregion

	}

}
