﻿using System.Windows.Input;
using Wautilus.ArticleModel;
using Wautilus.BrowserControls;

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
			if (Article is FileArticle)
				Article.Open(ArticleOpenType.MainApplication);
			if (Article is DirectoryArticle)
			{
				var Directory = Article as DirectoryArticle;
				var Page      = new DirectoryPage(Directory);
				MainBrowser.Navigate(Page);
			}
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
			if (e.Parameter is Article)
				e.CanExecute = CanOpenInNewTab(e.Parameter as Article);
			if (e.Parameter is IArticleSelectable)
				e.CanExecute = CanOpenInNewTab(e.Parameter as IArticleSelectable);

		}
		private void OpenInNewTab_Executed (object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Parameter is Article)
				OpenInNewTab(e.Parameter as Article);
			if (e.Parameter is IArticleSelectable)
				OpenInNewTab(e.Parameter as IArticleSelectable);
		}

		private bool CanOpenInNewTab (Article Article)
		{
			return Article is DirectoryArticle
				&& Article.CanOpen(ArticleOpenType.Wautilus);
		}
		private bool CanOpenInNewTab (IArticleSelectable Selectable)
		{
			return CanOpenInNewTab(Selectable ?. SelectedArticle);
		}

		private void OpenInNewTab (Article Article)
		{
			if (Article is DirectoryArticle)
			{
				var Directory = Article as DirectoryArticle;
				var Page      = new DirectoryPage(Directory);
				MainBrowser.Navigate(Page, BrowserLocation.AfterCurrent);
			}
		}
		private void OpenInNewTab (IArticleSelectable Selectable)
		{
			Open(Selectable ?. SelectedArticle);
		}

		#endregion

		#region Close

		private void Close_CanExecute (object sender, CanExecuteRoutedEventArgs e)
		{
			if (e.Parameter is BrowserFrame)
				e.CanExecute = CanClose(e.Parameter as BrowserFrame);
		}
		private void Close_Executed (object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Parameter is BrowserFrame)
				Close(e.Parameter as BrowserFrame);
		}

		private bool CanClose (BrowserFrame Frame)
		{
			return (Frame ?. Browser ?. Count ?? 0) > 1;
		}

		private void Close (BrowserFrame Frame)
		{
			if (CanClose(Frame))
				Frame.Browser.Close(Frame);
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
