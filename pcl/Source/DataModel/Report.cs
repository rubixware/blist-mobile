using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace pclSGlocalizacion
{
	public class ReportFile
	{
		public string Name { get; set; }
		public string Extension { get; set; }
		public string Id { get; set; }


		public override string ToString ()
		{
			return (Id != null) ? string.Format ("{0}_{1}", Id, Name) : Name;
		}
	}

	public class Report
	{
		private const string INITIAL_DATE = "initial";
		private const string FINAL_DATE = "final";
		private const string DEVICE_ID = "device_id";
		private const string GROUP_ID = "group_id";
		private const string SPEED = "speed";
		private const string COLOR = "color";

		public static ReportFile BinnacleFile = new ReportFile (){
			Name = "Reporte de Bitacora",
			Extension = "csv"
		};

		public static ReportFile EventsFile = new ReportFile (){
			Name = "Consolidado de Eventos",
			Extension = "csv"
		};

		public static ReportFile HistoryFile = new ReportFile (){
			Name = "Reporte de Historial",
			Extension = "csv"
		};

		public static ReportFile OdometerFile = new ReportFile (){
			Name = "Reporte de Odometro",
			Extension = "csv"
		};

		public static ReportFile RouteFile = new ReportFile (){
			Name = "Reporte Por Ruta",
			Extension = "csv"
		};

		public static ReportFile SpeedFile = new ReportFile (){
			Name = "Excesos de Velocidad",
			Extension = "csv"
		};

		public static ReportFile StopsFile = new ReportFile (){
			Name = "Reporte de Paradas",
			Extension = "csv"
		};

		public static ReportFile TemperatureFile = new ReportFile (){
			Name = "Reporte de Temperaturas",
			Extension = "csv"
		};

		public static ReportFile ZoneFile = new ReportFile (){
			Name = "Reporte de Zonas",
			Extension = "csv"
		};

		public static string Binnacle(string initialDate , string finalDate, int groupId, Credentials credentials)
		{
			return RestRequests.QueryString (Generate (initialDate, finalDate, null, groupId.ToString(), credentials));
		}

		public static string Consolidated(string initialDate , string finalDate, string initialTime, string finalTime,Credentials credentials)
		{
			return RestRequests.QueryString (Generate (initialDate, finalDate, null, null, credentials, initialTime, finalTime));
		}

		public static string History(string initialDate , string finalDate, int deviceId, string initialTime, string finalTime, Credentials credentials)
		{
			return RestRequests.QueryString (Generate (initialDate, finalDate, (deviceId != 0)? new List<int>{deviceId} : null, null, credentials, initialTime, finalTime));
		}

		public static string Odometer(string initialDate , string finalDate, int deviceId, Credentials credentials)
		{
			return RestRequests.QueryString (Generate (initialDate, finalDate, (deviceId != 0)? new List<int>{deviceId} : null, null, credentials));
		}

		public static string Route(string initialDate , string finalDate, string initialTime, string finalTime, int deviceId,Credentials credentials)
		{
			return RestRequests.QueryString (Generate (initialDate, finalDate, (deviceId != 0)? new List<int>{deviceId} : null, null, credentials, initialTime, finalTime));
		}

		public static string DrawRoute(string initialDate , string finalDate, string initialTime, string finalTime, int deviceId,Credentials credentials)
		{
			return RestRequests.QueryString (Generate (initialDate, finalDate, (deviceId != 0)? new List<int>{deviceId} : null, null, credentials, initialTime, finalTime));
		}

		public static string Speed(string initialDate , string finalDate, string initialTime, string finalTime, IList<int> listDeviceId, int groupId, string speed, Credentials credentials)
		{
			Dictionary<string, List<object>> dictionary = Generate (initialDate, finalDate, listDeviceId, 
				groupId.ToString(), credentials, initialTime, finalTime);
			List<object> extraValue = new List<object> ();
			extraValue.Add (speed);
			dictionary.Add (SPEED, extraValue);
			return RestRequests.QueryString (dictionary);
		}

		public static string Stops(string initialDate , string finalDate, string initialTime, string finalTime, IList<int> listDeviceId, int groupId, Credentials credentials)
		{
			return RestRequests.QueryString (Generate (initialDate, finalDate, listDeviceId, 
				groupId.ToString(), credentials, initialTime, finalTime));
		}

		public static string Temperature(string initialDate , string finalDate,  string initialTime, string finalTime, IList<int> listDeviceId, Credentials credentials)
		{
			return RestRequests.QueryString (Generate (initialDate, finalDate, listDeviceId, null, credentials, initialTime, finalTime));
		}

		public static string Zone(string initialDate , string finalDate, string initialTime, string finalTime, IList<int> listDeviceId, int groupId, Credentials credentials)
		{
			return RestRequests.QueryString (Generate (initialDate, finalDate, listDeviceId, 
				groupId.ToString(), credentials, initialTime, finalTime));
		}

		private static Dictionary<string, List<object>> Generate(string initialDate , string finalDate, 
			IList<int> listDeviceId, string groupId,Credentials credentials, string initialTime = null, string finalTime = null)
		{
			List<object> values;
			Dictionary<string, List<object>> dictionary = new Dictionary<string, List<object>> ();

			values = new List<object> ();
			values.Add (initialTime != null ? FillParam(string.Format ("{0} {1}", initialDate, initialTime)) : initialDate);
			dictionary.Add (INITIAL_DATE, values);

			values = new List<object> ();
			values.Add (finalTime != null ? FillParam(string.Format ("{0} {1}", finalDate, finalTime)) : finalDate);
			dictionary.Add (FINAL_DATE, values);

			if (listDeviceId != null && listDeviceId.Count > 0) {
				values = new List<object> ();
				foreach (int id in listDeviceId) {
					values.Add (id);
				}
				dictionary.Add (DEVICE_ID, values);
			}
			if (groupId != null) {
				values = new List<object> ();
				values.Add (groupId);
				dictionary.Add (GROUP_ID, values);
			}

			values = new List<object> ();
			values.Add (credentials.AccessToken);
			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, values);

			return dictionary;
		}

		private static string FillParam(string value)
		{
			return value.Replace (" ", "+");
		}

		async public static System.Threading.Tasks.Task<string> DrawRouteData(string queryString, Credentials credentials)
		{
			string url = SGLConstants.URL_HOST + queryString;
			
			//string data = await RestRequests.GetData (url);

//			Settings settings = JsonConvert.DeserializeObject<Settings> (data, new JsonSerializerSettings () {
//				NullValueHandling = NullValueHandling.Ignore
//			});

			return url;
		}
	}
}