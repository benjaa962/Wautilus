using System.Windows;
using System.Windows.Controls;
using Wautilus.ArticleModel;

namespace Wautilus.ArticleControls
{

	public partial class ArticleItem : UserControl
	{

		#region field

		public static readonly DependencyProperty ArticleProperty = DependencyProperty.Register(
			"Article", typeof(Article), typeof(ArticleItem),
			new PropertyMetadata(null, OnArticlePropertyChanged)
		);

		public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
			"Type", typeof(ArticleItemType), typeof(ArticleItem),
			new PropertyMetadata(ArticleItemType.ImageNormal, OnTypePropertyChanged)
		);

		#endregion

		#region constructor

		public ArticleItem () : base()
		{
			InitializeComponent();
			OnTypeChanged();
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

		public ArticleItemType Type
		{
			get { return (ArticleItemType)GetValue(TypeProperty); }
			set { SetValue(TypeProperty, value);                  }
		}

		#endregion

		#region private method

		private static void OnArticlePropertyChanged (DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var Item = sender as ArticleItem;
			Item.OnArticleChanged();
		}

		private static void OnTypePropertyChanged (DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var Item = sender as ArticleItem;
			Item.OnTypeChanged();
		}

		private void OnArticleChanged ()
		{
			Presenter.Content = Article;
		}

		private void OnTypeChanged ()
		{
			var Key      = Type.ToString() + "Template"     ;
			var Template = FindResource(Key) as DataTemplate;

			Presenter.ContentTemplate = Template;
		}

		#endregion

	}

}
