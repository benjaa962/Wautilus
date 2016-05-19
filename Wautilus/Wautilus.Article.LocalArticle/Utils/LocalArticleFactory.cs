namespace Wautilus.Article.LocalArticle
{

	public static class LocalArticleFactory
	{

		public static ILocalArticle GetArticle (string path)
		{
			return new FileLocalArticle(path);
		}

	}

}
