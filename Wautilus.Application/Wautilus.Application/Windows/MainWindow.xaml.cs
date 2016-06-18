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
			var article = ArticleProvider.GetArticle("local", path) as IParentArticle;
			var context = new ArticleContext(article);
			//this.DataContext = context;
			RootPanel.ItemsSource = article.Children;
		}

	}

}
