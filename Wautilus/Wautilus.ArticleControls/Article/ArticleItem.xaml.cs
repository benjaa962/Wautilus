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

namespace Wautilus.ArticleControls
{

	public partial class ArticleItem : UserControl
	{
		
		#region field

		public static readonly DependencyProperty ArticleProperty = DependencyProperty.Register(
			"Article", typeof(Article), typeof(ArticleItem)
		);

		#endregion

		#region constructor

		public ArticleItem () : base()
		{
			InitializeComponent();
			RootLayout.DataContext = this;
		}
		public ArticleItem (Article Article) : this()
		{
			this.Article = Article;
		}

		#endregion

		#region property

		public Article Article
		{
			get { return (Article)GetValue(ArticleProperty); }
			set { SetValue(ArticleProperty, value);          }
		}

		#endregion

	}

}
