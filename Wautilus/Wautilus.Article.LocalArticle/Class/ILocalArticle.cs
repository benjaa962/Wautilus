using Wautilus.Common.Article;

namespace Wautilus.Article.LocalArticle
{

	public interface ILocalArticle : IArticle
	{

		string Path { get; }

	}

}
