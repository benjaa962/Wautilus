using System.Windows;
using Wautilus.ArticleModel;

namespace Wautilus
{

	public partial class MainWindow : Window
	{
		
		#region constructor

		public MainWindow ()
		{
			InitializeComponent();
			Test.Article = new FileArticle(@"C:\Home\u.jpg");
        }
		
		#endregion

	}

}
