using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class ConcernPointBean
	{
		[JsonProperty ("name")]
		public string Name { get; set; }
		[JsonProperty ("lat")]
		public Double Latitude { get; set; }
		[JsonProperty ("long")]
		public Double Longitude { get; set; }
		[JsonProperty ("radius")]
		public Double Radius { get; set; }
		[JsonProperty ("public")]
		public Boolean Public { get; set; }

		public ConcernPointBean ()
		{
		}
	}
}

