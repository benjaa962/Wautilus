using Wautilus.Common.Module;

namespace Wautilus.Common.Article
{

	public interface IArticle : IResource, IRefreshable
	{

		string Path { get; }

		string GetName (ArticleNameType type);

	}

}
