using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;
using DublinRTPI.Core.DataAccess;
using DublinRTPI.Core.EndPointParser;

namespace DublinRTPI.Core.EndPoints
{
	internal class BusEireannDataProvider : IEndPoint
	{
		public const string ROUTES = "";
		public const string STATIONS = "";
		public const string STATION_DETAILS = "";

		private HttpClientHelper _httpClient;
		private IEndPointParser _dataParser;

		public BusEireannDataProvider() {
			this._httpClient = new HttpClientHelper();
			this._dataParser = new BusEireannDataParser();
		}

		public async Task<Boolean> IsDataServiceOnline(){
			throw new NotImplementedException();
		}

		public async Task<List<Route>> GetRoutes(){
			throw new NotImplementedException();
		}
			
		public async Task<List<Station>> GetStations(){
			throw new NotImplementedException();
		}

		public async Task<List<Station>> GetStationsByRoute(string routeId){
			throw new NotImplementedException();
		}
			
		public async Task<Station> GetStationDetails(string stationId){
			throw new NotImplementedException();
		}
	}
}