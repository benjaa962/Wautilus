using System.IO;

namespace Wautilus.ArticleModel
{

	public class DriveArticle : DirectoryArticle
	{
		
		#region field

		private DriveInfo Info;

		#endregion

		#region constructor

		public DriveArticle (string Path) : base(Path)
		{
			Info = new DriveInfo(Path);
		}

		#endregion

		#region property

		public bool      IsReady   => Info.IsReady  ;
		public DriveType DriveType => Info.DriveType;

		public long FreeSize  => GetSize(DriveSizeType.Free );
		public long UsedSize  => GetSize(DriveSizeType.Used );
		public long TotalSize => GetSize(DriveSizeType.Total);

		#endregion
		
		#region public method

		public long GetSize (DriveSizeType Type)
		{
			if (!Exists)
				return 0;

			switch (Type)
			{
				case DriveSizeType.Free:
					return Info.TotalFreeSpace;
				case DriveSizeType.Used:
					return Info.TotalSize - Info.TotalFreeSpace;
				case DriveSizeType.Total:
					return Info.TotalSize;
				default:
					return TotalSize;
			}
		}

		#endregion

	}

}
