using System.Windows;
using Wautilus.BrowserControls;

namespace Wautilus
{

	public partial class MainWindow : Window
	{
		
		#region constructor

		public MainWindow () : base()
		{
			InitializeComponent();

			MainBrowser.Navigate("Coucou");
			MainBrowser.Navigate("Salut", BrowserLocation.AfterCurrent);

		}

		#endregion

	}

}
