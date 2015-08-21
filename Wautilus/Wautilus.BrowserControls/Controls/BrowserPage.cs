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

		#endregion

		#region protected method

		protected void Navigate (object Content)
		{
			Browser ?. Navigate(Content);
		}
		protected void Navigate (object Content, BrowserLocation Location)
		{
			Browser ?. Navigate(Content, Location);
		}
		protected void Navigate (Uri Source)
		{
			Browser ?. Navigate(Source);
		}
		protected void Navigate (Uri Source, BrowserLocation Location)
		{
			Browser ?. Navigate(Source, Location);
		}
		protected void Navigate (Page Page)
		{
			Browser ?. Navigate(Page);
		}
		protected void Navigate (Page Page, BrowserLocation Location)
		{
			Browser ?. Navigate(Page, Location);
		}
		protected void Navigate (BrowserPage Page)
		{
			Browser ?. Navigate(Page);
		}
		protected void Navigate (BrowserPage Page, BrowserLocation Location)
		{
			Browser ?. Navigate(Page, Location);
		}

		#endregion

	}

}
