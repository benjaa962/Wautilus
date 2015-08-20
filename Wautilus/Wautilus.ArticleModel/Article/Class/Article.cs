using System;

namespace Wautilus.ArticleModel
{

	public abstract class Article
	{
		
		#region constructor

		public Article () : base()
		{
		}

		#endregion

		#region property

		public abstract bool Exists { get; }

		public string Extension                 => GetName(ArticleNameType.Extension                );
		public string ShortName                 => GetName(ArticleNameType.ShortName                );
		public string ShortNameWithoutExtension => GetName(ArticleNameType.ShortNameWithoutExtension);
		public string FullName                  => GetName(ArticleNameType.FullName                 );
		public string FullNameWithoutExtension  => GetName(ArticleNameType.FullNameWithoutExtension );
		public string Label                     => GetName(ArticleNameType.Label                    );

		public DateTime CreationTime   => GetTime(ArticleTimeType.Creation  );
		public DateTime LastWriteTime  => GetTime(ArticleTimeType.LastWrite );
		public DateTime LastAccessTime => GetTime(ArticleTimeType.LastAccess);

		public object DefaultIcon       => GetImage(ArticleImageType.DefaultIcon      );
		public object EmbeddedIcon      => GetImage(ArticleImageType.EmbeddedIcon     );
		public object EmbeddedThumbnail => GetImage(ArticleImageType.EmbeddedThumbnail);
		public object ThemeIcon         => GetImage(ArticleImageType.ThemeIcon        );
		public object ThemeThumbnail    => GetImage(ArticleImageType.ThemeThumbnail   );

		#endregion

		#region public method

		public virtual void Refresh ()
		{
		}

		public abstract string   GetName  (ArticleNameType  Type);
		public abstract DateTime GetTime  (ArticleTimeType  Type);
		public abstract object   GetImage (ArticleImageType Type);

		#endregion

	}

}
