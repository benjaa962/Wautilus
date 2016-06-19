using System;
using System.IO;
using Wautilus.Common.Article;
using Wautilus.Common.Module;

namespace Wautilus.Article.Local
{

	public abstract class LocalArticle : IArticle, IChildArticle, IObservableArticle, IRefreshable
	{

		#region field

		public event EventHandler<ArticleEventArgs>      Changed;
		public event EventHandler<MovedArticleEventArgs> Moved  ;

		private bool _IsObservationEnabled = false;

		private LocalArticle      _Parent;
		private FileSystemWatcher Watcher;

		#endregion

		#region property

		public abstract string Path { get; }

		public IArticle Parent
		{
			get
			{
				if (_Parent == null)
					_Parent = GetParent();
				return _Parent;
			}
		}

		public bool IsObservationEnabled
		{
			get {
				return _IsObservationEnabled;
			}
			set
			{
				if (_IsObservationEnabled == value)
					return;
				_IsObservationEnabled = value;

				if (Watcher != null)
				{
					Watcher.Changed -= Watcher_Changed;
					Watcher.Renamed -= Watcher_Renamed;
					Watcher.EnableRaisingEvents = false;
					Watcher = null;
				}

				if (_IsObservationEnabled)
				{
					Watcher = new FileSystemWatcher(Path);
					Watcher.Changed += Watcher_Changed;
					Watcher.Renamed += Watcher_Renamed;
					Watcher.EnableRaisingEvents = true;
				}
			}
		}

		#endregion

		#region public method

		public virtual void Refresh ()
		{
			_Parent = null;

			if (IsObservationEnabled)
			{
				IsObservationEnabled = false;
				IsObservationEnabled = true ;
			}
		}

		public abstract string GetName (ArticleNameType type);

		public override int GetHashCode ()
		{
			return Path.GetHashCode();
		}

		public new bool Equals (object other)
		{
			var local = other as LocalArticle;
			return Equals(local);
		}
		public bool Equals (IArticle other)
		{
			var local = other as LocalArticle;

			return local      != null
				&& local.Path != null
				&& local.Path == Path;
		}

		public override string ToString ()
		{
			return Path;
		}

		#endregion

		#region protected method

		protected virtual LocalArticle GetParent ()
		{
			return null;
		}

		#endregion

		#region event

		private void Watcher_Changed (object sender, FileSystemEventArgs e)
		{
			if (Changed != null)
			{
				var Args = new ArticleEventArgs(this);
				Changed.Invoke(this, Args);
			}
		}
		private void Watcher_Renamed (object sender, RenamedEventArgs e)
		{
			if (Moved != null)
			{
				var Args = new MovedArticleEventArgs(this, e.OldFullPath, e.FullPath);
				Moved.Invoke(this, Args);
			}
		}

		#endregion

	}

}
