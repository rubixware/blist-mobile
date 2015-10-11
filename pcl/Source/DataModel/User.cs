using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class User
	{
		[JsonProperty ("user_id")]
		public int Id { get; set; }
		[JsonProperty ("user_name")]
		public string UserName { get; set; }
		[JsonProperty ("first_name")]
		public string FirstName { get; set; }
		[JsonProperty ("last_name")]
		public string LastName { get; set; }

		public User ()
		{
		}
	}
}

