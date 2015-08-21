using System.Windows.Input;

namespace Wautilus.BrowserControls
{

	public static class BrowserCommands
	{

		#region contructor

		static BrowserCommands ()
		{
			OpenInNewTab.Text = @"Ouvrir dans un nouvel onglet";

			SelectNone   .Text = @"Ne rien sélectionner" ;
			SelectAll    .Text = @"Tout sélectionner"    ;
			SelectReverse.Text = @"Inverser la sélection";

			var SelectAllGesture = new KeyGesture(Key.A, ModifierKeys.Control);
			SelectAll.InputGestures.Add(SelectAllGesture);
		}

		#endregion

		#region property

		public static RoutedUICommand OpenInNewTab { get; } = new RoutedUICommand();

		public static RoutedUICommand SelectNone    { get; } = new RoutedUICommand();
		public static RoutedUICommand SelectAll     { get; } = new RoutedUICommand();
		public static RoutedUICommand SelectReverse { get; } = new RoutedUICommand();

		#endregion

	}

}
