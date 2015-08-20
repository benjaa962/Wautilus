using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Wautilus.ArticleModel;

namespace Wautilus.ArticleControls
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

		public ArticleCollection Articles
		{
			get { return (ArticleCollection)GetValue(ArticlesProperty); }
			set { SetValue(ArticlesProperty, value);                    }
		}

		#endregion

	}

}
