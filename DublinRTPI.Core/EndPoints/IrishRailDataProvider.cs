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
	internal class IrishRailDataProvider : IEndPoint
	{

		public const string BASE_URL = "http://pipes.yahoo.com/pipes/pipe.run";
		public const string STATIONS = "eba0f0898e71d306b22145c67117519c";
		public const string STATION_DETAILS = "1561ece94621bf3972ee5bd94572d2e4";

		private HttpClientHelper _httpClient;
		private IEndPointParser _dataParser;

		public IrishRailDataProvider() {
			this._httpClient = new HttpClientHelper();
			this._dataParser = new IrishRailDataParser();
		}

		public async Task<Boolean> IsDataServiceOnline(){
			try {
				var url = String.Format(
					"{0}?_id={1}&_render=json", 
					IrishRailDataProvider.BASE_URL,
					IrishRailDataProvider.STATIONS
				);
				await this._httpClient.GetJson(url);
				return true;
			}
			catch(Exception ex){
				Debug.WriteLine(ex.Message);
				return false;
			}
		}

		public async Task<List<Route>> GetRoutes(){
			throw new NotSupportedException();
		}

		public async Task<List<Station>> GetStations(){
			var url = String.Format(
				"{0}?_id={1}&_render=json", 
				IrishRailDataProvider.BASE_URL,
				IrishRailDataProvider.STATIONS
			);
			var json = await this._httpClient.GetJson(url);
			return this._dataParser.ParseStations(json);
		}

		public async Task<List<Station>> GetStationsByRoute(string routeId){
			throw new NotSupportedException();
		}

		public async Task<Station> GetStationDetails(string stationId){

			var stations = await this.GetStations();
			var station = stations.Where (s => s.Id.ToString().Equals(stationId)).First();

			var url = String.Format(
				"{0}?_id={1}&_render=json&StationCode={2}", 
				IrishRailDataProvider.BASE_URL,
				IrishRailDataProvider.STATION_DETAILS,
				stationId
			);
			var json = await this._httpClient.GetJson(url);
			var details = this._dataParser.ParseStationDetails(json);
			station.TimeUpdates = details.TimeUpdates;
			return station;
		}
	}
}