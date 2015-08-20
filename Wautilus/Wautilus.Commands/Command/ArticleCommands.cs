using System.Windows.Input;

namespace Wautilus.Commands
{

	public static class ArticleCommands
	{

		#region property

		public static RoutedUICommand Refresh => NavigationCommands.Refresh;

		public static RoutedUICommand Cut    => ApplicationCommands.Cut   ;
		public static RoutedUICommand Copy   => ApplicationCommands.Copy  ;
		public static RoutedUICommand Paste  => ApplicationCommands.Paste ;
		public static RoutedUICommand Delete => ApplicationCommands.Delete;

		public static RoutedUICommand Open       => ApplicationCommands.Open      ;
		public static RoutedUICommand Properties => ApplicationCommands.Properties;

		public static RoutedUICommand New  => ApplicationCommands.New ;
		public static RoutedUICommand Find => ApplicationCommands.Find;

		#endregion

	}

}
