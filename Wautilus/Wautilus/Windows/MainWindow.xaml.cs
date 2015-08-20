using System.Windows;
using System.Windows.Input;
using Wautilus.ArticleModel;

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
			//MainBrowser.GoBack();
		}
		private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			//e.CanExecute = MainBrowser != null && MainBrowser.CanGoBack;
		}

	}

}
