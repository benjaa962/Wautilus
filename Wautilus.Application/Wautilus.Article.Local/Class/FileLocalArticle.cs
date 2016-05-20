using Alphaleonis.Win32.Filesystem;
using Wautilus.Common.Article;

namespace Wautilus.Article.Local
{

	public class FileLocalArticle : ILocalArticle
	{
		
		#region field

		private FileInfo Info;

		#endregion

		#region constructor

		public FileLocalArticle (string path)
		{
			Info = new FileInfo(path);
		}

		#endregion

		#region property

		public string Path => Info ?. FullName;

		#endregion

		#region public method

		public void Refresh ()
		{
			Info.Refresh();
		}

		public string GetName (ArticleNameType type)
		{
			switch (type)
			{
				case ArticleNameType.Full:  return Info.FullName;
				case ArticleNameType.Short: return Info.Name    ;
				default:                    return null         ;
			}
		}

		#endregion

	}

}
