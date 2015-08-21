using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Wautilus.BrowserControls
{

	public class BrowserFrame : Frame
	{

		#region constructor

		internal BrowserFrame () : base()
		{
			LoadCompleted         += OnLoadCompleted;
			NavigationUIVisibility = NavigationUIVisibility.Hidden;
		}
		internal BrowserFrame (object Content) : this(null, Content)
		{
		}
		internal BrowserFrame (Uri Source) : this(null, Source)
		{
		}
		internal BrowserFrame (Page Page) : this(null, Page)
		{
		}
		internal BrowserFrame (BrowserPage Page) : this(null, Page)
		{
		}

		internal BrowserFrame (Browser Browser) : this()
		{
			this.Browser = Browser;
		}
		internal BrowserFrame (Browser Browser, object Content) : this(Browser)
		{
			Navigate(Content);
		}
		internal BrowserFrame (Browser Browser, Uri Source) : this(Browser)
		{
			Navigate(Source);
		}
		internal BrowserFrame (Browser Browser, Page Page) : this(Browser)
		{
			Navigate(Page);
		}
		internal BrowserFrame (Browser Browser, BrowserPage Page) : this(Browser)
		{
			Navigate(Page);
		}

		#endregion

		#region property

		public Browser Browser { get; internal set; }

		#endregion
		
		#region private method

		private void OnLoadCompleted (object sender, NavigationEventArgs e)
		{
			var Page = e.Content as BrowserPage;
			if (Page != null)
			{
				Page.Frame = this;
				Page.Refresh();
			}
		}

		#endregion

	}

}
