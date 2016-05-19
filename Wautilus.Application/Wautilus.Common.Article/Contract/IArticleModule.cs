using System;
using Wautilus.Common.Module;

namespace Wautilus.Common.Article
{

	public interface IArticleModule : IModule
	{

		IArticle GetArticle (Uri reference);

	}

}
