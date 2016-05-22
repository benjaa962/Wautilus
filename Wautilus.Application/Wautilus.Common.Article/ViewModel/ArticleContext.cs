namespace Wautilus.Common.Article
{

	public class ArticleContext
	{

		#region constructor

		public ArticleContext () : base()
		{
		}
		public ArticleContext (IArticle article) : this()
		{
			Article = article;
		}

		#endregion

		#region property

		public IArticle Article { get; set; }
		
		#endregion

	}

}
