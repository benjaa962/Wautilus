using System;
using Wautilus.Common.Article;
using Wautilus.Common.Module;

namespace Wautilus.Article.Local
{

	[ModuleExport(Constant.Key, Constant.Version)]
	public class LocalArticleModule : IModule, IArticleModule
	{

		#region property

		public IModuleInfo Info => GetInfo();

		public string Key     => Constant.Key    ;
		public string Version => Constant.Version;

		#endregion

		#region public method

		public ModuleState GetState ()
		{
			return ModuleState.Succes;
		}

		public IArticle GetArticle (string path)
		{
			return LocalArticleFactory.GetArticle(path);
		}

		#endregion

		#region private method

		private static IModuleInfo GetInfo ()
		{
			var builder = new ModuleInfoBuilder
			{
				Author  = Constant.Author ,
				Comment = Constant.Comment,
			};

			return builder.Build();
		}

		#endregion

	}

}
