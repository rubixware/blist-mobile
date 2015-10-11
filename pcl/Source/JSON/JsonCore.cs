using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace pclSGlocalizacion
{
	public static class JsonCore
	{
		public static string AddValue(string data, string newKey, string newValue)
		{
			try {
				// Declare container for deserializable data
				Dictionary<Object, Object> dictionary;//new Dictionary<object, object> ();
				
				// Begin the Deserialization
				dictionary = JsonConvert.DeserializeObject<Dictionary<Object, Object>> (data);

				// Add new value
				dictionary.Add (newKey, newValue);

				// Create json with the new value
				string newData = JsonConvert.SerializeObject (dictionary);

				return newData;

			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

