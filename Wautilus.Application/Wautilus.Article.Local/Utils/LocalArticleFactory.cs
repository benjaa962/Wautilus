namespace Wautilus.Article.Local
{

	public static class LocalArticleFactory
	{

		public static LocalArticle GetArticle (string path)
		{
			return new FileLocalArticle(path);
		}

	}

}
