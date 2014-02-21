using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net;

namespace DublinRTPI.Core.DataAccess
{
	internal class HttpClientHelper
	{
		public async Task<string> GetJson(string url, Dictionary<string,string> parameters = null){
			// parameters?
			if (parameters != null) {
				if (parameters.Count > 0) {
					url += "?";
					foreach(var key in parameters.Keys){

						// add parameter to url
						url += String.Format("{0}={1}", key, parameters[key]);

						// more parameters?
						if(!parameters.Keys.Last ().Equals(key)){
							url += "&";
						}
					}
				}
			}
			// send request
			var uri = new Uri(url);
			var client = new HttpClient();
			return await client.GetStringAsync(uri);
		}

        public async Task<string> PostJson(string url, string body)
        {
			var uri = new Uri(url);
			var client = new HttpClient();
			var content = new StringContent (body, Encoding.UTF8, "application/json");
			var response = await client.PostAsync (uri, content);
			return await response.Content.ReadAsStringAsync ();
        }
	}
}