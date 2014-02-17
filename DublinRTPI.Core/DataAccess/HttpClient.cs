using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
			var req = new HttpClient();
			return await req.GetStringAsync(uri);
		}

        public async Task<string> PostJson(string url, string body)
        {
            // send request
            var uri = new Uri(url);
            var req = new HttpClient();
            // TODO "Content-Type" = "application/json; charset=UTF-8";
            return await req.GetStringAsync(uri);
        }
	}
}