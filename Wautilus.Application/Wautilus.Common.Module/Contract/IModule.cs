namespace Wautilus.Common.Module
{

	public interface IModule
	{
		
		string Key     { get; }
		string Version { get; }

		IModuleInfo Info { get; }

		ModuleState GetState ();

	}

}
