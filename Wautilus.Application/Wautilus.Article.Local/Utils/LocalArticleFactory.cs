namespace Wautilus.Article.Local
{

	public static class LocalArticleFactory
	{

		public static ILocalArticle GetArticle (string path)
		{
			return new FileLocalArticle(path);
		}

	}

}
