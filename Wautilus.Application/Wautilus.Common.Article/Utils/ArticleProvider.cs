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

		public static Uri GetReference (string moduleKey, string articlePath)
		{
			var builder = new UriBuilder
			{
				Scheme = moduleKey  ,
				Host   = articlePath,
			};
			return builder.Uri;
		}

		public static IArticle GetArticle (string reference)
		{
			var uri = new Uri(reference);
			return GetArticle(uri);
		}
		public static IArticle GetArticle (Uri reference)
		{
			var key    = reference ?. Scheme;
			var module = GetModule(key)     ;

			return module ?. GetArticle(reference);
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
