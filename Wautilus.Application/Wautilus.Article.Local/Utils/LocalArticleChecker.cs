using Alphaleonis.Win32.Filesystem;

namespace Wautilus.Article.Local
{

	public static class LocalArticleChecker
	{
		
		public static LocalArticleType GetType (string path)
		{
			if (Directory.Exists(path, PathFormat.FullPath))
				return LocalArticleType.Directory;
			if (File.Exists(path, PathFormat.FullPath))
				return LocalArticleType.File;
			return LocalArticleType.Invalid;
		}
		internal static LocalArticleType GetType (FileSystemInfo info)
		{
			if (info is DirectoryInfo)
				return LocalArticleType.Directory;
			if (info is FileInfo)
				return LocalArticleType.File;
			if (info is FileSystemInfo)
				return LocalArticleType.Article;
			return LocalArticleType.Invalid;
		}

	}

}
