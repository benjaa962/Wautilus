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
			//MainBrowser.Navigate("Salut", BrowserLocation.AfterCurrent);
			MainBrowser.HeaderBarVisibility = BrowserHeaderBarVisibility.Auto;

		}

		#endregion

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MainBrowser.Navigate("Salut", BrowserLocation.AfterCurrent);
			/*if (MainBrowser.HeaderBarVisibility == BrowserHeaderBarVisibility.Visible)
				MainBrowser.HeaderBarVisibility = BrowserHeaderBarVisibility.Hidden;
			else
				MainBrowser.HeaderBarVisibility = BrowserHeaderBarVisibility.Visible;*/
        }
	}

}
