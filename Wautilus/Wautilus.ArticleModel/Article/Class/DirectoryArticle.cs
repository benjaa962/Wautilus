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
			var Size = ShellImageSize.Build(256);

			switch (Type)
			{
				case ArticleImageType.NoImage:
					return null;
				case ArticleImageType.DefaultIcon:
					return ShellTools.GetImage(Item, ShellImageType.IconOnly, Size);
				case ArticleImageType.EmbeddedIcon:
					return ShellTools.GetImage(Item, ShellImageType.IconOnly, Size);
				case ArticleImageType.EmbeddedThumbnail:
					return ShellTools.GetImage(Item, ShellImageType.ThumbnailOnly, Size);
				case ArticleImageType.ThemeIcon:
					return ShellTools.GetImage(Item, ShellImageType.IconOnly, Size);
				case ArticleImageType.ThemeThumbnail:
					return ShellTools.GetImage(Item, ShellImageType.ThumbnailOnly, Size);
				default:
					return null;
			}
		}

		public override bool CanOpen (ArticleOpenType Type)
		{
			switch (Type)
			{
				case ArticleOpenType.MainApplication:
				case ArticleOpenType.Properties:
					return Exists;
				default:
					return false;
			}
		}
		public override void Open (ArticleOpenType Type)
		{
			if (!CanOpen(Type))
				return;

			switch (Type)
			{
				case ArticleOpenType.MainApplication:
					break;
				case ArticleOpenType.Properties:
					ShellTools.OpenProperties(FullName);
					break;
			}
		}

		#endregion

	}

}
