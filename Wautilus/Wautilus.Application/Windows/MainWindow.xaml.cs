using System;
using System.Windows;
using Wautilus.Common.Module;

namespace Wautilus.Application
{

	public partial class MainWindow : Window
	{

		#region constructor

		public MainWindow ()
		{
			InitializeComponent();

			var Provider = ModuleProvider.Instance;
			Provider.Import();
			var Test = Provider.GetModule<TestModule>("Test");

			var a = new Uri("local://test/ici?hahaha");
		}

		#endregion

	}

}
