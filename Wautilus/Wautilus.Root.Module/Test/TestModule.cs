using Wautilus.Common.Module;

namespace Wautilus.Application
{

	[ModuleExport(TestConstant.Key, TestConstant.Version)]
	public class TestModule : IModule
	{

		#region property

		public string Key     { get; } = TestConstant.Key    ;
		public string Version { get; } = TestConstant.Version;

		public IModuleInfo Info { get; } = GetInfo();

		#endregion

		#region public method

		public ModuleState GetState ()
		{
			return ModuleState.Succes;
		}

		#endregion

		#region private method

		private static IModuleInfo GetInfo ()
		{
			var builder = new ModuleInfoBuilder
			{
				Author  = TestConstant.Author ,
				Comment = TestConstant.Comment,
			};
			
			return builder.Build();
		}

		#endregion

	}

}
