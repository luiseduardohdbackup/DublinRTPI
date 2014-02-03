using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DUBLIN_RTPI.Core.Entities;
using DUBLIN_RTPI.Core.Contracs;

namespace DUBLIN_RTPI.Core.EndPoints
{
	public class BusEireannDataProvider : IEndPoint, IEndPointParser
	{
		public const string ROUTES = "";
		public const string STATIONS = "";
		public const string STATION_DETAILS = "";

		#region IEndPoint

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

		#endregion

		#region IEndPointParser

		public async Task<Route> ParseRoute (string json){
			throw new NotImplementedException();
		}

		public async Task<List<Route>> ParseRoutes(string json){
			throw new NotImplementedException();
		}

		public async Task<Station> ParseStation(string json){
			throw new NotImplementedException();
		}

		public async Task<List<Station>> ParseStations(string json){
			throw new NotImplementedException();
		}

		#endregion
	}
}