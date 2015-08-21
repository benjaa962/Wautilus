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
		public TestPage (string DirectoryPath) : this(new DirectoryArticle(DirectoryPath))
		{
			/*InitializeComponent();
			this.Directory = Directory;
			//Loaded += TestPage_Loaded;

			var Parameter = new ArticlesBuilderParameter
			{
				IncludeFiles = true,
				IncludeDirectories = true,
				RootPath = Directory.FullName,
			};
			var Articles = ArticleBuilder.BuildCollection(Parameter);
			MainLayout.Articles = Articles;*/
		}
		public TestPage (DirectoryArticle Directory) : base()
		{
			InitializeComponent();
			//Loaded += TestPage_Loaded;
			this.Directory = Directory;
			
			//Loaded += TestPage_Loaded;

			//var Parameter = new ArticlesBuilderParameter
			//{
			//	IncludeFiles       = true,
			//	IncludeDirectories = true,
			//	RootPath           = Directory.FullName,
			//};
			//var Articles = ArticleBuilder.BuildCollection(Parameter);
			//MainLayout.Articles = Articles;
		}

		public override void Refresh()
		{
			base.Refresh();
			if (Directory == null)
				return;
			var Parameter = new ArticlesBuilderParameter
			{
				IncludeFiles = true,
				IncludeDirectories = true,
				RootPath = Directory.FullName,
			};
			var Articles = ArticleBuilder.BuildCollection(Parameter);
			MainLayout.Articles = Articles;
		}

		private DirectoryArticle Directory;


		public override void EndInit()
		{
			base.EndInit();


		}

		/*private DirectoryArticle Directory;

		private void TestPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			if (Directory == null)
				return;
			var Parameter = new ArticlesBuilderParameter
			{
				IncludeFiles = true,
				IncludeDirectories = true,
				RootPath = Directory.FullName,
			};
			var Articles = ArticleBuilder.BuildCollection(Parameter);
			MainLayout.Articles = Articles;

		}*/

		#endregion


	}

}
