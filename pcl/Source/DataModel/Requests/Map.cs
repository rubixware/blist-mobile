using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pclSGlocalizacion
{
	public class Map
	{
		[JsonProperty ("group_devices")]
		public Device[] GroupDevices { get; set; }
		[JsonProperty ("groupless")]
		public Device[] Groupless { get; set; }
		[JsonProperty ("connections")]
		public Connection[] Connections { get; set; }
		[JsonProperty ("created_at")]
		public ConnectionCreatedAt[] ConnectionsCreatedAt { get; set; }
		[JsonProperty ("geocoded_areas")]
		public GeocodedArea[] GeocodedAreas { get; set; }

		public Map ()
		{
		}

		private const string URL = "/map";
		async public static Task<Map> Data(Credentials credentials)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, credentials.AccessToken);

			// Generate url
			string url = SGLConstants.URL_HOST + URL + RestRequests.QueryString (dictionary);

			string data = await RestRequests.GetData (url);

			Map map = JsonConvert.DeserializeObject<Map> (data, new JsonSerializerSettings () {
				NullValueHandling = NullValueHandling.Ignore
			});

			return map;
		}

		public Connection Device(int deviceId)
		{
			foreach (var connection in this.Connections) {
				if (connection.DeviceId.Equals(deviceId)) {
					return connection;
				}
			}
			return null;
		}

		public int DevicesCount { 
			get { 
				return GroupDevices.Length + Groupless.Length;
			}
		}
	}
}

