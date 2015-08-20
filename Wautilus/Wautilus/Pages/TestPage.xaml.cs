using Wautilus.ArticleModel;
using Wautilus.BrowserControls;

namespace Wautilus
{

	public partial class TestPage : BrowserPage
	{

		#region constructor

		public TestPage() : base()
		{
			InitializeComponent();

			var Articles = ArticleBuilder.BuildDrives();
			MainLayout.Articles = Articles;

		}
		public TestPage (DirectoryArticle Directory) : base()
		{
			InitializeComponent();

			var Parameter = new ArticlesBuilderParameter
			{
				IncludeFiles       = true,
				IncludeDirectories = true,
				RootPath           = Directory.FullName,
			};
			var Articles = ArticleBuilder.BuildCollection(Parameter);
			MainLayout.Articles = Articles;
		}
		
		#endregion

	}

}
