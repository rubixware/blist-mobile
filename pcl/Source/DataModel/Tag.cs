﻿using System;
using Newtonsoft.Json;

namespace pcl
{
	public class Tag : Mobile
	{
		public Tag ()
		{
		}

		[JsonIgnore]
		public string Url {
			get {
				return Helper.URL_HOST + URL;
			}
		}

		private const string URL = "/tags";
		public static System.Collections.Generic.List<Tag> RequestData()
		{
			bool status = false;

			string data = RestRequests.GetData (URL, out status);

			if (status) {
				RESTApi request = JsonConvert.DeserializeObject<RESTApi>(data, new JsonSerializerSettings () {
					NullValueHandling = NullValueHandling.Ignore});
				return request.Tags;
			}

			throw new Exception (data);
		}
	}
}

