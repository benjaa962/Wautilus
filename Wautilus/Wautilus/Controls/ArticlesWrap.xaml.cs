using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wautilus.ArticleModel;

namespace Wautilus
{

	public partial class ArticlesWrap : UserControl
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
			RootLayout.DataContext = this;
		}

		#endregion

		#region property

		public Article SelectedArticle => MainBox.SelectedItem as Article;
		public IEnumerable<Article> SelectedArticles => new ArticleCollection(MainBox.SelectedItems);

		public ArticleCollection Articles
		{
			get { return (ArticleCollection)GetValue(ArticlesProperty); }
			set { SetValue(ArticlesProperty, value);                    }
		}

		#endregion

	}

}
