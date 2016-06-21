using System;
using System.ComponentModel;

namespace Wautilus.Common.ViewModel
{

	public abstract class AbstractContext : INotifyPropertyChanged
	{
		
		#region static

		public static event PropertyChangedEventHandler StaticPropertyChanged;

		protected static void OnStaticPropertyChanged (Type Type, params string[] PropertyNames)
		{
			if (StaticPropertyChanged != null && PropertyNames != null)
				foreach (string PropertyName in PropertyNames)
					if (!string.IsNullOrEmpty(PropertyName))
						StaticPropertyChanged(Type, new PropertyChangedEventArgs(PropertyName));
		}

		#endregion
		
		#region instance

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged (params string[] PropertyNames)
		{
			if (PropertyChanged != null && PropertyNames != null)
				foreach (string PropertyName in PropertyNames)
					if (!string.IsNullOrEmpty(PropertyName))
						PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
		}

		#endregion

	}

}
