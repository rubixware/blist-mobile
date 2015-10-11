using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class Connection
	{
		[JsonProperty ("id")]
		public int Id { get; set; }
		[JsonProperty ("latitude")]
		public Double Latitude { get; set; }
		[JsonProperty ("longitude")]
		public Double Longitude { get; set; }
		[JsonProperty ("device_id")]
		public int DeviceId { get; set; }
		[JsonProperty ("speed")]
		public Double Speed { get; set; }
		[JsonProperty ("speed_alert")]
		public Boolean SpeedAlert { get; set; }
		[JsonProperty ("ignition_on")]
		public Boolean IgnitionOn { get; set; }
		[JsonProperty ("ignition_off")]
		public Boolean IgnitionOff { get; set; }
		[JsonProperty ("mileage")]
		public Double Mileage { get; set; }
		[JsonProperty ("engine_status_id")]
		public int EngineStatusId { get; set; }
		[JsonProperty ("battery")]
		public int Battery { get; set; }

		public Connection ()
		{
		}
	}

	public class ConnectionCreatedAt
	{
		[JsonProperty ("created_at")]
		public DateTime CreatedAt { get; set; }
		[JsonProperty ("device_id")]
		public Double DeviceId { get; set; }
	}
}

