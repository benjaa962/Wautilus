using Alphaleonis.Win32.Filesystem;
using System;
using Wautilus.Common.Article;

namespace Wautilus.Article.LocalArticle
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
			Reference = GetReference();
		}

		#endregion

		#region property

		public string Path => Info ?. FullName;

		public Uri Reference { get; private set; }

		#endregion

		#region public method

		public void Refresh ()
		{
			Info.Refresh();
			Reference = GetReference();
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

		#region private method

		private Uri GetReference ()
		{
			return ArticleProvider.GetReference(Constant.Key, Path);
		}

		#endregion

	}

}
