using System.Runtime.InteropServices;

namespace Wautilus.ArticleModel
{
	
	/// <summary>
	/// The structure specifies the width and height of a rectangle.
    /// MSDN : http://msdn.microsoft.com/en-us/library/ms532297(VS.85).aspx
    /// </summary>
	[StructLayout(LayoutKind.Sequential)]

	internal struct ShellImageSize
	{
		
		#region field

		public int X;
		public int Y;
		
		#endregion

		#region constructor

		public ShellImageSize (int X, int Y)
		{
			this.X = X;
			this.Y = Y;
		}

		#endregion

		#region public method

		public static ShellImageSize Build (int Size)
		{
			return Build(Size, Size);
		}
		public static ShellImageSize Build (int Width, int Height)
		{
			return new ShellImageSize(Width, Height);
		}

		#endregion

	}

}
