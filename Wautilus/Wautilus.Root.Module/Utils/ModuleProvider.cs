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

		public void Import (params string[] CatalogPaths)
		{
			try
			{
				var catalog   = GetCatalog(CatalogPaths);
				var container = new CompositionContainer(catalog);

				var allModules = container.GetExportedValues<IModule>();
				foreach (IModule module in allModules)
				{
					var State = module.GetState();
					if (State == ModuleState.Succes)
						Modules.Add(module.Key, module);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IModule GetModule (string Key)
		{
			return GetModule<IModule>(Key);
		}
		public T GetModule<T> (string Key) where T : IModule
		{
			if (!Modules.ContainsKey(Key))
				return default(T);
			if (!(Modules[Key] is T))
				return default(T);
			return (T)Modules[Key];
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
				if (module is T)
					modules.Add((T)module.Value);
			}
			return modules;
		}

		#endregion

		#region private method

		private ComposablePartCatalog GetCatalog (string[] CatalogPaths)
		{
			var catalog = new AggregateCatalog();

			var mainCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
			catalog.Catalogs.Add(mainCatalog);

			foreach (var catalogPath in CatalogPaths)
			{
				var subCatalog = new DirectoryCatalog(catalogPath);
				catalog.Catalogs.Add(subCatalog);
			}

			return catalog;
		}

		#endregion

	}

}
