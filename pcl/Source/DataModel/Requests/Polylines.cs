using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace pclSGlocalizacion
{
	public class Polylines
	{
		public Polylines ()
		{
		}

		private const string URL = "/routes";
		async public static System.Threading.Tasks.Task<Dictionary<string, List<MarkerBean>>> Data(Credentials credentials)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, credentials.AccessToken);

			// Generate url
			string url = SGLConstants.URL_HOST + URL + RestRequests.QueryString (dictionary);

			string data = await RestRequests.GetData (url);

			JObject dataPolylines = JObject.Parse (data);
			var dataPoints = dataPolylines ["points"].Children ();
			Dictionary<string, List<MarkerBean>> points = new Dictionary<string, List<MarkerBean>>();

			foreach (JToken item in dataPoints) {
				string key = (item as JProperty).Name;
				foreach (var pv in item.Children ()) {
					List<MarkerBean> mb = JsonConvert.DeserializeObject<List<MarkerBean>> (pv.ToString (), new JsonSerializerSettings () {
						NullValueHandling = NullValueHandling.Ignore
					});
					points.Add (key, mb);
				};
			}

			return points;
		}
	}
}

