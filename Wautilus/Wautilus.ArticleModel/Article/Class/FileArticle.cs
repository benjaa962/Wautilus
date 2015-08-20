using Alphaleonis.Win32.Filesystem;
using System;
using System.Diagnostics;

namespace Wautilus.ArticleModel
{

	public class FileArticle : Article
	{

		#region field

		private FileInfo   Info;
		private IShellItem Item;

		#endregion

		#region constructor

		public FileArticle (string Path) : base()
		{
			Info = new FileInfo(Path)         ;
			Item = ShellTools.CreateItem(Path);
		}

		#endregion

		#region property

		public override bool Exists => Info.Exists;

		public long Size => Exists ? Info.Length : 0;

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
					var ShortName = GetName(ArticleNameType.ShortName);
					return Path.GetFileNameWithoutExtension(ShortName);
				case ArticleNameType.FullName:
					return Info.FullName;
				case ArticleNameType.FullNameWithoutExtension:
					return Info.DirectoryName + @"\" + ShortNameWithoutExtension;
				case ArticleNameType.Label:
					return GetName(ArticleNameType.ShortNameWithoutExtension);
				default:
					return GetName(ArticleNameType.Label);
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
					return GetTime(ArticleTimeType.LastWrite);
			}
		}

		public override object GetImage (ArticleImageType Type)
		{
			var Size = ShellImageSize.Build(128);

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

		public bool CanOpen (ArticleOpenType Type)
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
		public void Open (ArticleOpenType Type)
		{
			if (!CanOpen(Type))
				return;

			switch (Type)
			{
				case ArticleOpenType.MainApplication:
					Process.Start(FullName);
					break;
				case ArticleOpenType.Properties:
					ShellTools.OpenProperties(FullName);
					break;
			}
		}

		#endregion

	}

}
