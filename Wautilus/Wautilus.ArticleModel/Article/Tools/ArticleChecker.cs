using System.IO;

namespace Wautilus.ArticleModel
{

	public static class ArticleChecker
	{

		#region const

		private static readonly ArticleType[] SortedTypesForHasType =
		{
			ArticleType.File     ,
			ArticleType.Drive    ,
			ArticleType.Directory,
			ArticleType.Article  ,
		};

		#endregion

		#region public method

		public static bool HasType (string Path, ArticleType Type)
		{
			switch (Type)
			{
				case ArticleType.File:
					return File.Exists(Path);
				case ArticleType.Directory:
					return Directory.Exists(Path);
				case ArticleType.Drive:
					return Directory.Exists(Path)
						&& Directory.GetParent(Path) == null;
				case ArticleType.Article:
					return HasType(Path, ArticleType.File)
						|| HasType(Path, ArticleType.Directory);
				case ArticleType.NoArticle:
					return !HasType(Path, ArticleType.Article);
				default:
					return false;
            }
		}

		public static ArticleType GetType (string Path)
		{
			foreach (var Type in SortedTypesForHasType)
				if (HasType(Path, Type))
					return Type;
			return ArticleType.NoArticle;
		}

		#endregion

	}

}
