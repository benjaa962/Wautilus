using System.Windows.Input;
using Wautilus.ArticleModel;

namespace Wautilus
{

	public partial class MainWindow
	{

		#region Open

		private void Open_CanExecute (object sender, CanExecuteRoutedEventArgs e)
		{
			if (e.Parameter is Article)
				e.CanExecute = CanOpen(e.Parameter as Article);
			if (e.Parameter is IArticleSelectable)
				e.CanExecute = CanOpen(e.Parameter as IArticleSelectable);
		}
		private void Open_Executed (object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Parameter is Article)
				Open(e.Parameter as Article);
			if (e.Parameter is IArticleSelectable)
				Open(e.Parameter as IArticleSelectable);
		}

		private bool CanOpen (Article Article)
		{
			if (Article == null)
				return false;
			var OpenType = GetOpenType(Article);
			return Article.CanOpen(OpenType);
		}
		private bool CanOpen (IArticleSelectable Selectable)
		{
			return CanOpen(Selectable ?. SelectedArticle);
		}

		private void Open (Article Article)
		{
			if (Article == null)
				return;
			var OpenType = GetOpenType(Article);
			Article.Open(OpenType);
		}
		private void Open (IArticleSelectable Selectable)
		{
			Open(Selectable ?. SelectedArticle);
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
		
		#region OpenInNewTab

		private void OpenInNewTab_CanExecute (object sender, CanExecuteRoutedEventArgs e)
		{
		}
		private void OpenInNewTab_Executed (object sender, ExecutedRoutedEventArgs e)
		{
		}

		#endregion

		#region Cut

		private void Cut_CanExecute (object sender, CanExecuteRoutedEventArgs e)
		{
		}
		private void Cut_Executed (object sender, ExecutedRoutedEventArgs e)
		{
		}

		#endregion
		
		#region Copy

		private void Copy_CanExecute (object sender, CanExecuteRoutedEventArgs e)
		{
		}
		private void Copy_Executed (object sender, ExecutedRoutedEventArgs e)
		{
		}

		#endregion
		
		#region Paste

		private void Paste_CanExecute (object sender, CanExecuteRoutedEventArgs e)
		{
		}
		private void Paste_Executed (object sender, ExecutedRoutedEventArgs e)
		{
		}

		#endregion

	}

}
