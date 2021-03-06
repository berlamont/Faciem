﻿using Plugin.Connectivity;
using Xamarin.Forms;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace Faciem
{
	public class App : Application
	{
		internal static bool IsConnected;
		public App()
		{
			CrossConnectivity.Current.ConnectivityChanged += (sender, e) => { IsConnected = e.IsConnected; };
			MobileCenter.Start(typeof(Analytics), typeof(Crashes));
			MainPage = new NavigationPage(new MainPage());

		}

		protected override void OnStart()
		{
			IsConnected = CrossConnectivity.Current.IsConnected;
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			IsConnected = CrossConnectivity.Current.IsConnected;
		}
	}
}
