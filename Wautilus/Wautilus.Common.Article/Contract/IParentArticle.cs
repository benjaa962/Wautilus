using System.Collections.Generic;

namespace Wautilus.Common.Article
{

	public interface IParentArticle : IArticle
	{

		IEnumerable<IArticle> SubArticles { get; }

	}

}
