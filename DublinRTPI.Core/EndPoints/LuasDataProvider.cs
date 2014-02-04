using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;
using DublinRTPI.Core.DataAccess;
using DublinRTPI.Core.EndPointParser;

namespace DublinRTPI.Core.EndPoints
{
	internal class LuasDataProvider : IEndPoint
	{
		public const string BASE_URL = "http://pipes.yahoo.com/pipes/pipe.run";
		public const string STATION_DETAILS = "64aee2afc4e2531bc6ceced68e5a3914";

		private HttpClientHelper _httpClient;
		private IEndPointParser _dataParser;

		public LuasDataProvider() {
			this._httpClient = new HttpClientHelper();
			this._dataParser = new LuasDataParser();
		}

		public async Task<Boolean> IsDataServiceOnline(){
			try {
				var url = String.Format(
					"{0}?_id={1}&_render=json&get={2}", 
					DublinBikeDataProvider.BASE_URL,
					DublinBikeDataProvider.STATION_DETAILS,
					"Harcourt"
				);
				await this._httpClient.GetJson(url);
				return true;
			}
			catch(Exception ex){
				Debug.WriteLine(ex.Message);
				return false;
			}
		}
			
		public Task<List<Route>> GetRoutes(){
			throw new NotSupportedException ();
		}
		public Task<List<Station>> GetStationsByRoute(string routeId){
			throw new NotSupportedException ();
		}

		public async Task<List<Station>> GetStations(){
			return LuasData.STATIONS;
		}

		public async Task<Station> GetStationDetails(string stationId){

			var stations = await GetStations();
			var station = stations.Where (s => s.Id.ToString().Equals(stationId)).First();

			var url = String.Format(
				"{0}?_id={1}&_render=json&get={2}", 
				LuasDataProvider.BASE_URL,
				LuasDataProvider.STATION_DETAILS,
				stationId.Replace(" ", "%20").Replace("'", "%27")
			);

			var json = await this._httpClient.GetJson(url);
			var details = this._dataParser.ParseStationDetails(json);
			station.TimeUpdates = details.TimeUpdates;
			return station;
		}
	}
}