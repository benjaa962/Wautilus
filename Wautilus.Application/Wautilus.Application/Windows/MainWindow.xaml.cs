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
			var path = @"D:\Vrac";
			var a = ArticleProvider.GetArticle("local", path) as DirectoryLocalArticle;
			var b = a.Children as ObservableCollection<IArticle>;
		}

	}

}
