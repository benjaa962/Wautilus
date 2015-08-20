using System.Runtime.InteropServices;
using System.Text;

namespace Wautilus.ArticleModel
{

	public static class SizeTools
	{

		#region const

		private const SizeTextType DefaultTextType = SizeTextType.Unit;

		private const int BufferSize = 64;

		private const string PercentFormat = @"{0:P0}";

		#endregion

		#region public method

		public static bool IsValid (long Size)
		{
			return Size >= 0;
		}

		public static string GetByteText (long Size)
		{
			return GetUnitText(Size);
		}

		public static string GetUnitText (long Size)
		{
			if (!IsValid(Size))
				return null;
			var Builder = new StringBuilder();
			StrFormatByteSize(Size, Builder, BufferSize);
			return Builder.ToString();
		}

		public static string GetPercentText (long Size, long Total)
		{
			if (Size < 0 || Total <= 0)
				return null;

			var Percent = 1d * Size / Total;
			return string.Format(PercentFormat, Percent);
		}

		public static string GetText (long Size, SizeTextType Type)
		{
			return GetText(Size, Size, Type);
		}
        public static string GetText (long Size, long Total, SizeTextType Type)
		{
			switch (Type)
			{
				case SizeTextType.Byte:
					return GetByteText(Size);
				case SizeTextType.Unit:
					return GetUnitText(Size);
				case SizeTextType.Percent:
					return GetPercentText(Size, Total);
				case SizeTextType.Default:
				default:
					return GetText(Size, Total, DefaultTextType);
			}
		}

		#endregion

		#region private method

		[DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
		private static extern long StrFormatByteSize
		(
			long fileSize,
			[MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer,
			int bufferSize
		);

		#endregion

	}

}
