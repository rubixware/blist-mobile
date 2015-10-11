using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pclSGlocalizacion
{
	public class Credentials
	{
		[JsonProperty ("id")]
		public int Id { get; set; }
		[JsonProperty ("first_name")]
		public string FirstName { get; set; }
		[JsonProperty ("last_name")]
		public string LastName { get; set; }
		[JsonProperty ("status_id")]
		public int StatusId { get; set; }
		[JsonProperty ("company")]
		public string Company { get; set; }
		[JsonProperty ("user_name")]
		public string Username { get; set; }
		[JsonProperty ("access_token")]
		public string AccessToken { get; set; }
		[JsonProperty ("sub_user")]
		public Boolean IsSubUser { get; set; }

		[JsonIgnore]
		public const string ACCESS_TOKEN_KEY = "access_token";
		[JsonIgnore]
		private static string URL = "/sessions/new";

		async public static Task<Credentials> Data(string userName, string password)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			Credentials credentials;
	
			dictionary.Add ("user_name", userName);
			dictionary.Add ("password", password);

			// Generate url
			string url = SGLConstants.URL_HOST + URL + RestRequests.QueryString (dictionary);

			string data = await RestRequests.GetData (url);

//			if (data != null && data.Contains ("false")) {
//				throw new InvalidOperationException (Constants.LOGIN_FAILED);
//			}
			try {
				credentials = JsonConvert.DeserializeObject<Credentials> (data, new JsonSerializerSettings () {
					NullValueHandling = NullValueHandling.Ignore
				});
			} catch (Exception ex) {
				throw new InvalidOperationException (SGLConstants.LOGIN_FAILED);
			}

			return credentials;
		}

//		public static string Data(string userName, string password, int oi)
//		{
//			Dictionary<string, string> dictionary = new Dictionary<string, string> ();
//
//			dictionary.Add ("user_name", userName);
//			dictionary.Add ("password", password);
//
//			// Generate url
//			string url = Constants.URL_HOST + URL + RestRequests.QueryString (dictionary);
//
//			string data = RestRequests.GetData (url).Result;
//
//			if (data != null && data.Contains ("false")) {
//				throw new InvalidOperationException (Constants.LOGIN_FAILED);
//			}
//				
//			return data;
//		}
	}
}

