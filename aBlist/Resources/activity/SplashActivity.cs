
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
			//Thread.Sleep(10000); // Simulate a long loading process on app startup.

			ThreadPool.QueueUserWorkItem (delegate {
				try {
					// Tags
					AppDelegate.Tags = pcl.Tag.RequestData ();
					Console.WriteLine ("count {0}", AppDelegate.Tags.Count);

					// Categories
					AppDelegate.Categories = pcl.Category.Categories;

					// Companies
					AppDelegate.Companies = pcl.Company.RequestData ();
					Console.WriteLine ("count {0}", AppDelegate.Companies.Count);

					RunOnUiThread (delegate {
						StartActivity(typeof(MapActivity));
					});
				} catch (Exception ex) {
					Console.WriteLine (ex.Message);
				}
			});
		}
	}
}

