using Wautilus.Common.Article;
using Wautilus.Common.Module;

namespace Wautilus.Article.Local
{

	public abstract class LocalArticle : IArticle, IChildArticle, IRefreshable
	{
		
		#region field

		private LocalArticle _Parent;

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

		#endregion

		#region public method

		public virtual void Refresh ()
		{
			_Parent = null;
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

		public virtual LocalArticle GetParent ()
		{
			return null;
		}

		#endregion

	}

}
