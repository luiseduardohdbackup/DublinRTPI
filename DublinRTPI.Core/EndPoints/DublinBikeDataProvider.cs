using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using DUBLIN_RTPI.Core.Entities;
using DUBLIN_RTPI.Core.Contracs;
using DUBLIN_RTPI.Core.DataAccess;

namespace DUBLIN_RTPI.Core.EndPoints
{
	public class DublinBikeDataProvider : IEndPoint, IEndPointParser
	{
		private HttpClientHelper _httpClient;

		public DublinBikeDataProvider() {
			this._httpClient = new HttpClientHelper();
		}

		public const string BASE_URL = "http://pipes.yahoo.com/pipes/pipe.run";
		public const string STATIONS = "102a8e299735b6de44059c9475c1dde7";
		public const string STATION_DETAILS = "4a530c7211bdc27c86096b91a7a5ffae";

		public async Task<Boolean> IsDataServiceOnline()
		{
			try {
				var url = String.Format(
					"?{0}_id{1}&_render=json", 
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
			throw new NotSupportedException();
		}

		public async Task<List<Station>> GetStations(){
			var url = String.Format(
				"{0}?_id={1}&_render=json", 
				DublinBikeDataProvider.BASE_URL,
				DublinBikeDataProvider.STATIONS
			);
			var json = await this._httpClient.GetJson(url);
			return await this.ParseStations(json);
		}

		public async Task<List<Station>> GetStationsByRoute(string routeId){
			throw new NotSupportedException();
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
			var details = await this.ParseStationDetails(json);
			station.VehicleAvailabilityUpdate = details.VehicleAvailabilityUpdate;
			return station;
		}

		#region IEndPointParser

		public async Task<Route> ParseRoute (string json){
			throw new NotImplementedException();
		}

		public async Task<List<Route>> ParseRoutes(string json){
			throw new NotImplementedException();
		}

		public async Task<Station> ParseStationDetails(string json){

			var o = JObject.Parse(json);

			var stationJson = o ["value"]["items"][0];

			var station = new Station () {
				TimeUpdates = null,
				VehicleAvailabilityUpdate = new VehicleAvailabilityUpdate(){
					Available = Int32.Parse(stationJson["available"].ToString()),
					Total = Int32.Parse(stationJson["total"].ToString())
				}
			};
			return station;
		}

		public async Task<Station> ParseStation(string json){

			var stationJson = JObject.Parse(json);

			var station = new Station () {
				Id = stationJson["number"].ToString(),
				Name = stationJson["name"].ToString(),
				Latitude = Double.Parse(stationJson["lat"].ToString()),
				Longitude = Double.Parse(stationJson["lng"].ToString()),
				TimeUpdates = null,
				VehicleAvailabilityUpdate = null
			};

			return station;
		}

		public async Task<List<Station>> ParseStations(string json){
			var stations = new List<Station> ();
			var o = JObject.Parse(json);
			var stationsJson = o ["value"]["items"][0]["markers"] ["marker"].Children<JObject>();
			foreach(var station in stationsJson){
				stations.Add(await this.ParseStation(station.ToString()));
			}
			return stations;
		}

		#endregion
	}
}