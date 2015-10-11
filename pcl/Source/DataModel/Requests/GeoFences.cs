using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pclSGlocalizacion
{
	public class GeoFences
	{
		[JsonProperty ("circular")]
		public List<CircularBean> Circulars { get; set; }
		[JsonProperty ("polygonal")]
		public List<PolygonalBean> Polygonals { get; set; }

		public GeoFences ()
		{
		}

		public static string URL = "/geo_fences";
		async public static Task<GeoFences> Data(Credentials credentials)
		{
			Dictionary<string, List<object>> dictionary = new Dictionary<string, List<object>> ();
			List<object> value = new List<object> ();
			value.Add (credentials.AccessToken);
			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, value);

			// Generate url
			string url = SGLConstants.URL_HOST + URL + RestRequests.QueryString (dictionary);

			string data = await RestRequests.GetData (url);

			GeoFences geoFences = JsonConvert.DeserializeObject<GeoFences> (data, new JsonSerializerSettings () {
				NullValueHandling = NullValueHandling.Ignore
			});

			return geoFences;
		}
	}
}

