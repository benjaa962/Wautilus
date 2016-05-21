using Alphaleonis.Win32.Filesystem;
using Wautilus.Common.Article;

namespace Wautilus.Article.Local
{

	public class DirectoryLocalArticle : LocalArticle
	{
		
		#region field

		private DirectoryInfo Info;

		#endregion

		#region constructor

		public DirectoryLocalArticle (string path)
		{
			Info = new DirectoryInfo(path);
		}

		#endregion

		#region property

		public override string Path => Info?.FullName;

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
				case ArticleNameType.Full : return Info.FullName;
				case ArticleNameType.Short: return Info.Name    ;
				default: return null;
			}
		}
		
		#endregion

	}

}
