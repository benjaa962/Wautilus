﻿using System.Windows;
using Wautilus.ArticleModel;

namespace Wautilus
{

	public partial class MainWindow : Window
	{
		
		#region constructor

		public MainWindow ()
		{
			InitializeComponent();

			var Parameter = new ArticlesBuilderParameter
			{
				IncludeFiles       = true ,
                IncludeDirectories = false,
				RootPath =  @"C:\Home",
			};
			var Articles = ArticleBuilder.BuildCollection(Parameter);
			Test.Articles = Articles;
        }
		
		#endregion

	}

}
