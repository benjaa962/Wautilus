using System;
using System.Runtime.InteropServices;

namespace Wautilus.ArticleModel
{
	
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b")]

	internal interface IShellItemImageFactory
	{
		void GetImage(
			[In, MarshalAs(UnmanagedType.Struct)] ShellImageSize size,
			[In] ShellImageType flags,
			[Out]out IntPtr phbm
		);
	}

}
