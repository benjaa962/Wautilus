using System;
using System.Runtime.InteropServices;

namespace Wautilus.ArticleModel
{

	internal struct ShFileOperationStructure
	{
		public IntPtr hwnd;
		
		public FileOperatorType wFunc;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string pFrom;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pTo;
		
		public FileOperatorFlag fFlags;
		
		public bool fAnyOperationsAborted;
		
		public IntPtr hNameMappings;
		
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpszProgressTitle;
	}

}
