using System.Windows;
using Wautilus.ArticleModel;
using Wautilus.BrowserControls;

namespace Wautilus
{

	public partial class MainWindow : Window
	{
		
		#region constructor

		public MainWindow () : base()
		{
			InitializeComponent();

			var Path      = @"C:\Home\Cum";
			var Directory = new DirectoryArticle(Path);
			var Page      = new DirectoryPage(Directory);
			MainBrowser.Navigate(Page);
		}

		#endregion

	}

}
