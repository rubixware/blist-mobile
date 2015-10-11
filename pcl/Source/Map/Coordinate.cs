using System;
using Newtonsoft.Json;

namespace pcl
{
	public class Coordinate : Mobile
	{
		[JsonProperty ("latitude")]
		public Double Latitude { get; set; }
		[JsonProperty ("longitude")]
		public Double Longitude { get; set; }

		public Coordinate ()
		{
		}
	}
}

