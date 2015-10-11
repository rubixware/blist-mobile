using System;
using Newtonsoft.Json;

namespace pcl
{
	public class MapOverlay
	{
		[JsonProperty ("name")]
		public string Name { get; set; }
		[JsonProperty ("points")]
		public System.Collections.Generic.IList<Marker> Points { get; set; }
	}
}

