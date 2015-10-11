using System;

namespace pcl
{
	public interface IMap
	{
		void InitMap();

		void InitMarkers();

		void ClearMap();

		void ClearMarkers();

		void InitMapInRegion();

		void ChangeRegionInMap(Marker marker);
	}
}

