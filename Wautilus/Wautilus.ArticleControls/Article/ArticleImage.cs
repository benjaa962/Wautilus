using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Wautilus.ArticleModel;

namespace Wautilus.ArticleControls
{

	public class ArticleImage : Image
	{

		#region field

		public static readonly DependencyProperty ArticleProperty = DependencyProperty.Register(
			"Article", typeof(Article), typeof(ArticleImage),
			new PropertyMetadata(OnArticlePropertyChanged)
		);

		private static readonly IValueConverter Converter = new ToImageSourceConverter();

		#endregion

		#region constructor

		public ArticleImage () : base()
		{
		}
		public ArticleImage (Article Article) : this()
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
		
		#region private method

		private BindingBase GetSourceBinding ()
		{
			if (Article == null)
				return null;

			var SourceBinding = new PriorityBinding();
			SourceBinding.Bindings.Add(GetArticleBinding("ThemeThumbnail"));
			SourceBinding.Bindings.Add(GetArticleBinding("EmbeddedThumbnail"));
			SourceBinding.Bindings.Add(GetArticleBinding("ThemeIcon"));
			SourceBinding.Bindings.Add(GetArticleBinding("EmbeddedIcon"));
			SourceBinding.Bindings.Add(GetArticleBinding("DefaultIcon"));
			return SourceBinding;
		}

		private BindingBase GetArticleBinding (string Path)
		{
			return GetArticleBinding(new PropertyPath(Path));
		}
		private BindingBase GetArticleBinding (PropertyPath Path)
		{
			return new Binding
			{
				IsAsync   = true     ,
				Path      = Path     ,
				Source    = Article  ,
				Converter = Converter,
			};
		}

		#endregion

		#region event

		private static void OnArticlePropertyChanged (DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var Control = sender as ArticleImage;
			if (Control != null)
				Control.OnArticleChanged();
		}

		private void OnArticleChanged ()
		{
			var SourceBinding = GetSourceBinding();
			SetBinding(SourceProperty, SourceBinding);
		}

		#endregion

	}

}
