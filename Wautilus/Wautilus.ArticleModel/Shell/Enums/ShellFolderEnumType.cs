using System;

namespace Wautilus.ArticleModel
{
	
	[Flags]
	internal enum ShellFolderEnumType : int
	{
		CheckingForChildren = 0x00010,
		Folders             = 0x00020,
		NonFolders          = 0x00040,
		IncludeHidden       = 0x00080,
		InitOnFirstNext     = 0x00100,
		NetPrinterSrch      = 0x00200,
		Shareable           = 0x00400,
		Storage             = 0x00800,
		NavigationEnum      = 0x01000,
		FastItems           = 0x02000,
		FlatList            = 0x04000,
		EnableAsync         = 0x08000,
		IncludeSuperHidden  = 0x10000,
	}

}
