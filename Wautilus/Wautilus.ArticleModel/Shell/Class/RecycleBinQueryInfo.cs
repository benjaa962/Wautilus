using System;

namespace Wautilus.ArticleModel
{
	
	internal struct RecycleBinQueryInfo
	{
		public RecycleBinQueryInfo (Int32 cbSize, UInt64 i64Size, UInt64 i64NumItems)
		{
			this.cbSize      = cbSize     ;
			this.i64Size     = i64Size    ;
			this.i64NumItems = i64NumItems;
		}

		public Int32  cbSize     ;
		public UInt64 i64Size    ;
		public UInt64 i64NumItems;
	}

}
