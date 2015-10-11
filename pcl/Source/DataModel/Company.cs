using System;
using Newtonsoft.Json;

namespace pcl
{
	public class Company : Mobile
	{
		[JsonProperty ("description")]
		public string Description { get; set; }
		[JsonProperty ("category_id")]
		public int CategoryId { get; set; }
		[JsonProperty ("category")]
		public int Category { get; set; }
		[JsonProperty ("tags")]
		public System.Collections.Generic.List<string> Tags { get; set; }
		[JsonProperty ("contact_id")]
		public Contact ContactId { get; set; }
		[JsonProperty ("address_id")]
		public Direction AdressId { get; set; }
		[JsonProperty ("email")]
		public Session Email { get; set; }
		[JsonProperty ("contact_email")]
		public Session ContactEmail { get; set; }
		[JsonProperty ("phone")]
		public Session Phone { get; set; }
		[JsonProperty ("twitter")]
		public Session Twitter { get; set; }
		[JsonProperty ("facebook")]
		public Session Facebook { get; set; }
		[JsonProperty ("website")]
		public Session website { get; set; }
		[JsonProperty ("latitude")]
		public Session Latitude { get; set; }
		[JsonProperty ("longitude")]
		public Session Longitude { get; set; }

		public Company ()
		{
		}

		[JsonIgnore]
		public string Url {
			get {
				return Helper.URL_HOST + URL;
			}
		}

		private const string URL = "/companies";
		public static System.Collections.Generic.List<Company> RequestData()
		{
			bool status = false;

			string data = RestRequests.GetData (URL, out status);

			if (status) {
				RESTApi request = JsonConvert.DeserializeObject<RESTApi>(data, new JsonSerializerSettings () {
					NullValueHandling = NullValueHandling.Ignore});
				return request.Companies;
			}

			throw new Exception (data);
		}

		public static Company RequestData(int id)
		{
			bool status = false;

			string data = RestRequests.GetData (string.Format ("{0}/{1}", URL, id), out status);

			if (status) {
				return JsonConvert.DeserializeObject<Company>(data, new JsonSerializerSettings () {
					NullValueHandling = NullValueHandling.Ignore});
			}

			throw new Exception (data);
		}
	}
}

