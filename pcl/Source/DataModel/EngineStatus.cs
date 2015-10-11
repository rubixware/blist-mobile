using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace pclSGlocalizacion
{
	public class EngineStatus
	{
		[JsonProperty ("id")]
		public int Id { get; set; }
		[JsonProperty ("name")]
		public string Name { get; set; }
		[JsonProperty ("meaning")]
		public string Meaning { get; set; }


		public static bool IsOn(EngineStatus engineStatus) { 
			return engineStatus.Meaning.ToLower ().Contains ("on") ? true : false;
		}

		public EngineStatus ()
		{
		}

		private const string URL = "/engine_statuses";
		async public static System.Threading.Tasks.Task<EngineStatus[]> Data(Credentials credentials)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, credentials.AccessToken);

			// Generate url
			string url = SGLConstants.URL_HOST + URL + RestRequests.QueryString (dictionary);

			string data = await RestRequests.GetData (url);

			EngineStatus[] engineStatus = JsonConvert.DeserializeObject<EngineStatus[]> (data, new JsonSerializerSettings () {
				NullValueHandling = NullValueHandling.Ignore
			});

			return engineStatus;
		}
	}
}

