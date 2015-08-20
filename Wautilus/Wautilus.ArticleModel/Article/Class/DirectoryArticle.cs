using System;
using System.IO;

namespace Wautilus.ArticleModel
{

	public class DirectoryArticle : Article
	{
		
		#region field

		private DirectoryInfo Info;
		private IShellItem    Item;


		#endregion

		#region constructor

		public DirectoryArticle (string Path) : base()
		{
			Info = new DirectoryInfo(Path);
			Item = ShellTools.CreateItem(Path);
		}

		#endregion
		
		#region property

		public override bool Exists => Info.Exists;

		#endregion

		#region public method

		public override void Refresh ()
		{
			Info.Refresh();
		}

		public override string GetName (ArticleNameType Type)
		{
			switch (Type)
			{
				case ArticleNameType.Extension:
					return Info.Extension;
				case ArticleNameType.ShortName:
					return Info.Name;
				case ArticleNameType.ShortNameWithoutExtension:
					return Info.Name;
				case ArticleNameType.FullName:
					return Info.FullName;
				case ArticleNameType.FullNameWithoutExtension:
					return Info.FullName;
				case ArticleNameType.Label:
					return ShellTools.GetName(Item, ShellNameType.NormalDisplay) ?? string.Empty;
				default:
					return FullName;
			}
		}

		public override DateTime GetTime (ArticleTimeType Type)
		{
			switch (Type)
			{
				case ArticleTimeType.Creation:
					return Info.CreationTime;
				case ArticleTimeType.LastWrite:
					return Info.LastWriteTime;
				case ArticleTimeType.LastAccess:
					return Info.LastAccessTime;
				case ArticleTimeType.Default:
				default:
					return LastWriteTime;
			}
		}

		public override object GetImage (ArticleImageType Type)
		{
			return null;
		}

		#endregion

	}

}
