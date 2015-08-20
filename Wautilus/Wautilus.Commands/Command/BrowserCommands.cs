using System.Windows.Input;

namespace Wautilus.ViewModel
{

	public static class BrowserCommands
	{

		#region constructor

		static BrowserCommands()
		{
			SelectNone = new RoutedUICommand
			{
				Text = "Déselectionner"
			};

			SelectReverse = new RoutedUICommand
			{
				Text = "Inverser la sélection"
			};
		}

		#endregion

		#region property

		public static RoutedUICommand Refresh => NavigationCommands.Refresh;

		public static RoutedUICommand Undo => ApplicationCommands.Undo;
		public static RoutedUICommand Redo => ApplicationCommands.Redo;

		public static RoutedUICommand Open  => ApplicationCommands.Open;
		public static RoutedUICommand Close => ApplicationCommands.Close;
		public static RoutedUICommand OpenInNewTab { get; } = new RoutedUICommand { Text = "Ouvrir dans un nouvel onglet"};

		public static RoutedUICommand SelectNone    { get; } = new RoutedUICommand { Text = "Ne rien sélectionner"  };
        public static RoutedUICommand SelectAll     { get; } = new RoutedUICommand { Text = "Tout sélectionner"     };
		public static RoutedUICommand SelectReverse { get; } = new RoutedUICommand { Text = "Inverser la sélection" };

		public static RoutedUICommand BrowseHome    => NavigationCommands.BrowseHome;
		public static RoutedUICommand BrowseBack    => NavigationCommands.BrowseBack;
		public static RoutedUICommand BrowseForward => NavigationCommands.BrowseForward;

		#endregion

	}

}
