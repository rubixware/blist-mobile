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
	public class RestRequests
	{
		[JsonProperty ("errors")]
		public System.Collections.Generic.IList<Error> Errors { get; set; }

		public static HttpResponseMessage LastHttpResponseMessage { get; set; }

		public static string PostData(string url, Object data, out bool status)
		{
			try {
				HttpClient httpClient = new HttpClient (new NativeMessageHandler ());
				
				// Serialize data to send
				string dataToSend = JsonConvert.SerializeObject (data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
				
				// Create content body
				HttpContent httpContent = new StringContent (dataToSend, System.Text.Encoding.UTF8, "application/json");
				httpClient.DefaultRequestHeaders.Add ("Accept",new List<string>{"application/vnd.blistapi.v1", "application/json"});

				// Execute request and await for response
				HttpResponseMessage httpResponseMessage = httpClient.PostAsync (url, httpContent).Result;

				// save response message for further access
				LastHttpResponseMessage = httpResponseMessage;

				// Return the success response from request
				if (httpResponseMessage.IsSuccessStatusCode) {
					status = true;
					return httpResponseMessage.Content.ReadAsStringAsync ().Result;
				}
				status = false;
				return ServerCodesCustomMessages (httpResponseMessage.Content.ReadAsStringAsync ().Result);
			} catch (Exception ex) {
				throw(ex);
			}
		}

		async public static Task<string> GetData(string url)
		{
			HttpClient httpClient = new HttpClient (new NativeMessageHandler ());

			// Execute request and await for response
			HttpResponseMessage httpResponseMessage = httpClient.GetAsync (url).Result;
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
			httpClient.DefaultRequestHeaders.Add ("Accept",new List<string>{"application/vnd.blistapi.v1", "application/json"});

			// Execute request and await for response
			HttpResponseMessage httpResponseMessage = httpClient.GetAsync (url).Result;
			// save response message for further access
			LastHttpResponseMessage = httpResponseMessage;

			// Return the success response from request
			if (httpResponseMessage.IsSuccessStatusCode) {
				status = true;
				return httpResponseMessage.Content.ReadAsStringAsync ().Result;
			}
			status = false;
			return ServerCodesCustomMessages (httpResponseMessage.Content.ReadAsStringAsync ().Result);
		}

		private static string ServerCodesCustomMessages(string response)
		{
			string message = "";

			RestRequests request = JsonConvert.DeserializeObject<RestRequests>(response, new JsonSerializerSettings () {
				NullValueHandling = NullValueHandling.Ignore});
			for (int i = 0; i < request.Errors.Count; i++) {
				message += request.Errors [i];
				if (i + 1 < request.Errors.Count) {
					message += ", ";
				}
			}
			return message;
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
	}
}