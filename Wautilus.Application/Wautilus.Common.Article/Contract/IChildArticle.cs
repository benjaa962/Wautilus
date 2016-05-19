namespace Wautilus.Common.Article
{

	public interface IChildArticle : IArticle
	{

		IArticle Parent { get; }

	}

}
