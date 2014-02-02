using System;
using System.Collections.Generic;
using DUBLIN_RTPI.Core.Entities;
using DUBLIN_RTPI.Core.Contracs;

namespace DUBLIN_RTPI.Core.EndPoints
{
	public class DublinBussDataProvider : IEndPoint, IEndPointParser
	{
		public const string ROUTES = "";
		public const string STATIONS = "";
		public const string STATION_DETAILS = "";

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