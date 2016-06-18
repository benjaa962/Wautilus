namespace Wautilus.Common.Article
{

	public static class ArticleContextFactory
	{
		
		#region public method

		public static ArticleContext Build (IArticle article)
		{
			if (article == null)
				return null;
			return new ArticleContext(article);
		}
		
		#endregion

	}

}
