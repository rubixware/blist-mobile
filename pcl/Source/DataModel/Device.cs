using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class Device
	{
		[JsonProperty ("user_id")]
		public int UserId { get; set; }
		[JsonProperty ("id")]
		public int Id { get; set; }
		[JsonProperty ("uniq_id")]
		public string UniqueId { get; set; }
		[JsonProperty ("phone")]
		public string Phone { get; set; }
		[JsonProperty ("imei")]
		public string Imei { get; set; }
		[JsonProperty ("ip")]
		public string Ip { get; set; }
		[JsonProperty ("installation")]
		public DateTime Installation { get; set; }
		[JsonProperty ("activation")]
		public DateTime Activation { get; set; }
		[JsonProperty ("status_id")]
		public int StatusId { get; set; }
		[JsonProperty ("type_id")]
		public int TypeId { get; set; }
		[JsonProperty ("created_at")]
		public DateTime CreatedAt { get; set; }
		[JsonProperty ("updated_at")]
		public DateTime UpdatedAt { get; set; }
		[JsonProperty ("name")]
		public string Name { get; set; }
		[JsonProperty ("last_time_connected")]
		public DateTime LastTimeConnected { get; set; }
		[JsonProperty ("speed_alert")]
		public Double SpeedAlert { get; set; }
		[JsonProperty ("engine_status_id")]
		public int EngineStatusId { get; set; }
		[JsonProperty ("current_mileage")]
		public Double CurrentMileage { get; set; }
		[JsonProperty ("current_temperature")]
		public Double CurrentTemperature { get; set; }
		[JsonProperty ("battery")]
		public Double Battery { get; set; }
		[JsonProperty ("simcard")]
		public string Simcard { get; set; }
		[JsonProperty ("car_image_id")]
		public int CarImageId { get; set; }
		[JsonProperty ("groupname")]
		public string GroupName { get; set; }
		[JsonProperty ("group_id")]
		public int GroupId { get; set; }


		public Device ()
		{
		}
	}
}

