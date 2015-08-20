using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Wautilus.BrowserControls
{

	public partial class Browser : UserControl
	{

		#region field

		private int IndexForInsertAfterCurrent = 0;

		private ObservableCollection<BrowserFrame> Frames = new ObservableCollection<BrowserFrame>();

		#endregion

		#region constructor

		public Browser () : base()
		{
			InitializeComponent();
			MainLayout.SelectionChanged += OnSelectionChanged;
			MainLayout.ItemsSource = Frames;
		}

		#endregion

		#region property

		public int          CurrentIndex =>
			MainLayout.SelectedIndex >= 0 ? MainLayout.SelectedIndex : 0;
		public BrowserFrame CurrentFrame =>
			MainLayout.SelectedIndex >= 0 ? Frames[MainLayout.SelectedIndex] : null;

		#endregion

		#region public method

		public void Navigate (object Content)
		{
			Navigate(Content, BrowserLocation.AtCurrent);
		}
		public void Navigate (object Content, BrowserLocation Location)
		{
			NavigateToContent(Content, Location);
		}
		public void Navigate (Page Page)
		{
			Navigate(Page, BrowserLocation.AtCurrent);
		}
		public void Navigate (Page Page, BrowserLocation Location)
		{
			NavigateToContent(Page, Location);
		}
		public void Navigate (BrowserPage Page)
		{
			Navigate(Page, BrowserLocation.AtCurrent);
		}
		public void Navigate (BrowserPage Page, BrowserLocation Location)
		{
			NavigateToContent(Page, Location);
		}
		public void Navigate (Uri Source)
		{
			Navigate(Source, BrowserLocation.AtCurrent);
		}
		public void Navigate (Uri Source, BrowserLocation Location)
		{
			NavigateToContent(Source, Location);
        }

		public void Close (BrowserFrame Frame)
		{
			if (Frames.Contains(Frame))
				Frames.Remove(Frame);
		}

		#endregion

		#region private method

		private void OnSelectionChanged (object sender, SelectionChangedEventArgs e)
		{
			IndexForInsertAfterCurrent = CurrentIndex;
		}

		private void NavigateToContent (object Content, BrowserLocation Location)
		{
			if (CurrentFrame != null && Location == BrowserLocation.AtCurrent)
				CurrentFrame.Navigate(Content);
			else
				OpenFrame(Content, Location);
		}
		private void OpenFrame (object Content, BrowserLocation Location)
		{
			var Index = GetIndexForInsert(Location)    ;
			var Frame = new BrowserFrame(this, Content);

			Frames.Insert(Index, Frame);
		}

		private int GetIndexForInsert (BrowserLocation Location)
		{
			switch (Location)
			{
				case BrowserLocation.AtHome:
					return 0;
				case BrowserLocation.BeforeCurrent:
				case BrowserLocation.AtCurrent:
					return CurrentIndex;
				case BrowserLocation.AfterCurrent:
					return ++IndexForInsertAfterCurrent;
				case BrowserLocation.AtEnd:
				default:
					return Frames.Count;
			}
		}
		
		#endregion

	}

}
