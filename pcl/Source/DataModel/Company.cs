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
		[JsonProperty ("tags")]
		public System.Collections.Generic.List<Tag> Tags { get; set; }
		[JsonProperty ("contact_id")]
		public Contact ContactId { get; set; }
		[JsonProperty ("address_id")]
		public Direction AdressId { get; set; }
		[JsonProperty ("email")]
		public Session Email { get; set; }

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
	}
}

