using Alphaleonis.Win32.Filesystem;

namespace Wautilus.Article.Local
{

	public static class LocalArticleFactory
	{

		public static LocalArticle GetArticle (string path)
		{
			var type = LocalArticleChecker.GetType(path);
			switch (type)
			{
				case LocalArticleType.Drive:
				case LocalArticleType.Directory:
					return new DirectoryLocalArticle(path);
				case LocalArticleType.File:
					return new FileLocalArticle(path);
				default:
					return null;
			}
		}

		internal static LocalArticle GetArticle (FileSystemInfo info)
		{
			if (info is FileInfo)
				return new FileLocalArticle(info as FileInfo);
			if (info is DirectoryInfo)
				return new DirectoryLocalArticle(info as DirectoryInfo);
			return null;
		}

	}

}
