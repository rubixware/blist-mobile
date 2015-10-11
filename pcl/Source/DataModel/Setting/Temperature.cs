using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class Temperature : Setting
	{
		[JsonProperty ("units")]
		public string Units { get; set; }

		public Temperature ()
		{
		}

		public override string Description {
			get {
				return Units;
			}
		}
	}
}

