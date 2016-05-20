using System.Windows;
using Wautilus.Common.Article;
using Wautilus.Common.Module;

namespace Wautilus.Application
{

	public partial class MainWindow : Window
	{
		
		#region constructor

		public MainWindow ()
		{
			InitializeComponent();

			ModuleProvider.Instance.Import();
			var path = @"C:\Home\DansTonChat\6600.txt";
			var a = ArticleProvider.GetArticle("local", path);
		}
		
		#endregion

	}

}
