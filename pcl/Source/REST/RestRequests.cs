using System;
using ModernHttpClient;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Net;

namespace pcl
{
	public static class RestRequests
	{
		public static HttpResponseMessage LastHttpResponseMessage { get; set; }

		public static string Start(string url, Object data)
		{
			try {
				HttpClient httpClient = new HttpClient (new NativeMessageHandler ());
				
				// Serialize data to send
				string dataToSend = JsonConvert.SerializeObject (data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
				
				// Add authentication token to params content
				//dataToSend = Helper.AddValue (dataToSend, Credentials.ACCESS_TOKEN_KEY, "");
				
				// Create content body
				HttpContent httpContent = new StringContent (dataToSend, System.Text.Encoding.UTF8, "application/json");
				
				// Execute request and await for response
				HttpResponseMessage httpResponseMessage = httpClient.PostAsync (url, httpContent).Result;
				// save response message for further access
				LastHttpResponseMessage = httpResponseMessage;

				if (httpResponseMessage.IsSuccessStatusCode) {
					return httpResponseMessage.Content.ReadAsStringAsync ().Result;
				}

				throw new HttpRequestException(httpResponseMessage.ToString ());

			} catch (Exception ex) {
				throw(ex);
			}
		}

		async public static Task<string> GetData(string url)
		{
			HttpClient httpClient = new HttpClient (new NativeMessageHandler ());

			// Execute request and await for response
			HttpResponseMessage httpResponseMessage = httpClient.GetAsync (FillParam (url)).Result;
			// save response message for further access
			LastHttpResponseMessage = httpResponseMessage;

			// Return the success response from request
			if (httpResponseMessage.IsSuccessStatusCode) {
				return await httpResponseMessage.Content.ReadAsStringAsync ();
			}
			// Return string representation type of HttpResponseMessage

			throw new HttpRequestException(httpResponseMessage.ReasonPhrase);
		}

		public static string GetData(string url, out bool status)
		{
			HttpClient httpClient = new HttpClient (new NativeMessageHandler ());

			// Execute request and await for response
			HttpResponseMessage httpResponseMessage = httpClient.GetAsync (FillParam (url)).Result;
			// save response message for further access
			LastHttpResponseMessage = httpResponseMessage;

			// Return the success response from request
			if (httpResponseMessage.IsSuccessStatusCode) {
				status = true;
				return httpResponseMessage.Content.ReadAsStringAsync ().Result;
			}
			status = false;
			// Return string representation type of HttpResponseMessage
			return httpResponseMessage.StatusCode.ToString ();
			//throw new HttpRequestException(httpResponseMessage.ReasonPhrase);
		}

		private static string ServerCodesCustomMessages(HttpResponseMessage httpResponseMessage)
		{
			// TODO
			return "";
		}

//		public static string testDemo()
//		{
//			HttpClient httpClient = new HttpClient(new NativeMessageHandler());
//
//			//var httpClient = new HttpClient(new NativeMessageHandler());
//			//HttpContent httpContent = new StringContent(sendata, System.Text.Encoding.UTF8, "application/json");
//
//			//var response = await httpClient.PostAsync(new Uri("http://www.mocky.io/v2/55f1e9af61489c621d9e04d1"), httpContent);
//			string httpResponse = httpClient.GetStringAsync ("http://www.mocky.io/v2/55f1e9af61489c621d9e04d1").Result;
//			Task.Delay (2000).Start ();
//			//var httpResponse = httpClient.PostAsync(new Uri("http://www.mocky.io/v2/55f1e9af61489c621d9e04d1"), httpContent).Result;
//
//			return httpResponse;
//		}

		public static string QueryString(Dictionary<string, object> dictionary)
		{
			string queryString = "?";
			if (dictionary.Keys.Count > 0) {
				int index = 0;
				Dictionary<string,object>.KeyCollection.Enumerator enumerator = dictionary.Keys.GetEnumerator ();
				while (enumerator.MoveNext ()) {
					string key = enumerator.Current;
					queryString += string.Format ("{0}={1}", key, dictionary[key]);
					index++;
					if (index < dictionary.Keys.Count) {
						queryString += "&";
					}

				}
			} else {
				throw new KeyNotFoundException ("No keys found in dictionary for query string");
			}
			return queryString;
		}

		public static string QueryString(Dictionary<string, List<object>> dictionary)
		{
			string queryString = "?";
			if (dictionary.Keys.Count > 0) {
				int index = 0;
				Dictionary<string,List<object>>.KeyCollection.Enumerator enumerator = dictionary.Keys.GetEnumerator ();
				while (enumerator.MoveNext ()) {
					string key = enumerator.Current;
					queryString += string.Format ("{0}={1}", key, ListValues (dictionary [key]));
					index++;
					if (index < dictionary.Keys.Count) {
						queryString += "&";
					}
				}
			} else {
				throw new KeyNotFoundException ("No keys found in dictionary for query string");
			}
			return queryString;
		}

		private static string ListValues(List<object> list)
		{
			string values = "";

			if (list != null) {
				if (list.Count > 1) {
					values += "[";
					if (list != null && list.Count > 0) {
						for (int i = 0; i < list.Count; i++) {
							values += string.Format ("{0}", list [i]);
							if (i + 1 < list.Count) {
								values += ",";
							}
						}
					} 
					values += "]";
				} else {
					values = string.Format ("{0}", list [0]);
				}
			} else {
				throw new ArgumentNullException ("Report List");
			}
			return values;
		}

		public static string FillParam(string value)
		{
			return value.Replace (" ", "+");
		}

		public static string MessageForHttpStatusCode(HttpStatusCode httpStatusCode, string messageError = null)
		{
			string message = null;

			switch (httpStatusCode) {
			case HttpStatusCode.NotFound:
				message = "No se ha encontrado la búsqueda";
				break;
			case HttpStatusCode.InternalServerError:
				message = "Se ha producido un error interno en el servidor";
				break;
			case HttpStatusCode.BadRequest:
				message = "Verificar si hace falta el valor de un campo";
				break;
			default:
				message = messageError ?? "Error al realizar la consulta";
				break;
			}

			return message;
		}

//		public static string QueryStringParamElementArray(string name, Dictionary<string, object> value)
//		{
//			return string.Format ("{0}{1}", name, QueryStringArrayFinalValue (value));
//		}

//		public static string QueryStringParamElementArray(string name,string index, List<Dictionary<string, object>> listValues)
//		{
//			string queryString = "";
//			for (int i = 0; i < listValues.Count; i++) {
//				var dictionary = listValues [i];
//				queryString += string.Format ("{0}[{1}]", name, QueryStringArrayIndex (index, dictionary));
//				if (i + 1 < listValues.Count) {
//					queryString += "&";
//				}
//			}
//			return queryString;
////			foreach (var dictionary in listValues) {
////				queryString += string.Format ("{0}[{1}]", name, QueryStringArrayIndex (key, dictionary));
////			}
//		}
//		public static string QueryStringArrayIndex(string index, Dictionary<string, object> value)
//		{
//			return string.Format ("[{0}]{1}", index, QueryStringArrayFinalValue (value));
//		}

//		public static string QueryStringArrayFinalValue(Dictionary<string, object> dictionary)
//		{
//			//[lat]=32.43561304116276
//			string value = "";
//			foreach (var key in dictionary.Keys) {
//				value += string.Format ("[{0}]={1}", key, dictionary [key]);
//				break;
//			}
//			return value;
//		}

//		public static string testRequest(Dictionary<string, object> dictionary)
//		{
//			string value = "";
//			int index = 0;
//			foreach (var key in dictionary.Keys) {
//				if (typeof(Dictionary<string, object>) == dictionary [key].GetType ()) {
//					value += string.Format ("[{0}]{1}", key, testRequest ((Dictionary<string, object>)dictionary [key]));
//				} else {
//					value += string.Format ("[{0}]={1}", key, dictionary [key]);
//				}
//				index++;
//				if (index < dictionary.Count) {
//					value += "&";
//				}
//			}
//			return value;
//		}
	}
}