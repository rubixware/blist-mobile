﻿using System;
using Newtonsoft.Json;

namespace pcl
{
	public class Category : Mobile
	{
		

		public Category ()
		{
		}

		public static System.Collections.Generic.List<IMobile> Categories { get{ return new System.Collections.Generic.List<IMobile>{
					new Category(){
						Id = 1,
						Name = "Freelancer",
						ImageName = "freelancer"
					},
					new Category(){
						Id = 2,
						Name = "Start up",
						ImageName = "startup"
					},
					new Category(){
						Id = 3,
						Name = "PYME",
						ImageName = "pyme"
					}
				};
			}
		}

		[JsonIgnore]
		public string Url {
			get {
				return Helper.URL_HOST + URL;
			}
		}

		private const string URL = "/categories";
		public static System.Collections.Generic.List<Category> RequestData()
		{
			bool status = false;

			string data = RestRequests.GetData (URL, out status);

			if (status) {
				RESTApi request = JsonConvert.DeserializeObject<RESTApi>(data, new JsonSerializerSettings () {
					NullValueHandling = NullValueHandling.Ignore});
				return request.Categories;
			}

			throw new Exception (data);
		}
	}
}

