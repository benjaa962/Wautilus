using Wautilus.ArticleModel;
using Wautilus.BrowserControls;

namespace Wautilus
{

	public partial class TestPage : BrowserPage
	{
		
		#region constructor

		public TestPage () : base()
		{
			InitializeComponent();

			var Path = @"C:\Home";
			var Parameter = new ArticlesBuilderParameter
			{
				IncludeFiles       = true,
				IncludeDirectories = true,
				RootPath           = Path,
			};
			var Articles = ArticleBuilder.BuildCollection(Parameter);
			MainLayout.Articles = Articles;
		}
		
		#endregion

	}

}
