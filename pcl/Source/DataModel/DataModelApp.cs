using System;
using pclSGlocalizacion;
using System.Collections.Generic;

namespace pclSGlocalizacion
{
	public class DataModelApp
	{
		public Credentials Credentials { get; set; }
		public EngineStatus[] EngineStatus { get; set; }
		public GeoFences GeoFences { get; set; }
		public Locations Locations { get; set; }
		public Map Map { get; set; }
		public Settings Settings { get; set; }
		public User[] Users { get; set; }
		public UserStatus[] UserStatus { get; set; }
		private Dictionary<int, Group> groups;
		public Dictionary<int, Group> Groups{ get { return InitializeGroups ();}}
		public Dictionary<string, List<MarkerBean>> Routes { get; set; }
		public static ColorBean[] Colors {
			get	{ 
				return ColorBean.Colors;
			}
		}

		public Boolean IsUserAllowed { get { return AllowByUserStatus (Credentials.StatusId); }}

		public DataModelApp ()
		{
		}

		public bool EngineIsOn(Device device)
		{
			foreach (var engineStatus in EngineStatus) {
				if (engineStatus.Id.Equals (device.EngineStatusId)) {
					return pclSGlocalizacion.EngineStatus.IsOn (engineStatus);
				}
			}
			return false;
		}
		private Boolean AllowByUserStatus(int userId)
		{
			bool status = false;

			foreach (var user in UserStatus) {
				if (userId.Equals(user.Id) && (user.Name.Contains("active") || user.Name.Contains("activo") )){
					status = true;
					break;
				}
			}
			return true; // FIXME test status
		}

		private Dictionary<int, Group> InitializeGroups()
		{
			if (this.groups == null) {
				this.groups = new Dictionary<int, Group> ();

				foreach (var device in Map.GroupDevices) {
					if (this.groups.ContainsKey(device.GroupId)) {
						this.groups [device.GroupId].ListDevices.Add (device);
					} else {
						Group group = new Group () {
							Id = device.GroupId,
							Name = device.GroupName,
							ListDevices = new List<Device> (){ }
						};
						group.ListDevices.Add (device);
						this.groups.Add (device.GroupId, group);
					}
				}

				// Devices groupless
				string groupLess = "Not Assigned";
				int defaultGroupId = 0;
				foreach (var device in Map.Groupless) {
					if (this.groups.ContainsKey(defaultGroupId)) {
						this.groups [defaultGroupId].ListDevices.Add (device);
					} else {
						Group group = new Group () {
							Id = defaultGroupId,
							Name = groupLess,
							ListDevices = new List<Device> (){ }
						};
						group.ListDevices.Add (device);
						this.groups.Add (defaultGroupId, group);
					}
				}

			}
			return this.groups;
		}
	}
}

