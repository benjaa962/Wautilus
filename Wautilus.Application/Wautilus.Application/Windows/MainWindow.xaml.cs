using System.Windows;
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
			var path = @"C:\Home\DansTonChat\6600.txt";
			var a = ArticleProvider.GetArticle("local", path);
		}

	}

}
