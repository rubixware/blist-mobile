using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace pclSGlocalizacion
{
	public abstract class AOverlay
	{
		[JsonProperty ("name")]
		public string Name { get; set; }
		[JsonProperty ("public")]
		public Boolean Public { get; set; }
		[JsonProperty ("points")]
		public List<MarkerBean> Points { get; set; }
		[JsonProperty ("history")]
		public Boolean PointToPoint { get; set; }

		protected string QueryStringPoints(string overlay)
		{
			string queryString = "";
			for (int i = 0; i < Points.Count; i++) {
				
				queryString += 
					string.Format ("{0}[points_attributes][{1}]{2}&" +
						"{3}[points_attributes][{4}]{5}",
						overlay, Points[i].Id, Points[i].QueryStringLatitude (),
						overlay, Points[i].Id, Points[i].QueryStringLongitude ());
				if (i + 1 < Points.Count) {
					queryString += "&";
				}
			}
			return queryString;
		}

		public abstract string QueryString();

		protected static string ReplaceParam(string value, string overlay)
		{
			return string.Format ("{0}[{1}]", overlay, value);
		}

	}

	public class PolylineBean : AOverlay
	{
		[JsonProperty ("device_id")]
		public int DeviceId { get; set; }
		[JsonProperty ("initial")]
		public DateTime InitialDate { get; set; }
		[JsonProperty ("final")]
		public DateTime FinalDate { get; set; }

		public PolylineBean()
		{
		}

		public override string QueryString ()
		{
			const string OVERLAY = "polyline";

			string queryString = "";
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			if (Name != null)
				dictionary.Add (ReplaceParam ("name", OVERLAY), Name); 
			dictionary.Add (ReplaceParam ("point_to_point", OVERLAY), PointToPoint);
			dictionary.Add (ReplaceParam ("device_id", OVERLAY), DeviceId);
			dictionary.Add (ReplaceParam ("active_until", OVERLAY), InitialDate);
			dictionary.Add (ReplaceParam ("active_since", OVERLAY), FinalDate);
				
			if (dictionary.Count > 0) {
				queryString += RestRequests.QueryString (dictionary);
				if (Points.Count > 0) {
					queryString += "&";
					queryString += QueryStringPoints (OVERLAY);
				}
			}

			return queryString;
		}
	}

	public class PolygonalBean : AOverlay
	{
		public PolygonalBean()
		{
		}

		public override string QueryString ()
		{
			string queryString = "";
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			if (Name != null)
				dictionary.Add (ReplaceParam ("name", "polygon"), Name);
			dictionary.Add (ReplaceParam ("public", "polygon"), Public);

			if (dictionary.Count > 0) {
				queryString += RestRequests.QueryString (dictionary);
				if (Points.Count > 0) {
					queryString += "&";
					queryString += QueryStringPoints ("polygon");
				}
			}

			return queryString;
		}
	}
}

