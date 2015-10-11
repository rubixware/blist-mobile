using System;
using Newtonsoft.Json;

namespace pcl
{
	public class Error
	{
		[JsonProperty ("message")]
		public string Message { get; set; }
		[JsonProperty ("code")]
		public string Code { get; set; }
	}
}

