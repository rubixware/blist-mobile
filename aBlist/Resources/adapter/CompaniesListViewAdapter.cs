using System;
using System.Threading;
using ModernHttpClient;

namespace aBlist
{
	public class CompaniesListViewAdapter :  Android.Widget.BaseAdapter<string>
	{
		
		public CompaniesListViewAdapter (Android.App.Activity context, System.Collections.Generic.List<pcl.IMobile> items)
		{
			this.context = context;
			this.items = items;
		}

		protected Android.App.Activity context;
		protected System.Collections.Generic.List<pcl.IMobile> items;

		public override int Count {
			get {
				return items.Count;
			}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override string this[int index] {
			get {
				return items [index].Title;
			}
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			Android.Views.View view = convertView;
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.ListViewRowCompany, null);
			view.FindViewById<Android.Widget.TextView> (Resource.Id.textViewTitle).Text = items [position].Title;
			view.FindViewById<Android.Widget.TextView> (Resource.Id.textViewSubtitle).Text = items [position].SubTitle;

//			AppDelegate.listImagesDonwloaded.Clear ();
//			foreach (var company in items) {
//				try {
//					//Java.Net.URL url = new Java.Net.URL(company.ImageUrl);
//					Android.Graphics.Bitmap bitmap = GetBitmapFromUriAsync (company.ImageUrl).Result;
////					Android.Graphics.Bitmap bitmap = Android.Graphics.BitmapFactory.DecodeStream (
////						url.OpenConnection ().InputStream
////					);
//
//					AppDelegate.listImagesDonwloaded.Add (new ImageDownloaded(){
//						Id = company.Id,
//						Bitmap = bitmap
//					});
//					view.FindViewById<Android.Widget.ImageView> (Resource.Id.imageView).SetImageBitmap (bitmap);
//
//				} catch (System.Exception ex) {
//					Console.WriteLine (ex.Message);
//				}
//			}
			return view;
		}

		async System.Threading.Tasks.Task<Android.Graphics.Bitmap> GetBitmapFromUriAsync(string uri)
		{
			var client = new System.Net.Http.HttpClient(new NativeMessageHandler());

			using (var data = await client.GetStreamAsync(uri))
			{
				if (data != null && data.Length > 0)
				{
					return await Android.Graphics.BitmapFactory.DecodeStreamAsync(data);
				}
			}

			return null;
		}
	}
}

