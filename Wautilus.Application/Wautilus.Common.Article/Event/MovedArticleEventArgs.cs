namespace Wautilus.Common.Article
{

	public class MovedArticleEventArgs : ArticleEventArgs
	{

		#region constructor

		public MovedArticleEventArgs (IArticle article, string oldPath, string newPath) : base(article)
		{
			OldPath = oldPath;
			NewPath = NewPath;
		}

		#endregion

		#region property

		public string OldPath { get; private set; }
		public string NewPath { get; private set; }

		#endregion

	}

}
