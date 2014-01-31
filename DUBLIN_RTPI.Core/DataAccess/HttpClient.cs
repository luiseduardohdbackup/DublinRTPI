using System;
using System.Collections.Generic;
//TODO PM> Install-Package Microsoft.Net.Http
// TODO PM> Install-Package Microsoft.Bcl.Async

namespace DUBLIN_RTPI.Core.DataAccess
{
	public class HttpClient
	{
		public string GetJson(string url){
			return this.GetJson (url, new  Dictionary<string,string> ());
		}

		public string GetJson(string url, Dictionary<string,string> parameters){
			throw new NotImplementedException();
		}
	}
}