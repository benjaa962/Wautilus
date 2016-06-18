using System;

namespace Wautilus.Common.Article
{

	public class ArticleEventArgs : EventArgs
	{
		
		#region constructor

		public ArticleEventArgs (IArticle article) : base()
		{
			Article = article;
		}

		#endregion

		#region property

		public IArticle Article { get; private set; }

		#endregion

	}

}
