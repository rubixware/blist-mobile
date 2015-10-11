using System;
using Newtonsoft.Json;

namespace pcl
{
	public class Direction : Mobile
	{
		[JsonProperty ("street")]
		public string Street { get; set; }
		[JsonProperty ("suburb")]
		public string suburb { get; set; }
		[JsonProperty ("city")]
		public string City { get; set; }
		[JsonProperty ("region")]
		public string Region { get; set; }

		public Direction ()
		{
		}
	}
}

