using System.Windows;
using Wautilus.Common.Module;

namespace Wautilus.Application
{

	public partial class App : System.Windows.Application
	{

		#region protected method

		protected override void OnStartup (StartupEventArgs e)
		{
			base.OnStartup(e);
			InitializeModules();
		}

		#endregion

		#region private method

		private void InitializeModules ()
		{
			var Provider = ModuleProvider.Instance;
			Provider.Import(Constant.ModulePaths);
		}

		#endregion

	}

}
