using System;

namespace Wautilus.ArticleModel
{
	
	[Flags]
	internal enum FileOperatorType : ushort
	{
		Move   = 0x0001,
		Copy   = 0x0002,
		Delete = 0x0003,
		Rename = 0x0004,
	}

}
