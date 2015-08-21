using Wautilus.ArticleModel;
using Wautilus.BrowserControls;

namespace Wautilus
{

	public partial class DirectoryPage : BrowserPage
	{
		
		#region constructor

		public DirectoryPage ()
		{
			InitializeComponent();
		}
		public DirectoryPage (DirectoryArticle Directory) : base()
		{
			InitializeComponent();

			Title = Directory.Label;
			this.Directory = Directory;

			var Parameter = new ArticlesBuilderParameter
			{
				IncludeFiles       = true,
				IncludeDirectories = true,
				RootPath = Directory.FullName,
			};

			var Articles = ArticleBuilder.BuildCollection(Parameter);
			ArticlePanel.Articles = Articles;
		}

		#endregion

		#region property

		public DirectoryArticle Directory { get; }

		#endregion

	}

}
