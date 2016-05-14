namespace Wautilus.Common.Module
{

	public interface IModule
	{
		
		#region property

		string Key     { get; }
		string Version { get; }

		IModuleInfo Info { get; }

		#endregion

		#region public method

		ModuleState GetState ();

		#endregion

	}

}
