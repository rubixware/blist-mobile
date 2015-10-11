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

		public static System.Collections.Generic.List<ImageDownloaded> listImagesDonwloaded =
			new System.Collections.Generic.List<ImageDownloaded>();
	}

	public class ImageDownloaded
	{
		public ImageDownloaded(){}

		public int Id { get; set; }
		public Android.Graphics.Bitmap Bitmap { get; set; }

	}
}

