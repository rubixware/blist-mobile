using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace pclSGlocalizacion
{
	public class Users
	{
		public Users ()
		{
		}

		private const string URL = "/users";
		async public static Task<User[]> Data(Credentials credentials)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, credentials.AccessToken);

			// Generate url
			string url = SGLConstants.URL_HOST + URL + RestRequests.QueryString (dictionary);

			string data = await RestRequests.GetData (url);

			User[] users = JsonConvert.DeserializeObject<User[]> (data, new JsonSerializerSettings () {
				NullValueHandling = NullValueHandling.Ignore
			});

			return users;
		}
	}
}

