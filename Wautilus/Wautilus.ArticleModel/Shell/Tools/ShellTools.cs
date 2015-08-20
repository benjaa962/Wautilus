using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;

namespace Wautilus.ArticleModel
{
	
	internal static class ShellTools
	{
		
		#region const

		private const string ShellGuidID = "43826d1e-e718-42ee-bc55-a1e261c37bfe";

		private const ShellNameType DefaultNameType = ShellNameType.DesktopAbsoluteParsing;
		
		#endregion

		#region field

		private static readonly Guid Guid = new Guid(ShellGuidID);

		#endregion

		#region public method

		public static IShellItem CreateItem (string Name)
		{
			try
			{
				IShellItem Item;
				SHCreateItemFromParsingName(Name, IntPtr.Zero, Guid, out Item);
				return Item;
			}
			catch
			{
				return null;
			}
		}
		
		public static IShellItem GetParent (IShellItem Item)
		{
			try
			{
				IShellItem Parent;
				Item.GetParent(out Parent);
				return Parent;
			}
			catch
			{
				return null;
			}
		}

		public static string GetName (IShellItem Item)
		{
			return GetName(Item, DefaultNameType);
		}
		public static string GetName (IShellItem Item, ShellNameType Type)
		{
			try
			{
				IntPtr Name;
				Item.GetDisplayName(Type, out Name);
				return Marshal.PtrToStringUni(Name);
			}
			catch
			{
				return null;
			}
		}

		public static IntPtr GetImage (IShellItem Item, ShellImageType Type, ShellImageSize Size)
		{
			try
			{
				IntPtr Image;
				((IShellItemImageFactory)Item).GetImage(Size, Type, out Image);
				return Image;
			}
			catch
			{
				return IntPtr.Zero;
			}
		}
		
		public static void Move (string Source, string Target)
		{
			var Sources = new List<string>{ Source };
			Move(Sources, Target);
		}
		public static void Move (IEnumerable<string> Sources, string Target)
		{
			var Operation    = new ShFileOperationStructure();
			Operation.wFunc  = FileOperatorType.Move;
			Operation.pFrom  = GetFrom(Sources);
			Operation.pTo    = Target;
			Operation.fFlags = FileOperatorFlag.Default;
			ExecOperation(Operation);
		}

		public static void Copy (string Source, string Target)
		{
			var Sources = new List<string>{ Source };
			Copy(Sources, Target);
		}
		public static void Copy (IEnumerable<string> Sources, string Target)
		{
			var Operation    = new ShFileOperationStructure();
			Operation.wFunc  = FileOperatorType.Copy;
			Operation.pFrom  = GetFrom(Sources);
			Operation.pTo    = Target;
			Operation.fFlags = FileOperatorFlag.Default;
			ExecOperation(Operation);
		}

		public static void Delete (string Path, DeleteOption Option)
		{
			var Operation    = new ShFileOperationStructure();
			Operation.wFunc  = FileOperatorType.Delete;
			Operation.pFrom  = Path + '\0' + '\0';
			Operation.fFlags = ToFlag(Option);
			ExecOperation(Operation);
		}

		public static void OpenProperties (string Path)
		{
			const int  SwShow            =  5;
			const uint SeeMaskInvoIdList = 12;

			var Info    = new ShellExecuteInfo();
			Info.cbSize = Marshal.SizeOf(Info);
			Info.lpVerb = "properties";
			Info.lpFile = Path;
			Info.nShow  = SwShow;
			Info.fMask  = SeeMaskInvoIdList;
			ShellExecuteEx(ref Info);
		}

		#endregion
		
		#region private method

		private static void ExecOperation (ShFileOperationStructure Operation)
		{
			var Start = new ThreadStart(() =>
			{
				SHFileOperation(ref Operation);
			});
			var Thread = new Thread(Start);
			Thread.Start();
		}

		private static string GetFrom (IEnumerable<string> Paths)
		{
			var Builder = new StringBuilder();
			foreach (string Path in Paths)
				Builder.Append(Path + '\0');
			Builder.Append('\0');
			return Builder.ToString();
		}

		private static FileOperatorFlag ToFlag (DeleteOption Option)
		{
			switch (Option)
			{
				case DeleteOption.SendToRecycleBin:
					return FileOperatorFlag.AllowUndo;
				case DeleteOption.DeletePermanentlyWithoutConfirmation:
					return FileOperatorFlag.NoConfirmation;
				case DeleteOption.DeletePermanentlyWithConfirmation:
				default:
					return FileOperatorFlag.Default;
			}
		}

		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		private static extern bool ShellExecuteEx (ref ShellExecuteInfo lpExecInfo);

		[DllImport("shell32.dll", CharSet = CharSet.Unicode)]
		private static extern int SHFileOperation([In] ref ShFileOperationStructure lpFileOp);
		[DllImport("shell32.dll", CharSet = CharSet.Unicode)]
		public static extern object NameSpace ([In] int n);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
		private static extern void SHCreateItemFromParsingName (
			[In][MarshalAs(UnmanagedType.LPWStr)] string pszPath,
			[In] IntPtr pbc,
			[In][MarshalAs(UnmanagedType.LPStruct)] Guid riid,
			[Out][MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out IShellItem ppv
		);
		
		#endregion

	}

}
