using System;

namespace Wautilus.ArticleModel
{
	
	[Flags]
	internal enum ShellFolderAttribute : uint
	{
		CanCopy               = 0x00000001,
		CanMove               = 0x00000002,
		CanLink               = 0x00000004,
		Storage               = 0x00000008,
		CanRename             = 0x00000010,
		CanDelete             = 0x00000020,
		HahPropertySheet      = 0x00000040,
		DropTarget            = 0x00000100,
		CapabilityMask        = 0x00000177,
		Encrypted             = 0x00002000,
		IsSlow                = 0x00004000,
		Ghosted               = 0x00008000,
		Link                  = 0x00010000,
		Share                 = 0x00020000,
		ReadOndy              = 0x00040000,
		Hidden                = 0x00080000,
		DisplayAttributeMask  = 0x000FC000,
		FileSystemAncestor    = 0x10000000,
		Folder                = 0x20000000,
		FileSystem            = 0x40000000,
		HasSubFolder          = 0x80000000,
		ContentsMask          = 0x80000000,
		Validate              = 0x01000000,
		Removable             = 0x02000000,
		Compressed            = 0x04000000,
		Browsable             = 0x08000000,
		NonEnumerated         = 0x00100000,
		NewContent            = 0x00200000,
		CanMoniker            = 0x00400000,
		HasStorage            = 0x00400000,
		Stream                = 0x00400000,
		StorageAncestor       = 0x00800000,
		StoragecapabilityMask = 0x70C50008,
	}

}
