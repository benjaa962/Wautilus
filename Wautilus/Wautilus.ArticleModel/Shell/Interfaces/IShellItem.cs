﻿using System;
using System.Runtime.InteropServices;

namespace Wautilus.ArticleModel
{
	
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]

	internal interface IShellItem
	{
		void BindToHandler (
			IntPtr pbc,
			[MarshalAs(UnmanagedType.LPStruct)] Guid bhid,
			[MarshalAs(UnmanagedType.LPStruct)] Guid riid,
			out IntPtr ppv
		);

		void GetParent      (out IShellItem ppsi);
		void GetDisplayName (ShellNameType sigdnName, out IntPtr ppszName);
		void GetAttributes  (uint sfgaoMask, out uint psfgaoAttribs);

		void Compare (IShellItem psi, uint hint, out int piOrder);
	}

}