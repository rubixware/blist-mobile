using System;
using Newtonsoft.Json;

namespace pcl
{
	public interface IMobile
	{
		bool Selected { get; set; }
		int Id { get; set; }
		string Name { get; set; }
		string Title { get; set; }
		string SubTitle { get; set; }
		string ImageName { get; set; }
	}

	public abstract class Mobile: IMobile
	{
		[JsonProperty ("name")]
		public string Name { get; set; }
		[JsonProperty ("id")]
		public int Id { get; set; }
		public bool Selected { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageName { get; set; }
		[JsonIgnore]
		protected string url;

		public Mobile ()
		{
		}

		// Search for one element selected
		public static void Deselect(System.Collections.Generic.IList<IMobile> list)
		{
			foreach (var bean in list) {
				if (bean.Selected) {
					bean.Selected = false;
					break;
				}
			}
		}

		// Search for element id that is currently selected
		public static int SelectedId(System.Collections.Generic.IList<IMobile> list)
		{
			foreach (var bean in list) {
				if (bean.Selected) {
					return bean.Id;
				}
			}
			return 0;
		}

		// Search for element ids that are currently selected
		public static System.Collections.Generic.IList<int> SelectedIds(System.Collections.Generic.IList<IMobile> list)
		{
			System.Collections.Generic.List<int> selected = new System.Collections.Generic.List<int> ();
			foreach (var bean in list) {
				if (bean.Selected) {
					selected.Add (bean.Id);
				}
			}
			return selected;
		}

		// Whant to know index list for selected element
		public static int IndexSelected(System.Collections.Generic.IList<IMobile> list)
		{
			for (int i = 0; i < list.Count; i++) {
				if (list[i].Selected) {
					return i;
				}
			}
			return 0;
		}

		public override string ToString ()
		{
			return Name;
		}

		public static string SearchForName(int id, System.Collections.Generic.List<IMobile> list)
		{
			foreach (var element in list) {
				if (element.Id.Equals (id)) {
					return element.ToString ();
				}
			}
			return null;
		}
	}
}

