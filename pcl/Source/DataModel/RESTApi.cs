using System;
using Newtonsoft.Json;

namespace pcl
{
	public class RESTApi
	{
		[JsonProperty ("categories")]
		public System.Collections.Generic.List<Category> Categories { get; set; }
		[JsonProperty ("companies")]
		public System.Collections.Generic.List<Company> Companies { get; set; }
		[JsonProperty ("tags")]
		public System.Collections.Generic.List<Tag> Tags { get; set; }
	}
}

