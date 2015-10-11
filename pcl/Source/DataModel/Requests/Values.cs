using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class Values
	{
		[JsonProperty ("units")]
		public Unit []Units { get; set; }
		[JsonProperty ("temperatures")]
		public Temperature []Temperatures { get; set; }
		[JsonProperty ("date_formats")]
		public DateFormatBean []DateFormats { get; set; }
		[JsonProperty ("time_zones")]
		public TimeZone []TimeZones { get; set; }

		public Values ()
		{
		}
	}
}

