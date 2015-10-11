
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;
using System.Threading;

namespace aBlist
{
	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]	
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			Thread.Sleep(10000); // Simulate a long loading process on app startup.
			StartActivity(typeof(MapActivity));
		}
	}
}

