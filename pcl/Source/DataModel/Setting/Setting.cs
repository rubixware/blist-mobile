using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public abstract class Setting
	{
		[JsonProperty ("id")]
		public int Id { get; set; }

		public abstract string Description { get;}
	}
}

