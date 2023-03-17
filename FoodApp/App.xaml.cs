﻿using FoodApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new NavigationPage(new SettingsPage()); //For Admin
			
			string uname = Preferences.Get("Username", String.Empty);
			if (String.IsNullOrEmpty(uname))
			{
				MainPage = new LogInView();
			}
			else
			{
				MainPage = new ProductsView();
			}
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
