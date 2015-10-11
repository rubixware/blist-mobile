using System;
using System.Collections.Generic;

namespace pcl
{
	public class Helper
	{
		public const string URL_HOST = "http://rubixdev.cloudapp.net:8080";
		public Helper ()
		{
		}

		public static string AddValue(string data, string newKey, string newValue)
		{
			try {
				// Declare container for deserializable data
				Dictionary<Object, Object> dictionary;//new Dictionary<object, object> ();

				// Begin the Deserialization
				dictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<Object, Object>> (data);

				// Add new value
				dictionary.Add (newKey, newValue);

				// Create json with the new value
				string newData = Newtonsoft.Json.JsonConvert.SerializeObject (dictionary);

				return newData;

			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

