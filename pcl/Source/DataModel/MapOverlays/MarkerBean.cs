using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class MarkerBean
	{
		[JsonProperty ("lat")]
		public Double Latitude { get; set; }
		[JsonProperty ("long")]
		public Double Longitude { get; set; }
		[JsonProperty ("id")]
		public Double Id { get; set; }

		public MarkerBean ()
		{
		}

		public MarkerBean (double latitude, double longitude)
		{
			this.Latitude = latitude;
			this.Longitude = longitude;
		}
		public MarkerBean (double latitude, double longitude, double id)
		{
			this.Latitude = latitude;
			this.Longitude = longitude;
			this.Id = id;
		}
		
		public string QueryStringId()
		{
			return string.Format ("[id]={0}", Id);
		}
		public string QueryStringLatitude()
		{
			return string.Format ("[lat]={0}", Latitude);
		}

		public string QueryStringLongitude()
		{
			return string.Format ("[long]={0}", Longitude);
		}
	}
}

