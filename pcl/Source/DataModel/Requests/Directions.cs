using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace pclSGlocalizacion
{
	public class Directions
	{
		public Directions ()
		{
		}

		private const string WEB_SERVICE_URL = "https://maps.googleapis.com/maps/api/directions/json?";
		public static string Url(MarkerBean origin, MarkerBean destination)
		{
			return WEB_SERVICE_URL + string.Format ("origin={0},{1}&destination={2},{3}&key={4}", origin.Latitude, origin.Longitude, 
				destination.Latitude, destination.Longitude, SGLConstants.KEY_DIRECTIONS);
		}

		async public static System.Threading.Tasks.Task<string> PolylinePath(string url)
		{
			string data = await RestRequests.GetData (url);
			JObject googleSearch = JObject.Parse (data);

			var value = googleSearch ["routes"] [0] ["overview_polyline"] ["points"].ToString ();

			return value;
		}


	}
}

