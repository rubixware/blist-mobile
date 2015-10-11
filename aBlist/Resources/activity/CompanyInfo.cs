
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace aBlist
{
	[Activity (Label = "CompanyInfo")]			
	public class CompanyInfo : Activity
	{
		private pcl.Company Company { get; set; }

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.CompanyInfo);

			this.Company = MapActivity.ItemSelectedFromListView;

			FindViewById<TextView> (Resource.Id.textViewCategory).Text =
				pcl.Mobile.SearchForName (this.Company.Id, AppDelegate.Categories);
			FindViewById<TextView> (Resource.Id.textViewTag).Text =
				this.Company.TagDesription;
			FindViewById<TextView> (Resource.Id.textViewMap).Text =
				this.Company.Street + "\n" + this.Company.Suburb + "\n" +
			this.Company.City + "\n" + this.Company.Region;
			FindViewById<TextView> (Resource.Id.textViewMail).Text = 
				this.Company.Email;
			FindViewById<TextView> (Resource.Id.textViewAbout).Text = 
				this.Company.Page;
			FindViewById<TextView> (Resource.Id.textViewCall).Text = 
				this.Company.Phone;
		}
	}
}

