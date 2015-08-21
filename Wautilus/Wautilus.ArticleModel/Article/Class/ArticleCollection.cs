using System.Collections;
using System.Collections.ObjectModel;

namespace Wautilus.ArticleModel
{

	public class ArticleCollection : ObservableCollection<Article>
	{

		#region constructor

		public ArticleCollection () : base()
		{

		}
		public ArticleCollection (IList List) : this()
		{
			foreach (var Item in List)
				if (Item is Article)
					Add(Item as Article);
		}

		#endregion


		#region property

		public Article AloneArticle => Count == 1 ? this[0] : null;

		public string Label { get; set; }
		public object Image { get; set; }
		
		#endregion

	}

}
