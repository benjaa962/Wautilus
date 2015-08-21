using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace Wautilus.BrowserControls
{

	public abstract class NotifiableControl : Control, INotifyPropertyChanged
	{

		#region field

		public static event PropertyChangedEventHandler StaticPropertyChanged;
		public        event PropertyChangedEventHandler       PropertyChanged;

		#endregion

		#region constructor

		public NotifiableControl () : base()
		{
		}

		#endregion

		#region protected method

		protected static void OnStaticPropertyChanged (Type Type, params string[] PropertyNames)
		{
			if (PropertyNames != null)
				foreach (string PropertyName in PropertyNames)
					if (!string.IsNullOrEmpty(PropertyName) && StaticPropertyChanged != null)
						StaticPropertyChanged(Type, new PropertyChangedEventArgs(PropertyName));
		}

		protected void OnPropertyChanged (params string[] PropertyNames)
		{
			if (PropertyNames != null)
				foreach (string PropertyName in PropertyNames)
					if (!string.IsNullOrEmpty(PropertyName) && PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
		}

		#endregion

	}

}
