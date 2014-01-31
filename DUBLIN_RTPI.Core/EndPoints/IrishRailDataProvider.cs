using System;
using System.Collections.Generic;
using DUBLIN_RTPI.Core.Entities;
using DUBLIN_RTPI.Core.Contracs;

namespace DUBLIN_RTPI.Core.EndPoints
{
	public class IrishRailDataProvider : IEndPoint, IEndPointParser
	{
		public const string STATIONS = "http://pipes.yahoo.com/pipes/pipe.run?_id=eba0f0898e71d306b22145c67117519c&_render=json";
		public const string STATION_DETAILS = "http://pipes.yahoo.com/pipes/pipe.run?_id=1561ece94621bf3972ee5bd94572d2e4&_render=json"; // { StationCode: 'GCDK' }

		#region IEndPoint

		public Boolean IsDataServiceOnline(){
			throw new NotImplementedException();
		}

		public List<Route> GetRoutes(){
			throw new NotImplementedException();
		}

		public List<Station> GetStations(){
			throw new NotImplementedException();
		}

		public List<Station> GetStationsByRoute(string routeId){
			throw new NotImplementedException();
		}

		public Station GetStationDetails(string stationId){
			throw new NotImplementedException();
		}

		#endregion

		#region IEndPointParser

		public Route ParseRoute (string json){
			throw new NotImplementedException();
		}

		public List<Route> ParseRoutes(string json){
			throw new NotImplementedException();
		}

		public Station ParseStation(string json){
			throw new NotImplementedException();
		}

		public List<Station> ParseStations(string json){
			throw new NotImplementedException();
		}

		#endregion
	}
}