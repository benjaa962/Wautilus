using System;
using Wautilus.Common.Module;

namespace Wautilus.Common.Article
{

	public class ArticleProvider
	{

		#region field

		private static ArticleProvider _Instance = new ArticleProvider();

		#endregion

		#region constructor

		private ArticleProvider ()
		{
		}

		#endregion

		#region property

		public static ArticleProvider Instance => _Instance;

		#endregion

		#region public method

		public static IArticle GetArticle (string moduleKey, string articlePath)
		{
			var module = GetModule(moduleKey);
			return module ?. GetArticle(articlePath);
		}

		#endregion

		#region private method

		private static IArticleModule GetModule (string key)
		{
			var provider = ModuleProvider.Instance;
			return provider.GetModule<IArticleModule>(key);
		}

		#endregion

	}

}
