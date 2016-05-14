namespace Wautilus.Common.Module
{

	public class ModuleInfoBuilder
	{

		#region property

		public string Author  { get; set; }
		public string Comment { get; set; }

		#endregion

		#region public method

		public ModuleInfo Build ()
		{
			return new ModuleInfo
			{
				Author  = Author ,
				Comment = Comment,
			};
		}

		#endregion

	}

}
