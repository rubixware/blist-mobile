
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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.Security.Policy;
using Android.Graphics;
using Java.Net;
using Android.Views.InputMethods;

namespace aBlist
{	
	[Activity (Label = "aBlist", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MapActivity : Activity, pcl.IMap
	{
		 GoogleMap map;
		private CameraUpdate cameraUpdate;
		private List<Marker> listMarkers = new List<Marker>();

		// User values
		//private List<pcl.Marker> ListMarkers = new List<pcl.Marker>();
		private pcl.Marker markerForInitRegion = null;

		private const int MAP_VIEW_ZOOM_INIT = 3;
		private const int MAP_VIEW_ZOOM_MARK = 16;

		// Companies
		private ArrayAdapter<pcl.Company> adapterListCompanies;
		private ListView listView;
		private List<pcl.Company> listCompanies = new List<pcl.Company> ();

		public static pcl.Company ItemSelectedFromListView;

		private bool searchState = false;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Map);
			// Init Map
			InitMap ();

			this.listView = new ListView (this);

			// Action Bar Custom Navigation Bar
			ActionBar.SetDisplayShowHomeEnabled (false);
			ActionBar.SetDisplayShowTitleEnabled (false);

			ActionBar.SetCustomView (Resource.Layout.NavigationActionBar);
			ActionBar.SetDisplayShowCustomEnabled (true);

			ActionBar.CustomView.FindViewById<EditText> (Resource.Id.editTextSearch).Visibility = ViewStates.Gone;
			ActionBar.CustomView.FindViewById<ImageButton> (Resource.Id.imageButtonSearch).Click += delegate {
				this.searchState = true;
				OpenKeyBoard ();
				ActionBar.CustomView.FindViewById<ImageButton> (Resource.Id.imageButtonTagSearch).Visibility = 
					ActionBar.CustomView.FindViewById<TextView> (Resource.Id.textViewTitle).Visibility = ViewStates.Gone;
				ActionBar.CustomView.FindViewById<EditText> (Resource.Id.editTextSearch).Visibility = ViewStates.Visible;
				FindViewById<TextView> (Resource.Id.editTextSearch).RequestFocus ();

			};
		}

		private void OpenKeyBoard()
		{
			InputMethodManager imm = (InputMethodManager) this.GetSystemService(Context.InputMethodService);
			imm.ToggleSoftInput (Android.Views.InputMethods.ShowFlags.Forced, Android.Views.InputMethods.HideSoftInputFlags.None);
		}

		private void CloseKeyBoard()
		{
			InputMethodManager imm = (InputMethodManager) this.GetSystemService(Context.InputMethodService);
			imm.HideSoftInputFromWindow (this.CurrentFocus.WindowToken, Android.Views.InputMethods.HideSoftInputFlags.None);
			//imm.ToggleSoftInput (Android.Views.InputMethods.ShowFlags., Android.Views.InputMethods.HideSoftInputFlags.None );
		}
		private void ResetNavigationControlState()
		{
			ActionBar.CustomView.FindViewById<ImageButton> (Resource.Id.imageButtonTagSearch).Visibility = 
				ActionBar.CustomView.FindViewById<TextView> (Resource.Id.textViewTitle).Visibility = ViewStates.Visible;
			ActionBar.CustomView.FindViewById<EditText> (Resource.Id.editTextSearch).Visibility = ViewStates.Gone;
		}
		protected override void OnStart ()
		{
			base.OnStart ();

			MapFragment mapFrag = (MapFragment) FragmentManager.FindFragmentById(Resource.Id.mapContainer);
			this.map = mapFrag.Map;
			if (this.map != null) {
				// The GoogleMap object is ready to go.
				if (this.cameraUpdate == null) {
					InitMapInRegion();
				}
				this.map.MarkerClick += OnMapMarkerClick;
				this.map.MapClick += OnMapClick;
				this.map.MapLongClick += MapLongClick;

				// Clean Map to ensure to load new items created at Tools
				ClearMap ();

				// Load Markers
				InitMarkers ();
			}
		}

		public void ClearMap ()
		{
			ClearMarkers ();
			this.map.Clear ();
		}

		public void InitMarkers ()
		{
			foreach (var company in AppDelegate.Companies) {
				MarkerOptions markerOptions = new MarkerOptions ();
				markerOptions.SetPosition (new LatLng(company.Latitude, company.Longitude));
				markerOptions.SetIcon (BitmapDescriptorFactory.FromResource (AppDelegate.ImageResource (company.CategoryId)));
				var marker = this.map.AddMarker (markerOptions);
				this.listMarkers.Add (marker);
			}
		}
		public void InitMap ()
		{
			// Maps
			var mapFragment = MapFragment.NewInstance ();
			FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction ();
			fragmentTransaction.Add (Resource.Id.mapContainer, mapFragment);
			fragmentTransaction.Commit ();
		}

		public void InitMapInRegion ()
		{
			ChangeRegionInMap (this.markerForInitRegion);
		}

		public void ChangeRegionInMap (pcl.Marker marker)
		{
			if (marker != null) {
				LatLng location = new LatLng(marker.Coordinate.Latitude, marker.Coordinate.Longitude);
				CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
				builder.Target(location);
				builder.Zoom(MAP_VIEW_ZOOM_INIT);
				CameraPosition cameraPosition = builder.Build();
				this.cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
				this.map.MoveCamera (this.cameraUpdate);
			}
		}

		public void OnMapMarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
		{

		}

		public void OnMapClick(object sender, GoogleMap.MapClickEventArgs e)
		{
			if (this.searchState) {
				CloseKeyBoard ();
				this.ResetNavigationControlState ();
			}
		}

		public void MapLongClick(object sender, GoogleMap.MapLongClickEventArgs e)
		{

		}

		public void ClearMarkers ()
		{
			foreach (var element in listMarkers) {
				element.Remove ();
			}
		}

		private void InitComanies()
		{
			this.adapterListCompanies = new ArrayAdapter<pcl.Company> (this, Android.Resource.Layout.SimpleListItemChecked,
				Android.Resource.Id.Text1, this.listCompanies);
			this.listView.Adapter = this.adapterListCompanies;
			this.listView.ChoiceMode = ChoiceMode.Multiple;
			this.listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				// TODO
				//this.listDevices[e.Position].Selected = !this.listDevices[e.Position].Selected;
				ItemSelectedFromListView = this.listCompanies[e.Position];

				StartActivity (typeof(CompanyInfo));
			};
		}

//		private Bitmap downloadBitmap(String url) {
//			HttpURLConnection urlConnection = null;
//			try {
//				URL uri = new URL(url);
//				urlConnection = (HttpURLConnection) uri.OpenConnection();
//
//				int statusCode = urlConnection.getResponseCode();
//				if (statusCode != HttpStatus.SC_OK) {
//					return null;
//				}
//
//				InputStream inputStream = urlConnection.getInputStream();
//				if (inputStream != null) {
//
//					Bitmap bitmap = BitmapFactory.decodeStream(inputStream);
//					return bitmap;
//				}
//			} catch (Exception e) {
//				Log.d("URLCONNECTIONERROR", e.toString());
//				if (urlConnection != null) {
//					urlConnection.disconnect();
//				}
//				Log.w("ImageDownloader", "Error downloading image from " + url);
//			} finally {
//				if (urlConnection != null) {
//					urlConnection.disconnect();
//
//				}
//			}
//			return null;
//		}
	}
}

