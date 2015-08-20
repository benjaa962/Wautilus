
namespace Wautilus.ArticleModel
{
	
	/// <summary>
	/// Requests the form of an item's display name to retrieve through IShellItem::GetDisplayName and SHGetNameFromIDList.
	/// MSDN : http://msdn.microsoft.com/en-us/library/bb762544(VS.85).aspx
	/// </summary>

	internal enum ShellNameType : uint
	{
		NormalDisplay               = 0x00000000,
		ParentRelativeParsing       = 0x80018001,
		DesktopAbsoluteParsing      = 0x80028000,
		ParentRelativeEditing       = 0x80031001,
		DesktopAbsoluteEditing      = 0x8004c000,
		FileSysPath                 = 0x80058000,
		Url                         = 0x80068000,
		ParentRelativeForAddressBar = 0x8007c001,
		ParentRelative              = 0x80080001,
		ParentRelativeforUI         = 0x80094001,
	}

}
