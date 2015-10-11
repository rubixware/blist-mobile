using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace pclSGlocalizacion
{
	public class UserStatus
	{
		[JsonProperty ("id")]
		public int Id { get; set; }
		[JsonProperty ("name")]
		public string Name { get; set; }

		public UserStatus ()
		{
		}

		private const string URL = "/user_statuses";
		async public static System.Threading.Tasks.Task<UserStatus[]> Data(Credentials credentials)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, credentials.AccessToken);

			// Generate url
			string url = SGLConstants.URL_HOST + URL + RestRequests.QueryString (dictionary);

			string data = await RestRequests.GetData (url);

			UserStatus[] userStatuses = JsonConvert.DeserializeObject<UserStatus[]> (data, new JsonSerializerSettings () {
				NullValueHandling = NullValueHandling.Ignore
			});

			return userStatuses;
		}
	}
}

