using System.Collections.Generic;
using System.IO;

using static Wautilus.ArticleModel.ArticleChecker;

namespace Wautilus.ArticleModel
{

	public static class ArticleBuilder
	{
		
		#region public method
		
		public static Article Build (string Path)
		{
			var Type = ArticleChecker.GetType(Path);
			return Build(Path, Type);
		}
		public static Article Build (string Path, ArticleType Type)
		{
			if (!HasType(Path, Type))
				return null;

			switch (Type)
			{
				case ArticleType.File:
					return new FileArticle(Path);
				case ArticleType.Directory:
					return new DirectoryArticle(Path);
				case ArticleType.Drive:
					return new DriveArticle(Path);
				default:
					return null;
			}
		}

		public static ArticleCollection BuildDrives ()
		{
			var Drives     = new ArticleCollection();
            var DrivePaths = Directory.GetLogicalDrives()            ;

			foreach (string DrivePath in DrivePaths)
                if (HasType(DrivePath, ArticleType.Drive))
					Drives.Add(new DriveArticle(DrivePath));

			return Drives;
		}

		public static ArticleCollection BuildCollection (ArticlesBuilderParameter Parameter)
		{
			var Articles = new ArticleCollection();
			FillCollection(Articles, Parameter);
			return Articles;
        }

		public static void FillCollection (ArticleCollection Articles, ArticlesBuilderParameter Parameter)
		{
			Articles.Clear();
			var Paths = GetPaths(Parameter);

			foreach (string Path in Paths)
			{
				var Article = Build(Path);
				if (Article != null)
					Articles.Add(Article);
            }
		}

		#endregion

		#region private method

		private static IEnumerable<string> GetPaths (ArticlesBuilderParameter Parameter)
		{
			var Pattern =
				!string.IsNullOrWhiteSpace(Parameter.Pattern)
					? Parameter.Pattern
					: null;
			var Option =
				Parameter.IsRecursive
					? SearchOption.AllDirectories
					: SearchOption.TopDirectoryOnly;

			if ( Parameter.IncludeFiles && !Parameter.IncludeDirectories)
				return Directory.EnumerateFiles(Parameter.RootPath, Pattern, Option);
			if (!Parameter.IncludeFiles &&  Parameter.IncludeDirectories)
				return Directory.EnumerateDirectories(Parameter.RootPath, Pattern, Option);
			if ( Parameter.IncludeFiles &&  Parameter.IncludeDirectories)
				return Directory.EnumerateFileSystemEntries(Parameter.RootPath, Pattern, Option);
			return new string[0];
		}

		#endregion

	}

}
