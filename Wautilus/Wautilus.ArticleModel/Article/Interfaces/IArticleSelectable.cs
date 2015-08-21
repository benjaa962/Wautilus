
namespace Wautilus.ArticleModel
{

	public interface IArticleSelectable
	{

		Article           SelectedArticle  { get; }
		ArticleCollection SelectedArticles { get; }

	}

}
