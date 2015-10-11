using System;

namespace pclSGlocalizacion
{
	public static class Helper
	{
		public static string GenerateErrorMessage(System.Collections.Generic.List<string> listMessages, string message)
		{
			for (int i = 0; i < listMessages.Count; i++) {
				message += listMessages [i];
				if (i + 1 < listMessages.Count) {
					message += ", ";
				}
			}
			return message;
		}
	}
}

