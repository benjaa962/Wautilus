using System;
using System.Windows;
using Wautilus.Common.Article;
using Wautilus.Common.Module;

namespace Wautilus.Application
{

	public partial class MainWindow : Window
	{

		#region constructor

		public MainWindow ()
		{
			InitializeComponent();

			ModuleProvider.Instance.Import(".");

			string path = @"test";
			Uri reference = ArticleProvider.GetReference("local", path);

			var Provider = ArticleProvider.Instance;
			var a = Provider.GetArticle(reference);
		}

		#endregion

	}

}
