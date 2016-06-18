using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wautilus.Common.Article;
using AlphaFS = Alphaleonis.Win32.Filesystem;

namespace Wautilus.Article.Local
{

	public class DirectoryLocalArticle : LocalArticle, IObservableParentArticle
	{

		#region field

		public event EventHandler<MovedArticleEventArgs>            Moved           ;
		public event EventHandler<ChildrenModifiedArticleEventArgs> ChildrenModified;

		private AlphaFS.DirectoryInfo Info   ;
		private FileSystemWatcher     Watcher;

		private IEnumerable<IArticle> _Children = null;

		#endregion

		#region constructor

		public DirectoryLocalArticle (string path) : base()
		{
			Info = new AlphaFS.DirectoryInfo(path);
			Refresh();
		}
		internal DirectoryLocalArticle (AlphaFS.DirectoryInfo info) : base()
		{
			Info = info;
			Refresh();
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

		public bool IsObservationEnabled
		{
			get { return Watcher.EnableRaisingEvents;  }
			set { Watcher.EnableRaisingEvents = value; }
		}

		#endregion

		#region public method

		public override void Refresh ()
		{
			_Children = null;
			Info.Refresh();

			Watcher.Changed -= Watcher_Changed;
			Watcher = new FileSystemWatcher(Path);
			Watcher.Changed += Watcher_Changed;
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

		public override LocalArticle GetParent ()
		{
			return LocalArticleFactory.GetArticle(Info.Parent);
		}

		#endregion

		#region private method

		private IEnumerable<IArticle> GetChildren ()
		{
			return Info
				.GetFileSystemInfos("*", SearchOption.TopDirectoryOnly)
				.Select(info => LocalArticleFactory.GetArticle(info));
		}

		#endregion

		#region event

		private void Watcher_Changed (object sender, FileSystemEventArgs e)
		{
		}

		#endregion

	}

}
