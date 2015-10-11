using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class GeocodedArea
	{
		[JsonProperty ("id")]
		public int Id { get; set; }
		[JsonProperty ("lat")]
		public Double Latitude { get; set; }
		[JsonProperty ("long")]
		public Double Longitude { get; set; }
		[JsonProperty ("city")]
		public string City { get; set; }
		[JsonProperty ("street")]
		public string Street { get; set; }
		[JsonProperty ("reference")]
		public string Reference { get; set; }
		[JsonProperty ("distance")]
		public Double Distance { get; set; }
		[JsonProperty ("device_id")]
		public Double DeviceId { get; set; }
	
		public GeocodedArea ()
		{
		}
	}
}

