using System;
using System.Collections.Generic;
using DUBLIN_RTPI.Core.Entities;
using DUBLIN_RTPI.Core.Contracs;

namespace DUBLIN_RTPI.Core.EndPoints
{
	public class DublinBikeDataProvider : IEndPoint, IEndPointParser
	{
		public const string BASE_URL = "http://pipes.yahoo.com/pipes/pipe.run";
		// ?_id=
		public const string STATIONS = "102a8e299735b6de44059c9475c1dde7";
		public const string STATION_DETAILS = "102a8e299735b6de44059c9475c1dde7";
		// &_render=json // GET { station : 37 }

		public Boolean IsDataServiceOnline()
		{
			throw new NotImplementedException();
		}

		public List<Route> GetRoutes(){
			throw new NotSupportedException();
		}

		public List<Station> GetStations(){
			return new List<Station>();
		}

		public List<Station> GetStationsByRoute(string routeId){
			throw new NotSupportedException();
		}

		public Station GetStationDetails(string stationId){
			return new Station();
		}

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