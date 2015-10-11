using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pclSGlocalizacion
{
	public class Locations
	{
		[JsonProperty ("locations")]
		public List<ConcernPointBean> ConcernPoints { get; set; }

		public Locations ()
		{
		}

		private static string URL = "/locations";
		async public static Task<Locations> Data(Credentials credentials)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, credentials.AccessToken);

			// Generate url
			string url = SGLConstants.URL_HOST + URL + RestRequests.QueryString (dictionary);

			string data = await RestRequests.GetData (url);

			Locations locations = JsonConvert.DeserializeObject<Locations> (data, new JsonSerializerSettings () {
				NullValueHandling = NullValueHandling.Ignore
			});

			return locations;
		}
	}
}

