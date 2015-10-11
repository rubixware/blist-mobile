using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class Unit : Setting
	{
		[JsonProperty ("name")]
		public string Name { get; set; }

		public Unit ()
		{
		}

		public override string Description {
			get {
				return Name;
			}
		}
	}
}

