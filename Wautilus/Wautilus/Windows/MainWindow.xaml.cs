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

		private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Parameter is DirectoryArticle)
			{
				var Directory = e.Parameter as DirectoryArticle;
				var Page = new TestPage(Directory);
				Browser.Navigate(Page);
			}
		}
		private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
            if (e.Parameter is DirectoryArticle)
			{
				var Directory = e.Parameter as DirectoryArticle;
                e.CanExecute = Directory.Exists;
			}
		}

	}

}
