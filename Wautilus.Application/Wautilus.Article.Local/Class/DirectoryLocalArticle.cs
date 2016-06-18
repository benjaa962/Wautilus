using Alphaleonis.Win32.Filesystem;
using System.Collections.Generic;
using System.Linq;
using Wautilus.Common.Article;

namespace Wautilus.Article.Local
{

	public class DirectoryLocalArticle : LocalArticle
	{

		#region field

		private DirectoryInfo Info;

		private IEnumerable<IArticle> _Children = null;

		#endregion

		#region constructor

		public DirectoryLocalArticle (string path) : base()
		{
			Info = new DirectoryInfo(path);
			RefreshWatcher();
		}
		internal DirectoryLocalArticle (DirectoryInfo info) : base()
		{
			Info = info;
			RefreshWatcher();
		}

		#endregion

		#region property

		public override string Path => Info ?. FullName;

		public IEnumerable<IArticle> Children
		{
			get
			{
				if (_Children == null)
					_Children = GetChildren();
				return _Children;
			}
		}

		#endregion

		#region public method

		public override void Refresh ()
		{
			_Children = null;

			base.Refresh  ();
			Info.Refresh  ();
			RefreshWatcher();
		}

		public override string GetName (ArticleNameType type)
		{
			switch (type)
			{
				case ArticleNameType.Full : return Info.FullName;
				case ArticleNameType.Short: return Info.Name    ;
				default: return null;
			}
		}

		#endregion

		#region protected method

		protected override LocalArticle GetParent ()
		{
			return LocalArticleFactory.GetArticle(Info.Parent);
		}

		#endregion

		#region private method

		private IEnumerable<IArticle> GetChildren ()
		{
			return Info
				.GetFileSystemInfos("*", System.IO.SearchOption.TopDirectoryOnly)
				.Select(info => LocalArticleFactory.GetArticle(info));
		}

		#endregion

	}

}
