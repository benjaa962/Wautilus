using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Wautilus.BrowserControls
{

	public class Browser : Control
	{

		#region const

		private const BrowserLocation DefaultLocation = BrowserLocation.AtCurrent;

		#endregion

		#region field

		public static readonly DependencyProperty HeaderBarVisibilityProperty = DependencyProperty.Register(
			"HeaderBarVisibility", typeof(BrowserHeaderBarVisibility), typeof(Browser),
			new PropertyMetadata(BrowserHeaderBarVisibility.Visible, OnHeaderBarVisibilityPropertyChanged)
		);

		private int IndexForInsertAfterCurrent            = 0;
		private ObservableCollection<BrowserFrame> Frames = new ObservableCollection<BrowserFrame>();

		private TabControl MainLayout;

		#endregion

		#region constructor

		static Browser ()
		{
			var Type     = typeof(Browser)                    ;
			var MetaData = new FrameworkPropertyMetadata(Type);
			DefaultStyleKeyProperty.OverrideMetadata(Type, MetaData);
		}

		public Browser() : base()
		{
			ApplyHeaderBarVisibility();
            Frames.CollectionChanged += OnFramesCollectionChanged;
		}

		#endregion

		#region property

		public int Count => Frames.Count;

		public int          CurrentIndex => MainLayout?.SelectedIndex ?? -1                ;
		public BrowserFrame CurrentFrame => CurrentIndex >= 0 ? Frames[CurrentIndex] : null;

		public BrowserHeaderBarVisibility HeaderBarVisibility
		{
			get { return (BrowserHeaderBarVisibility)GetValue(HeaderBarVisibilityProperty); }
			set { SetValue(HeaderBarVisibilityProperty, value); }
		}

		private bool HasHeaderBar { get; set; } = true;

		#endregion

		#region public method

		public void Navigate (object Content)
		{
			Navigate(Content, DefaultLocation);
		}
		public void Navigate (object Content, BrowserLocation Location)
		{
			Navigate<object>(Content, Location);
		}
		public void Navigate (Uri Source)
		{
			Navigate(Source, DefaultLocation);
		}
		public void Navigate (Uri Source, BrowserLocation Location)
		{
			Navigate<Uri>(Source, Location);
		}
		public void Navigate (Page Page)
		{
			Navigate(Page, DefaultLocation);
		}
		public void Navigate (Page Page, BrowserLocation Location)
		{
			Navigate<Page>(Page, Location);
		}
		public void Navigate (BrowserPage Page)
		{
			Navigate(Page, DefaultLocation);
		}
		public void Navigate (BrowserPage Page, BrowserLocation Location)
		{
			Navigate<BrowserPage>(Page, Location);
		}

		public void Close (int Index)
		{
			if (Index >= 0 && Index < Frames.Count)
				Frames.RemoveAt(Index);
		}
		public void Close (BrowserFrame Frame)
		{
			if (Frames.Contains(Frame))
				Frames.Remove(Frame);
		}

		public override void OnApplyTemplate ()
		{
			base.OnApplyTemplate();
			MainLayout = Template.FindName("MainLayout", this) as TabControl;
			
			MainLayout.ItemsSource       = Frames            ;
			MainLayout.SelectionChanged += OnSelectionChanged;

			ApplyHeaderBarVisibility();
        }

		#endregion

		#region private method

		private void Navigate<T> (T Content, BrowserLocation Location)
		{
			if (CurrentFrame != null && Location == BrowserLocation.AtCurrent)
				CurrentFrame.Navigate(Content);
			else
				OpenFrame(Content, Location);
		}

		private void OpenFrame<T> (T Content, BrowserLocation Location)
		{
			var Index = GetIndexForInsert(Location);
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
					return Math.Max(0, CurrentIndex);
				case BrowserLocation.AfterCurrent:
					return ++IndexForInsertAfterCurrent;
				case BrowserLocation.AtEnd:
				default:
					return Frames.Count;
			}
		}

		private void ApplyHeaderBarVisibility ()
		{
			HasHeaderBar = HeaderBarVisibility == BrowserHeaderBarVisibility.Visible
				|| (HeaderBarVisibility == BrowserHeaderBarVisibility.Auto && Count > 1);
		}

		private static void OnHeaderBarVisibilityPropertyChanged (DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var Control = sender as Browser;
			if (Control != null)
				Control.ApplyHeaderBarVisibility();
        }

		private void OnFramesCollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
		{
			ApplyHeaderBarVisibility();
        }

		private void OnSelectionChanged (object sender, SelectionChangedEventArgs e)
		{
			IndexForInsertAfterCurrent = CurrentIndex;
		}

		#endregion

	}

}
