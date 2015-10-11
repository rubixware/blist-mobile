using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pclSGlocalizacion
{
	public class Settings
	{
		[JsonProperty ("values")]
		public Values Values { get; set; }
		[JsonProperty ("user_values")]
		public UserValues UserValues { get; set; }

		public Settings ()
		{
		}

		private const string URL = "/settings";
		async public static Task<Settings> Data(Credentials credentials)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, credentials.AccessToken);

			// Generate url
			string url = SGLConstants.URL_HOST + URL + RestRequests.QueryString (dictionary);

			string data = await RestRequests.GetData (url);

			Settings settings = JsonConvert.DeserializeObject<Settings> (data, new JsonSerializerSettings () {
				NullValueHandling = NullValueHandling.Ignore
			});

			return settings;
		}

		private const string URL_UPDATE = "/settings/update";
		public static string Update(Credentials credentials, Dictionary<string, object> dictionary)
		{
			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, credentials.AccessToken);

			// Generate url
			string url = SGLConstants.URL_HOST + URL_UPDATE + RestRequests.QueryString (dictionary);


			//Console.WriteLine (Settings.Update (AppDelegate.DataModelApp.Credentials, AccountActivity.SettingsValues ()).Result);
			bool status = false;

			string data = RestRequests.GetData (RestRequests.FillParam (url), out status);

			if (status) {
				return data;
			}
			throw new Exception (data);
		}
	}
}

