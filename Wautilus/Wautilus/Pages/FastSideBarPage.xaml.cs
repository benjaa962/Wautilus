using System.Windows.Controls;
using Wautilus.ArticleModel;
using Wautilus.BrowserControls;

namespace Wautilus
{

	public partial class FastSideBarPage : BrowserPage, IArticleSelectable
	{
		
		#region constructor

		public FastSideBarPage () : base()
		{
			InitializeComponent();
			MainBox.DataContext = this;
			MainBox.SelectionChanged += OnSelectionChanged;

			var Drives = ArticleBuilder.BuildDrives();
			MainBox.ItemsSource = Drives;
		}


		#endregion

		#region property

		public Article           SelectedArticle => SelectedArticles ?. AloneArticle;
		public ArticleCollection SelectedArticles {get; private set; } = new ArticleCollection();

		#endregion
		
		#region private method

		private void OnSelectionChanged (object sender, SelectionChangedEventArgs e)
		{
			SelectedArticles = new ArticleCollection(MainBox.SelectedItems);
		}
		
		#endregion

	}

}
