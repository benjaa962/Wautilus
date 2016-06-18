using System.Collections.ObjectModel;
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
			//this.DataContext = context;
			RootPanel.ItemsSource = article.Children;

			article.IsObservationEnabled = true;
			article.Changed += Article_Changed;
		}

		private void Article_Changed(object sender, ArticleEventArgs e)
		{
		}

	}

}
