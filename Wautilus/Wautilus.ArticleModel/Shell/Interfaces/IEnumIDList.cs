using System;
using System.Runtime.InteropServices;

namespace Wautilus.ArticleModel
{
	
	[ComImport, Guid("000214f2-0000-0000-c000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]

	internal interface IEnumIDList
	{
		[PreserveSig]
		int Next (uint celt, out IntPtr rgelt, out int pceltFetched);

		void Skip  (uint celt);
		void Reset ();
		void Clone (out IEnumIDList ppenum);
	}

}
