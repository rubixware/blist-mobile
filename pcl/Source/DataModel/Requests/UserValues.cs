using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class UserValues
	{
		[JsonProperty ("unit_id")]
		public int UnitId { get; set; }
		[JsonProperty ("temperature_id")]
		public int TemperatureId { get; set; }
		[JsonProperty ("date_format_id")]
		public int DateFormatId { get; set; }
		[JsonProperty ("time_zone_id")]
		public int TimeZoneId { get; set; }
		[JsonProperty ("zone_visibility")]
		public Boolean ZoneVisibility { get; set; }
		[JsonProperty ("routes_visibility")]
		public Boolean RoutesVisibility { get; set; }
		[JsonProperty ("speed_mail")]
		public Boolean SpeedMail { get; set; }
		[JsonProperty ("ignition_mail")]
		public Boolean IgnitionMail { get; set; }
		[JsonProperty ("zone_mail")]
		public Boolean ZoneMail { get; set; }
		[JsonProperty ("route_mail")]
		public Boolean RouteMail { get; set; }

		[JsonIgnore]
		public Boolean LocationsVisibility { get; set; }
		[JsonIgnore]
		public Boolean DevicesVisibility { get; set; }
		[JsonIgnore]
		public Boolean ReportsVisibility { get; set; }
		[JsonIgnore]
		public Boolean ConcernPointsVisibility { get; set; }

		public UserValues ()
		{
		}
	}
}

