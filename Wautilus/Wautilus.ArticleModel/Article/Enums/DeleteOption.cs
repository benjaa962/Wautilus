
namespace Wautilus.ArticleModel
{
	
	public enum DeleteOption : ushort
	{
		SendToRecycleBin                     = 0,
		DeletePermanentlyWithoutConfirmation = 1,
		DeletePermanentlyWithConfirmation    = 2,
	}

}
