using System;
using System.Windows.Controls;

namespace Wautilus.BrowserControls
{

	public abstract class BrowserPage : Page
	{

		#region constructor

		public BrowserPage () : base()
		{
		}

		#endregion

		#region property

		public Browser Browser => Frame ?. Browser;

		public BrowserFrame Frame { get; internal set; }

		#endregion

		#region public method

		public virtual void Refresh ()
		{
		}

		public void Navigate (object Content)
		{
			Navigate(Content, BrowserLocation.AtCurrent);
		}
		public void Navigate (object Content, BrowserLocation Location)
		{
			Browser ?. Navigate(Content, Location);
		}
		public void Navigate (Page Page)
		{
			Navigate(Page, BrowserLocation.AtCurrent);
		}
		public void Navigate (Page Page, BrowserLocation Location)
		{
			Browser ?. Navigate (Page, Location);
		}
		public void Navigate (BrowserPage Page)
		{
			Navigate(Page, BrowserLocation.AtCurrent);
		}
		public void Navigate (BrowserPage Page, BrowserLocation Location)
		{
			Browser ?. Navigate(Page, Location);
		}
		public void Navigate (Uri Source)
		{
			Navigate(Source, BrowserLocation.AtCurrent);
		}
		public void Navigate (Uri Source, BrowserLocation Location)
		{
			Browser ?. Navigate(Source, Location);
		}

		#endregion

	}

}
