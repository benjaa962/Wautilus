namespace Wautilus.Common.Module
{

	public class ModuleInfo : IModuleInfo
	{

		#region constructor

		internal ModuleInfo ()
		{
		}

		#endregion

		#region property

		public string Author  { get; internal set; }
		public string Comment { get; internal set; }

		#endregion

	}

}
