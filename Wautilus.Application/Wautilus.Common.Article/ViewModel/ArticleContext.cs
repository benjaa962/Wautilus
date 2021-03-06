﻿using System.Collections.ObjectModel;
using System.Linq;
using Wautilus.Common.Module;
using Wautilus.Common.ViewModel;

namespace Wautilus.Common.Article
{

	public class ArticleContext : AbstractContext
	{

		#region field

		private IArticle _Article = null;

		private ArticleContext                       _Parent   = null;
		private ObservableCollection<ArticleContext> _Children = null;

		#endregion

		#region constructor

		public ArticleContext (IArticle article) : base()
		{
			Article = article;

			(Article as IObservableArticle).Changed += ArticleContext_Changed;
			(Article as IObservableArticle).Moved   += ArticleContext_Moved  ;
		}

		#endregion

		#region property

		public IArticle Article { get; private set; }

		public ArticleContext Parent
		{
			get
			{
				if (_Parent == null && Article is IChildArticle)
					_Parent = GetParent();
				return _Parent;
			}
		}
		public ObservableCollection<ArticleContext> Children
		{
			get
			{
				if (_Children == null && Article is IParentArticle)
					_Children = GetChildren();
				return _Children;
			}
		}

		public string ShortName => Article ?. GetName(ArticleNameType.Short);
		public string FullName  => Article ?. GetName(ArticleNameType.Full );

		public bool IsObservationEnabled
		{
			get
			{
				return (Article as IObservableArticle) ?. IsObservationEnabled ?? false;
			}
			set
			{
				if (Article is IObservableArticle)
					(Article as IObservableArticle).IsObservationEnabled = value;
			}
		}

		#endregion

		#region public method

		public void Refresh ()
		{
			_Parent   = null;
			_Children = null;

			(Article as IRefreshable) ?. Refresh();
		}

		#endregion
		
		#region private method

		private ArticleContext GetParent ()
		{
			var parent = (Article as IChildArticle) ?. Parent;
			return ArticleContextFactory.Build(parent);
		}
		private ObservableCollection<ArticleContext> GetChildren ()
		{
			var childrenArticle = (Article as IParentArticle) ?. Children;
			if (Children == null)
				return null;
			var childrenContext = childrenArticle.Select(child => new ArticleContext(child));
			return new ObservableCollection<ArticleContext>(childrenContext);
		}

		private void OnArticleChanged ()
		{
			OnPropertyChanged
			(
				nameof(Article)
				,nameof(Parent  )
				,nameof(Children)
				,nameof(ShortName)
				,nameof(FullName )
			);
		}

		#endregion

		#region event

		private void ArticleContext_Moved (object sender, MovedArticleEventArgs e)
		{
			OnArticleChanged();
		}

		private void ArticleContext_Changed (object sender, ArticleEventArgs e)
		{
			OnArticleChanged();
		}

		#endregion

	}

}
