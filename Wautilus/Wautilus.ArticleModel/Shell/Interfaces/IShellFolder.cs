using System;
using System.Runtime.InteropServices;

namespace Wautilus.ArticleModel
{
	
	[ComImport, Guid("000214e6-0000-0000-c000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]

	internal interface IShellFolder
	{
		
		[PreserveSig]
		int ParseDisplayName (
			IntPtr hwnd,
			IntPtr pbc,
			[MarshalAs(UnmanagedType.LPWStr)] string pwszDisplayName,
			IntPtr pchEaten,
			out IntPtr ppidl,
			ShellFolderAttribute pdwAttributes
		);
		
		[PreserveSig]
		int EnumObjects (
			IntPtr hwndOwner,
			ShellFolderEnumType grfFlags,
			[MarshalAs(UnmanagedType.Interface)] out IEnumIDList ppenumIDList
		);
		
		[PreserveSig]
		int BindToObject (
			IntPtr pidl,
			IntPtr pbc,
			ref Guid riid,
			out IntPtr ppv
		);
		
		void BindToStorage (
			IntPtr pidl,
			IntPtr pbc,
			ref Guid riid,
			out IntPtr ppv
		);
		
		[PreserveSig]
		int CompareIDs (
			int lParam,
			IntPtr pidl1,
			IntPtr pidl2
		);
		
		[PreserveSig]
		int CreateViewObject (
			IntPtr hwndOwner,
			ref Guid riid,
			out IntPtr ppv
		);
		
		void GetAttributesOf (
			uint cidl,
			[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl,
			ref ShellFolderAttribute rgfInOut
		);
		
		[PreserveSig]
		int GetUIObjectOf (
			IntPtr hwndOwner,
			uint cidl,
			[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] apidl,
			ref Guid riid,
			IntPtr rgfReserved,
			out IntPtr ppv
		);
		
		[PreserveSig]
		int GetDisplayNameOf (
			IntPtr pidl,
			ShellNameType uFlags,
			IntPtr lpName
		);
		
		[PreserveSig]
		int SetNameOf (
			IntPtr hwndOwner,
			IntPtr pidl,
			[MarshalAs(UnmanagedType.LPWStr)] string lpszName,
			ShellNameType uFlags,
			ref IntPtr ppidlOut
		);

	}

}
