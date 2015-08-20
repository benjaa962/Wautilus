using System;

namespace Wautilus.ArticleModel
{
	
	[Flags]
	internal enum ShellImageType : int
	{
		ResizeToFit   = 0x00000,
		BiggerSizeOk  = 0x00001,
		MemoryOnly    = 0x00002,
		IconOnly      = 0x00004,
		ThumbnailOnly = 0x00008,
		InCacheOnly   = 0x00010,
	}

}
