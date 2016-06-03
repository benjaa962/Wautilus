using Alphaleonis.Win32.Filesystem;
using Wautilus.Common.Article;

namespace Wautilus.Article.Local
{

	public class FileLocalArticle : LocalArticle
	{
		
		#region field

		private FileInfo Info;

		#endregion

		#region constructor

		public FileLocalArticle (string path)
		{
			Info = new FileInfo(path);
		}
		internal FileLocalArticle (FileInfo info)
		{
			Info = info;
		}

		#endregion

		#region property

		public override string Path => Info ?. FullName;

		#endregion

		#region public method

		public override void Refresh ()
		{
			Info.Refresh();
		}

		public override string GetName (ArticleNameType type)
		{
			switch (type)
			{
				case ArticleNameType.Full:  return Info.FullName;
				case ArticleNameType.Short: return Info.Name    ;
				default:                    return null         ;
			}
		}

		#endregion
		
		#region protected method

		public override LocalArticle GetParent ()
		{
			return LocalArticleFactory.GetArticle(Info?.Directory);
		}

		#endregion

	}

}
