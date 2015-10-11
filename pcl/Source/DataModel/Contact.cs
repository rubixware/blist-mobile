using System;
using Newtonsoft.Json;

namespace pcl
{
	public class Contact : Mobile
	{
		[JsonProperty ("page")]
		public string PageUrl { get; set; }
		[JsonProperty ("telephone")]
		public string Telephone { get; set; }
		[JsonProperty ("email")]
		public string Email { get; set; }
		[JsonProperty ("facebook")]
		public string FaceBook { get; set; }
		[JsonProperty ("twitter")]
		public string Twitter { get; set; }

		public Contact ()
		{
		}
	}
}

