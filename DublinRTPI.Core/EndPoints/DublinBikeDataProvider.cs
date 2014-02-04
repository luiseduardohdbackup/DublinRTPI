using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;
using DublinRTPI.Core.DataAccess;
using DublinRTPI.Core.EndPointParser;

namespace DublinRTPI.Core.EndPoints
{
	internal class DublinBikeDataProvider : IEndPoint
	{
		public const string BASE_URL = "http://pipes.yahoo.com/pipes/pipe.run";
		public const string STATIONS = "102a8e299735b6de44059c9475c1dde7";
		public const string STATION_DETAILS = "4a530c7211bdc27c86096b91a7a5ffae";

		private HttpClientHelper _httpClient;
		private IEndPointParser _dataParser;

		public DublinBikeDataProvider() {
			this._httpClient = new HttpClientHelper();
			this._dataParser = new DublinBikeDataParser();
		}

		public async Task<Boolean> IsDataServiceOnline()
		{
			try {
				var url = String.Format(
					"{0}?_id={1}&_render=json", 
					DublinBikeDataProvider.BASE_URL,
					DublinBikeDataProvider.STATIONS
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
			throw new NotSupportedException ();
		}

		public async Task<List<Station>> GetStationsByRoute(string routeId){
			throw new NotSupportedException ();
		}

		public async Task<List<Station>> GetStations(){
			var url = String.Format(
				"{0}?_id={1}&_render=json", 
				DublinBikeDataProvider.BASE_URL,
				DublinBikeDataProvider.STATIONS
			);
			var json = await this._httpClient.GetJson(url);
			return this._dataParser.ParseStations(json);
		}

		public async Task<Station> GetStationDetails(string stationId){

			var stations = await this.GetStations();
			var station = stations.Where (s => s.Id.ToString().Equals(stationId)).First();

			var url = String.Format(
				"{0}?_id={1}&_render=json&station={2}", 
				DublinBikeDataProvider.BASE_URL,
				DublinBikeDataProvider.STATION_DETAILS,
				stationId
			);
			var json = await this._httpClient.GetJson(url);
			var details = this._dataParser.ParseStationDetails(json);
			station.VehicleAvailabilityUpdate = details.VehicleAvailabilityUpdate;
			return station;
		}
	}
}