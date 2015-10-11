using System;

namespace pclSGlocalizacion
{
	public class Group
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public System.Collections.Generic.List<Device> ListDevices { get; set; }

		public Group ()
		{
		}
	}
}

