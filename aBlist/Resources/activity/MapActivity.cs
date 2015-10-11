
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
using Java.Lang;

namespace aBlist
{	
	[Activity (Label = "aBlist", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MapActivity : Activity, pcl.IMap, IDialogInterfaceOnDismissListener, IDialogInterfaceOnCancelListener
	{
		 GoogleMap map;
		private CameraUpdate cameraUpdate;
		private List<Marker> listMarkers = new List<Marker>();

		// User values
		//private List<pcl.Marker> ListMarkers = new List<pcl.Marker>();
		private pcl.Marker markerForInitRegion = null;

		private const int MAP_VIEW_ZOOM_INIT = 3;
		private const int MAP_VIEW_ZOOM_MARK = 16;

		// Tags
		ArrayAdapter<pcl.IMobile> arrayAdapter;
		ListView listViewTags;
		Dialog dialogTags;

		// Companies
		private List<pcl.IMobile> listCompanies = new List<pcl.IMobile>();
		private ListView listViewCompanies;

		public static pcl.Company ItemSelectedFromListView;

		private bool searchState = false;
		private bool showCompaniesState = false;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Map);
			// Init Map
			InitMap ();

			//this.listViewCompanies = FindViewById<ListView> (Resource.Id.listViewCompanies);

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

			// Categories
			FindViewById<ImageButton> (Resource.Id.imageButtonTagSearch).Click += ShowCategoriesDialog;
			InitCategories ();

		}

		private void OpenKeyBoard()
		{
			InputMethodManager imm = (InputMethodManager) this.GetSystemService(Context.InputMethodService);
			imm.ToggleSoftInput (Android.Views.InputMethods.ShowFlags.Forced, Android.Views.InputMethods.HideSoftInputFlags.None);
		}

		private void CloseKeyBoard()
		{
			InputMethodManager imm = (InputMethodManager) this.GetSystemService(Context.InputMethodService);
			if (this.CurrentFocus != null && this.CurrentFocus.WindowToken != null) {
				imm.HideSoftInputFromWindow (this.CurrentFocus.WindowToken, Android.Views.InputMethods.HideSoftInputFlags.None);	
			}
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
//			if (this.listView != null && this.listView.Count > 0) {
//				foreach (var marker in listMarkers) {
//					if (marker.Equals (e.Marker)) {
//						// TODO
//					}
//				}
//			}
			
		}

		public void OnMapClick(object sender, GoogleMap.MapClickEventArgs e)
		{
			if (this.searchState) {
				CloseKeyBoard ();
				this.ResetNavigationControlState ();
			}
			if (this.showCompaniesState) {
				ShowListViewCompanies (false);
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

		private void InitCategories()
		{
			this.listViewTags = new ListView (this);
			this.arrayAdapter = new ArrayAdapter<pcl.IMobile> (this, Android.Resource.Layout.SimpleListItemChecked,
				Android.Resource.Id.Text1, AppDelegate.Categories);
			this.listViewTags.Adapter = this.arrayAdapter;
			this.listViewTags.ChoiceMode = ChoiceMode.Multiple;
			this.listViewTags.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				
				AppDelegate.Categories[e.Position].Selected = !AppDelegate.Categories[e.Position].Selected;
			};
			InitAlertDialogCategories ();
		}

		private void InitAlertDialogCategories()
		{
			AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
			alertDialog.SetTitle("Categorías");
			alertDialog.SetView (this.listViewTags);
			alertDialog.SetPositiveButton ("Cerrar", delegate {
				SearchCompanies();
			});
			alertDialog.NothingSelected += delegate(object sender, AdapterView.NothingSelectedEventArgs e) {
				Console.WriteLine ();
			};
			//alertDialog.SetOnDismissListener (this);
			alertDialog.SetOnCancelListener (this);
			dialogTags = alertDialog.Create ();
		}

		public void OnDismiss (IDialogInterface dialog)
		{
			// Console.WriteLine ("OnDismiss"); API 17+
		}

		public void OnCancel (IDialogInterface dialog)
		{
			Console.WriteLine ("OnCancel");
			SearchCompanies ();
		}

		private void SearchCompanies()
		{
			FindViewById<LinearLayout> (Resource.Id.linearLayoutCompanies).RemoveAllViews ();
			this.listViewCompanies = new ListView (this);
			FindViewById<LinearLayout> (Resource.Id.linearLayoutCompanies).AddView (this.listViewCompanies);
			this.listCompanies.Clear ();
			DefineCompanies ();

			var listAdapter = new CompaniesListViewAdapter (this, this.listCompanies);
			this.listViewCompanies.Adapter = listAdapter;
			this.listViewCompanies.ChoiceMode = ChoiceMode.Single;
			this.listViewCompanies.ItemClick += OnListItemClick;

			ShowListViewCompanies (true);
		}

		private void ShowListViewCompanies(bool state)
		{
			ViewStates viewStates = state ? ViewStates.Visible : ViewStates.Gone;
			this.listViewCompanies.Visibility = viewStates;
			this.showCompaniesState = state;
		}
		void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			foreach (var company in AppDelegate.Companies) {
				if (company.Id.Equals (this.listCompanies[e.Position].Id)) {
					ItemSelectedFromListView = company;
					break;
				}
			}
			ShowListViewCompanies (false);

			StartActivity (typeof(CompanyInfo));
		}

		private void DefineCompanies()
		{
			foreach (var company in AppDelegate.Companies) {
				company.Title = company.Name;
				company.SubTitle = company.TagDesription;
				foreach (var category in AppDelegate.Categories) {
					if (category.Selected && company.CategoryId.Equals (category.Id)) {
						this.listCompanies.Add (company);
						break;
					}
				}
			}
			if (this.listCompanies.Count == 0) {
				this.listCompanies.AddRange (AppDelegate.Companies);
			}
		}
		// This function is used only once, so no validations
		private void ShowCategoriesDialog(object sender, EventArgs e)
		{
			dialogTags.Show();
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

