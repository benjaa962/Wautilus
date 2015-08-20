using System;

namespace Wautilus.ArticleModel
{
	
	[Flags]
	internal enum FileOperatorFlag : ushort
	{
		Default                     = 0x0000,
		MultipleDestinationFiles    = 0x0001,
		ConfirmMouse                = 0x0002,
		Silent                      = 0x0004,
		RenameOnCollision           = 0x0008,
		NoConfirmation              = 0x0010,
		WantMappingHandle           = 0x0020,
		AllowUndo                   = 0x0040,
		FilesOnly                   = 0x0080,
		SimpleProgress              = 0x0100,
		NoConfirmCreateNewDirectory = 0x0200,
		NoErrorUI                   = 0x0400,
		NoCopySecurityAttributes    = 0x0800,
		NoRecursion                 = 0x1000,
		NoConnectedElements         = 0x2000,
		WantNukeWarning             = 0x4000,
		NoRecurseReparse            = 0x8000,
	}

}
