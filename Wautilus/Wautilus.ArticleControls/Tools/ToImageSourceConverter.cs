using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Wautilus.ArticleModel;

namespace Wautilus.ArticleControls
{

	public class ToImageSourceConverter : IValueConverter
	{
		
		#region const

		private const ushort           DefaultResult    = 0;
		private const ArticleImageType DefaultImageType = ArticleImageType.EmbeddedIcon;

		#endregion

		#region IValueConverter

		public object Convert (object Value, Type TargetType, object Parameter, CultureInfo Culture)
		{
			if (Value is string)
				return Convert((string)Value);
			if (Value is IntPtr)
				return Convert((IntPtr)Value);
			if (Value is byte[])
				return Convert((byte[])Value);
			if (Value is Uri)
				return Convert((Uri)Value);
			if (Value is Icon)
				return Convert((Icon)Value);
			return DefaultResult;
		}

		public object ConvertBack (object Value, Type TargetType, object Parameter, CultureInfo Culture)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Convert
		
		public object Convert (string Value)
		{
			var Path = new Uri(Value);
			return Convert(Path);
		}

		public object Convert (IntPtr Value)
		{
			if (Value == IntPtr.Zero)
				return DefaultResult;
			return Imaging.CreateBitmapSourceFromHBitmap(
				Value,
				IntPtr.Zero,
				Int32Rect.Empty,
				BitmapSizeOptions.FromEmptyOptions()
			);
		}
		
		public object Convert (byte[] Value)
		{
			var Image  = new BitmapImage();
			var Stream = new MemoryStream(Value);

			Image.BeginInit();
			Image.StreamSource = Stream;
			Image.EndInit();

			return Image;
		}
		
		public object Convert (Uri Value)
		{
			return new BitmapImage(Value);
		}
		
		public object Convert (Icon Value)
		{
			IntPtr Image = Value.ToBitmap().GetHbitmap();
			var Size     = GetSizeOptions(Value);

			var a = Imaging.CreateBitmapSourceFromHBitmap
			(
				Image,
				IntPtr.Zero,
				Int32Rect.Empty,
				Size
			);
			return a;
		}

		#endregion
		
		#region private method

		private BitmapSizeOptions GetSizeOptions (Icon Icon)
		{
			return GetSizeOptions(Icon.Width, Icon.Height);
		}
		private BitmapSizeOptions GetSizeOptions (int Width, int Height)
		{
			return BitmapSizeOptions.FromWidthAndHeight(Width, Height);
		}

		#endregion
		
	}

}
