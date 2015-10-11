using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class TimeZone : Setting
	{
		[JsonProperty ("name")]
		public string Name { get; set; }

		public TimeZone ()
		{
		}

		public override string Description {
			get {
				return Name;
			}
		}
	}
}

