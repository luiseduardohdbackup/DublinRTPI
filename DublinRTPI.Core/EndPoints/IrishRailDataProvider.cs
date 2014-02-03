using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using DUBLIN_RTPI.Core.Entities;
using DUBLIN_RTPI.Core.Contracs;
using DUBLIN_RTPI.Core.DataAccess;

namespace DUBLIN_RTPI.Core.EndPoints
{
	public class IrishRailDataProvider : IEndPoint, IEndPointParser
	{
		private HttpClientHelper _httpClient;

		public IrishRailDataProvider() {
			this._httpClient = new HttpClientHelper();
		}

		public const string BASE_URL = "http://pipes.yahoo.com/pipes/pipe.run";
		public const string STATIONS = "eba0f0898e71d306b22145c67117519c";
		public const string STATION_DETAILS = "1561ece94621bf3972ee5bd94572d2e4";

		#region IEndPoint

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
			throw new NotImplementedException();
		}

		public async Task<List<Station>> GetStations(){
			var url = String.Format(
				"{0}?_id={1}&_render=json", 
				IrishRailDataProvider.BASE_URL,
				IrishRailDataProvider.STATIONS
			);
			var json = await this._httpClient.GetJson(url);
			return await this.ParseStations(json);
		}

		public async Task<List<Station>> GetStationsByRoute(string routeId){
			throw new NotImplementedException();
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
			var details = await this.ParseStationDetails(json);
			station.TimeUpdates = details.TimeUpdates;
			return station;
		}

		#endregion

		#region IEndPointParser

		public async Task<Route> ParseRoute (string json){
			throw new NotImplementedException();
		}

		public async Task<List<Route>> ParseRoutes(string json){
			throw new NotImplementedException();
		}

		public async Task<Station> ParseStationDetails(string json){

			var station = new Station () {
				TimeUpdates = new List<TimeUpdate>()
			};

			var o = JObject.Parse(json);
			var stationJson = o["value"]["items"].Children<JObject>();

			foreach (var time in stationJson) {
				station.TimeUpdates.Add(new TimeUpdate(){
					Traincode = stationJson["Traincode"].ToString(),
					Destination = stationJson["Destination"].ToString(),
					Time = stationJson["Exparrival"].ToString()
				});
			}

			return station;
		}

		public async Task<Station> ParseStation(string json){

			var stationJson = JObject.Parse(json);

			var station = new Station () {
				Id = stationJson["StationCode"].ToString(),
				Name = stationJson["StationDesc"].ToString(),
				Latitude = Double.Parse(stationJson["StationLatitude"].ToString()),
				Longitude = Double.Parse(stationJson["StationLongitude"].ToString()),
				TimeUpdates = null,
				VehicleAvailabilityUpdate = null
			};

			return station;
		}

		public async Task<List<Station>> ParseStations(string json){
			var stations = new List<Station> ();
			var o = JObject.Parse(json);
			var stationsJson = o ["value"]["items"].Children<JObject>();
			foreach(var station in stationsJson){
				stations.Add(await this.ParseStation(station.ToString()));
			}
			return stations;
		}

		#endregion
	}
}