using System.Windows;
using System.Windows.Controls;
using Wautilus.ArticleModel;

namespace Wautilus
{

	public partial class ArticlesWrap : UserControl, IArticleSelectable
	{
		
		#region field

		public static readonly DependencyProperty ArticlesProperty = DependencyProperty.Register(
			"Articles", typeof(ArticleCollection), typeof(ArticlesWrap),
			new PropertyMetadata(new ArticleCollection())
		);

		#endregion

		#region constructor

		public ArticlesWrap () : base()
		{
			InitializeComponent();
			MainBox.DataContext = this;

			MainBox.SelectionChanged += OnSelectionChanged;
		}

		#endregion

		#region property

		public Article           SelectedArticle => SelectedArticles ?. AloneArticle;
		public ArticleCollection SelectedArticles {get; private set; } = new ArticleCollection();

		public ArticleCollection Articles
		{
			get { return (ArticleCollection)GetValue(ArticlesProperty); }
			set { SetValue(ArticlesProperty, value);                    }
		}

		#endregion
		
		#region private method

		private void OnSelectionChanged (object sender, SelectionChangedEventArgs e)
		{
			SelectedArticles = new ArticleCollection(MainBox.SelectedItems);
		}

		#endregion

		private void Open_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
		{
			if (SelectedArticle is FileArticle)
				SelectedArticle.Open(ArticleOpenType.MainApplication);
			else if (SelectedArticle is DirectoryArticle)
				SelectedArticle.Open(ArticleOpenType.Wautilus);
		}
		private void Open_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
		{
			if (SelectedArticle is FileArticle)
				SelectedArticle.Open(ArticleOpenType.MainApplication);
			else if (SelectedArticle is DirectoryArticle)
				SelectedArticle.Open(ArticleOpenType.Wautilus);
		}

		private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
		{
			if (SelectedArticle != null)
				SelectedArticle.Open(ArticleOpenType.Properties);
		}
		private void CommandBinding_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
		{
			if (SelectedArticle != null)
				e.CanExecute = SelectedArticle.CanOpen(ArticleOpenType.Properties);
		}
	}

}
