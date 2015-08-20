using System.Windows.Input;

namespace Wautilus.Commands
{

	public static class Commands
	{

		#region property

		public static RoutedUICommand OpenInNewTab { get; } = new RoutedUICommand { Text = "Ouvrir dans un nouvel onglet" };

		public static RoutedUICommand SelectNone    { get; } = new RoutedUICommand { Text = "Ne rien sélectionner" };
		public static RoutedUICommand SelectAll     { get; } = new RoutedUICommand { Text = "Tout sélectionner" };
		public static RoutedUICommand SelectReverse { get; } = new RoutedUICommand { Text = "Inverser la sélection" };

		#endregion

	}

}
