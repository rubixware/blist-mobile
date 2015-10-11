using System;
using Newtonsoft.Json;

namespace pcl
{
	public class Session : Mobile
	{
		[JsonIgnore]
		public string Username { get; set; }
		[JsonProperty ("email")]
		public string Email { get; set; }
		[JsonProperty ("auth_token")]
		public string Token { get; set; }
		[JsonProperty ("password")]
		public string Password { get; set; }
		[JsonIgnore]
		public string Url {
			get {
				return Helper.URL_HOST + URL;
			}
		}

		public Session ()
		{
		}

		private const string URL = "/sessions";
		public static Session RequestData(Session session)
		{
			bool status = false;

			string data = RestRequests.PostData (session.Url, session, out status);

			if (status) {
				return JsonConvert.DeserializeObject<Session>(data, new JsonSerializerSettings () {
					NullValueHandling = NullValueHandling.Ignore});
			}
			throw new Exception (data);
		}
	}
}

