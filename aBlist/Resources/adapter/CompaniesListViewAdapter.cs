using System;

namespace aBlist
{
	public class CompaniesListViewAdapter :  Android.Widget.BaseAdapter<string>
	{
		public CompaniesListViewAdapter ()
		{
		}

		protected Android.App.Activity context;
		protected System.Collections.Generic.List<pcl.Mobile> items;

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
			return view;
		}
	}
}

