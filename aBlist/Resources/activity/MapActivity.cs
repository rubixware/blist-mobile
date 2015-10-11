
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

namespace aBlist
{	
	[Activity (Label = "aBlist", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MapActivity : Activity, pcl.IMap
	{
		 GoogleMap map;
		private CameraUpdate cameraUpdate;
		private IList<Marker> listMarkers = new List<Marker>();

		// User values
		private IList<pcl.Marker> ListMarkers = new List<pcl.Marker>();
		private pcl.Marker markerForInitRegion = null;

		private const int MAP_VIEW_ZOOM_INIT = 3;
		private const int MAP_VIEW_ZOOM_MARK = 16;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Map);
			// Init Map
			InitMap ();
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
			foreach (var element in ListMarkers) {
				MarkerOptions markerOptions = new MarkerOptions ();
				markerOptions.SetPosition (new LatLng (element.Coordinate.Latitude, element.Coordinate.Longitude));
				markerOptions.SetIcon(BitmapDescriptorFactory.DefaultMarker ());
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
	}
}

