using System;
using Newtonsoft.Json;

namespace pcl
{
	public class Company : Mobile, IMobile
	{
		[JsonProperty ("description")]
		public string Description { get; set; }
		[JsonProperty ("category_id")]
		public int CategoryId { get; set; }
		[JsonProperty ("category")]
		public int Category { get; set; }
		[JsonProperty ("tags")]
		public System.Collections.Generic.List<string> Tags { get; set; }
		[JsonProperty ("email")]
		public string Email { get; set; }
		[JsonProperty ("contact_email")]
		public string ContactEmail { get; set; }
		[JsonProperty ("page")]
		public string Page { get; set; }
		[JsonProperty ("phone")]
		public string Phone { get; set; }
		[JsonProperty ("twitter")]
		public string Twitter { get; set; }
		[JsonProperty ("facebook")]
		public string Facebook { get; set; }
		[JsonProperty ("website")]
		public string website { get; set; }
		[JsonProperty ("latitude")]
		public double Latitude { get; set; }
		[JsonProperty ("longitude")]
		public double Longitude { get; set; }
		[JsonProperty ("street")]
		public string Street { get; set; }
		[JsonProperty ("suburb")]
		public string Suburb { get; set; }
		[JsonProperty ("city")]
		public string City { get; set; }
		[JsonProperty ("region")]
		public string Region { get; set; }

		[JsonIgnore]
		public string TagDesription { get {
				string message = "";
				for (int i = 0; i < Tags.Count; i++) {
					message += Tags [i];
					if (i + 1 < Tags.Count) {
						message += ", ";
					}
				}
				return message;
			} }

		public Company ()
		{
		}

		[JsonIgnore]
		public static string Url {
			get {
				return Helper.URL_HOST + URL;
			}
		}

		private const string URL = "/companies";
		public static System.Collections.Generic.List<Company> RequestData()
		{
			bool status = false;

			string data = RestRequests.GetData (Url, out status);

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

			string data = RestRequests.GetData (string.Format ("{0}/{1}", Url, id), out status);

			if (status) {
				return JsonConvert.DeserializeObject<Company>(data, new JsonSerializerSettings () {
					NullValueHandling = NullValueHandling.Ignore});
			}

			throw new Exception (data);
		}
	}
}

