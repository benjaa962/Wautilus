using Wautilus.Common.Article;
using Wautilus.Common.Module;

namespace Wautilus.Article.Local
{

	public abstract class LocalArticle : IArticle,  IRefreshable
	{
		
		#region property

		public abstract string Path { get; }

		#endregion

		#region public method

		public virtual void Refresh ()
		{
		}

		public abstract string GetName (ArticleNameType type);

		public override int GetHashCode ()
		{
			return Path.GetHashCode();
		}

		public new bool Equals(object other)
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

		#endregion

	}

}
