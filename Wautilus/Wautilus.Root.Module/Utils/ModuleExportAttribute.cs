using System;
using System.ComponentModel.Composition;

namespace Wautilus.Common.Module
{

	[MetadataAttribute]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class ModuleExportAttribute : ExportAttribute
	{

		#region constructor

		public ModuleExportAttribute (string key, string version) : base(typeof(IModule))
		{
			Key     = key    ;
			Version = version;
		}

		#endregion

		#region property

		public string Key     { get; private set; }
		public string Version { get; private set; }

		#endregion

	}

}
