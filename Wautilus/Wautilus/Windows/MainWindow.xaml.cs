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

			var Articles = new ArticleCollection();
			for (int i = 0; i < 1000; ++i)
				Articles.Add(new FileArticle(@"C:\Home\u.jpg"));

			Test.Articles = Articles;
        }
		
		#endregion

	}

}
