using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Wautilus.BrowserControls
{

	public class BrowserFrame : Frame
	{

		#region constructor

		public BrowserFrame (Browser Browser) : base()
		{
			this.Browser           = Browser                      ;
			LoadCompleted         += OnLoadCompleted              ;
			NavigationUIVisibility = NavigationUIVisibility.Hidden;

        }
		public BrowserFrame (Browser Browser, object Content) : this(Browser)
		{
			Navigate(Content);
		}
		public BrowserFrame (Browser Browser, Page Page) : this(Browser)
		{
			Navigate(Page);
		}
		public BrowserFrame (Browser Browser, BrowserPage Page) : this(Browser)
		{
			Navigate(Page);
		}
		public BrowserFrame (Browser Browser, Uri Source) : this(Browser)
		{
			Navigate(Source);
		}

		#endregion

		#region property

		public Browser Browser { get; }

		#endregion

		#region private method

		private void OnLoadCompleted (object sender, NavigationEventArgs e)
		{
			var Page = e.Content as BrowserPage;
			if (Page != null)
				Page.Frame = this;
		}
		
		#endregion

	}

}
