using System;
using System.Collections.Generic;

namespace pclSGlocalizacion
{
	public class Tools
	{
		public Tools ()
		{
		}
		private const string LATITUDE = "lat";
		private const string LONGITUDE = "long";
		private const string RADIUS = "radius";
		private const string NAME = "name";
		private const string PUBLIC = "public";

		private const string URL_CIRCLE = "/circles/new";
		public static string Circle(string latitude, string longitude, string radius, string name, 
			Credentials credentials, string userPublic)
		{
			// Generate url
			string url = SGLConstants.URL_HOST + URL_CIRCLE;

			return CircleOrConcernPoint (latitude, longitude, radius, name, credentials, url, userPublic, true);
		}

		private const string URL_CONCERN_POINT = "/locations/new";
		public static string ConcernPoint(string latitude, string longitude, string radius, string name, 
			Credentials credentials, string userPublic)
		{
			// Generate url
			string url = SGLConstants.URL_HOST + URL_CONCERN_POINT;

			return CircleOrConcernPoint (latitude, longitude, radius, name, credentials, url, userPublic);
		}

		private static string CircleOrConcernPoint(string latitude, string longitude, string radius, string name, 
			Credentials credentials, string url, string userPublic, bool circle = false)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> ();
			// fix for get request
			dictionary.Add (ReplaceParamId (LATITUDE, circle), latitude);
			dictionary.Add (ReplaceParamId (LONGITUDE, circle), longitude);
			dictionary.Add (ReplaceParamId (RADIUS, circle), radius);
			dictionary.Add (ReplaceParamId (NAME, circle), name);
			dictionary.Add (ReplaceParamId (PUBLIC, circle), userPublic);

			dictionary.Add (Credentials.ACCESS_TOKEN_KEY, credentials.AccessToken);

			bool status = false;
			// debug only
			//string debugString = url + RestRequests.QueryString (dictionary);
			//
			string data = RestRequests.GetData (url + RestRequests.QueryString (dictionary), out status);

			// TODO 
			//return url + RestRequests.QueryString (dictionary);
			if (status) {
				return data;
			}
			throw new Exception (data);
		}
		
		private static string ReplaceParamId(string value, bool circle)
		{
			return circle ?
				string.Format ("circle[{0}]", value) : 
				string.Format ("location[{0}]", value);
		}

		private const string URL_POLYLINE = "/polylines/new"; 
		public static string Polyline(string queryString, Credentials credentials)
		{
			//string data = RestRequests.GetData (url + RestRequests.QueryString (dictionary)).Result;

			// Generate url
			string url = SGLConstants.URL_HOST + URL_POLYLINE + queryString +
			             "&" + Credentials.ACCESS_TOKEN_KEY + "=" + credentials.AccessToken;

			return RestRequests.FillParam (url);
		}

		private const string URL_POLYGON = "/polygons/new";
		public static string Polygon(string queryString, Credentials credentials)
		{
			// Generate url
			string url = SGLConstants.URL_HOST + URL_POLYGON + queryString +
				"&" + Credentials.ACCESS_TOKEN_KEY + "=" + credentials.AccessToken;

			//return RestRequests.FillParam (url);
			bool status = false;

			string data = RestRequests.GetData (RestRequests.FillParam (url), out status);

			if (status) {
				return data;
			}
			throw new Exception (data);
		}
	}
}

