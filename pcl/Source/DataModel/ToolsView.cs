using System;

namespace pclSGlocalizacion
{
	public static class ToolsView
	{
		public static CircularBean Location = new CircularBean();
		public static Zone ZoneOverlay = new Zone();
		public static Route History = new Route();

		public class Zone
		{
			public Zone ()
			{
			}
			
			public string Name { get; set; }
			public Boolean CanShowToSubusers { get; set; }
		}

		public class Route
		{
			public Route ()
			{
			}
			
			public string Name { get; set; }
			public int Id { get; set; }
			public string InitDate { get; set; }
			public string FinalDate { get; set; }
		}
	}
}

