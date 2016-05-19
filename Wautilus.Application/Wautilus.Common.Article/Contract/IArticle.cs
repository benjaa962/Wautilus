using Wautilus.Common.Module;

namespace Wautilus.Common.Article
{

	public interface IArticle
	{

		string Path { get; }

		string GetName (ArticleNameType type);

	}

}
