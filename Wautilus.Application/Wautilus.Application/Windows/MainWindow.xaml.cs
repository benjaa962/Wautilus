using System.Windows;
using Wautilus.Article.Local;
using Wautilus.Common.Article;

namespace Wautilus.Application
{

	public partial class MainWindow : Window
	{
		
		#region constructor

		public MainWindow ()
		{
			InitializeComponent();
			Test();
		}

		#endregion

		private void Test ()
		{
			var path = @"C:\Home";
			var article = ArticleProvider.GetArticle("local", path) as DirectoryLocalArticle;
			var context = new ArticleContext(article);
			context.IsObservationEnabled = true;
			RootPanel.ItemsSource = context.Children;
		}

	}

}
