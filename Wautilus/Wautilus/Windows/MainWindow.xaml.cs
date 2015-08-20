using System.Windows;
using System.Windows.Input;
using Wautilus.ArticleModel;
using Wautilus.BrowserControls;

namespace Wautilus
{

	public partial class MainWindow : Window
	{
		
		#region constructor

		public MainWindow ()
		{
			InitializeComponent();
			var Page = new TestPage();
			Browser.Navigate(Page);
			var a = Page.Browser;
			/*var Parameter = new ArticlesBuilderParameter
			{
				IncludeFiles       = true ,
                IncludeDirectories = false,
				RootPath =  @"C:\Home",
			};
			var Articles = ArticleBuilder.BuildCollection(Parameter);
			Test.Articles = Articles;*/
        }

		#endregion


		private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			Browser ?.CurrentFrame?.GoBack();
		}
		private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = Browser?.CurrentFrame?.CanGoBack ?? false;
		}

		private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			Browser?.CurrentFrame?.GoForward();
		}
		private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = Browser?.CurrentFrame?.CanGoForward ?? false;
		}


		private void Open_Executed (object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Parameter is FileArticle)
			{
				var File = e.Parameter as FileArticle;
				File.Open(ArticleOpenType.MainApplication);
			}
			if (e.Parameter is DirectoryArticle)
			{
				var Directory = e.Parameter as DirectoryArticle;
				var Page = new TestPage(Directory);
				Browser.Navigate(Page);
			}
		}
		private void Open_CanExecute (object sender, CanExecuteRoutedEventArgs e)
		{
			if (e.Parameter is Article)
			{
				var Article = e.Parameter as Article;
				e.CanExecute = Article.CanOpen(ArticleOpenType.MainApplication);
			}
		}

		private void Properties_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Parameter is Article)
			{
				var Article = e.Parameter as Article;
				Article.Open(ArticleOpenType.Properties);
			}
		}
		private void Properties_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			if (e.Parameter is Article)
			{
				var Article = e.Parameter as Article;
				e.CanExecute = Article.CanOpen(ArticleOpenType.Properties);
			}
		}

	}

}
