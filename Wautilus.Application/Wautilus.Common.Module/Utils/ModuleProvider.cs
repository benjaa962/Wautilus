using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;

namespace Wautilus.Common.Module
{

	public class ModuleProvider
	{

		#region field

		private static ModuleProvider _Instance = new ModuleProvider();

		private readonly Dictionary<string, IModule> Modules = new Dictionary<string, IModule>();

		#endregion

		#region constructor

		private ModuleProvider ()
		{
		}

		#endregion

		#region property

		public static ModuleProvider Instance => _Instance;

		#endregion

		#region public method

		public void Import (params string[] catalogPaths)
		{
			try
			{
				var catalog   = GetCatalog(catalogPaths);
				var container = new CompositionContainer(catalog);

				var allModules = container.GetExportedValues<IModule>();
				foreach (IModule module in allModules)
				{
					if (!Modules.ContainsKey(module.Key))
					{
						var State = module.GetState();
						if (State == ModuleState.Succes)
							Modules.Add(module.Key, module);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IModule GetModule (string key)
		{
			return GetModule<IModule>(key);
		}
		public T GetModule<T> (string key) where T : IModule
		{
			if (!Modules.ContainsKey(key))
				return default(T);
			if (!(Modules[key] is T))
				return default(T);
			return (T)Modules[key];
		}

		public IEnumerable<IModule> GetModules ()
		{
			return GetModules<IModule>();
		}
		public IEnumerable<T> GetModules<T> () where T : IModule
		{
			var modules = new List<T>();
			foreach (var module in Modules)
			{
				if (module.Value is T)
					modules.Add((T)module.Value);
			}
			return modules;
		}

		#endregion

		#region private method

		private ComposablePartCatalog GetCatalog (string[] catalogPaths)
		{
			var catalog = new AggregateCatalog();

			var mainCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
			catalog.Catalogs.Add(mainCatalog);

			foreach (var catalogPath in catalogPaths)
			{
				var subCatalog = new DirectoryCatalog(catalogPath);
				catalog.Catalogs.Add(subCatalog);
			}

			return catalog;
		}

		#endregion

	}

}
