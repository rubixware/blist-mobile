using System;
using Newtonsoft.Json;

namespace pclSGlocalizacion
{
	public class DateFormatBean : Setting
	{
		[JsonProperty ("format")]
		public string Format { get; set; }

		[JsonIgnore]
		public static string UserFormat = "MM/dd/yyyy"; // Bussiness Rule - date format for date pickers
		[JsonIgnore]
		public static string RequestFormatDate = "dd/MM/yyyy"; // Bussiness Rule - date format of params in request
		[JsonIgnore]
		public static string RequestFormatTime = "hh:mm tt"; // Bussiness Rule - time format of params in request

		public DateFormatBean ()
		{
		}

		public override string Description {
			get {
				return Format;
			}
		}
	}
}

