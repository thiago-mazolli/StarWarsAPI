using System.IO;
using System.Net;
using System.Web.Helpers;

namespace Business.Models
{
	public class dRequestApi
	{
		public static dynamic Request(string pCategoria, string pUrlId)
		{
			var url = pUrlId ?? "https://swapi.dev/api/" + pCategoria.ToLower() + "/";

			var requestSWApi = WebRequest.CreateHttp(url);
			requestSWApi.Method = "GET";
			requestSWApi.UserAgent = "RequisicaoWebDemo";

			using(var request = requestSWApi.GetResponse())
			{
				var streamDados = request.GetResponseStream();
				StreamReader reader = new StreamReader(streamDados);
				object objResponse = reader.ReadToEnd();

				dynamic json = Json.Decode(objResponse.ToString());

				reader.Dispose();
				streamDados.Close();
				request.Close();

				return json;
			}
		}
	}
}
