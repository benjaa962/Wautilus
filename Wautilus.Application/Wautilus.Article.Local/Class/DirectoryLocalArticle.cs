using Alphaleonis.Win32.Filesystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Wautilus.Common.Article;

namespace Wautilus.Article.Local
{

	public class DirectoryLocalArticle : LocalArticle, IParentArticle
	{
		
		#region field

		private DirectoryInfo Info;

		private ObservableCollection<IArticle> _Children = null;

		#endregion

		#region constructor

		public DirectoryLocalArticle (string path)
		{
			Info = new DirectoryInfo(path);
		}
		internal DirectoryLocalArticle (DirectoryInfo info)
		{
			Info = info;
		}

		#endregion

		#region property

		public override string Path => Info?.FullName;

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
			Info.Refresh();
			_Children = null;
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

		#region private method

		private ObservableCollection<IArticle> GetChildren ()
		{
			var children = Info
				.GetFileSystemInfos("*", System.IO.SearchOption.TopDirectoryOnly)
				.Select(info => LocalArticleFactory.GetArticle(info))
				.OrderBy(article => article.Path);
			return new ObservableCollection<IArticle>(children);
		}

		#endregion

	}

}
