using System.Windows.Input;
using Wautilus.ArticleModel;

namespace Wautilus
{

	public partial class MainWindow
	{

		#region Open

		private void Open_CanExecute (object sender, CanExecuteRoutedEventArgs e)
		{
			if (e.Parameter is IArticleSelectable)
			{
				var Selectable = e.Parameter as IArticleSelectable;
				var Article    = Selectable.SelectedArticle       ;
				var OpenType   = GetOpenType(Article)             ;

				if (Article != null)
					e.CanExecute = Article.CanOpen(OpenType);
			}
		}

		private void Open_Executed (object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Parameter is IArticleSelectable)
			{
				var Selectable = e.Parameter as IArticleSelectable;
				var Article    = Selectable.SelectedArticle       ;
				var OpenType   = GetOpenType(Article)             ;

				if (Article != null)
					Article.Open(OpenType);
			}
		}

		private ArticleOpenType GetOpenType (Article Article)
		{
			if (Article is FileArticle)
				return ArticleOpenType.MainApplication;
			if (Article is DirectoryArticle)
				return ArticleOpenType.Wautilus;
			return ArticleOpenType.Wautilus;
		}

		#endregion

	}

}
