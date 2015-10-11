using System;

namespace aBlist
{
	public static class AppDelegate
	{
		public static System.Collections.Generic.List<pcl.IMobile> Categories { get; set; }
		public static System.Collections.Generic.List<pcl.Company> Companies { get; set; }
		public static System.Collections.Generic.List<pcl.Tag> Tags { get; set; }

		public static int ImageResource(int categoryId)
		{
			if (categoryId.Equals (1)) {
				return Resource.Drawable.freelancer;
			}
			if (categoryId.Equals (2)) {
				return Resource.Drawable.startup;
			}
			if (categoryId.Equals (3)) {
				return Resource.Drawable.pyme;
			}
			return Resource.Drawable.Icon;
		}
	}
}

