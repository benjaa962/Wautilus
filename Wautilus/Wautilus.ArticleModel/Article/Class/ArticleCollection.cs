using System.Collections.ObjectModel;

namespace Wautilus.ArticleModel
{

	public class ArticleCollection : ObservableCollection<Article>
	{
		
		#region property

		public string Label { get; set; }
		public object Image { get; set; }
		
		#endregion

	}

}
