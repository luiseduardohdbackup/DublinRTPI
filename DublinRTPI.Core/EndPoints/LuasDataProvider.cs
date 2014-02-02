using System;
using System.Diagnostics;
using System.Collections.Generic;
using DUBLIN_RTPI.Core.Entities;
using DUBLIN_RTPI.Core.Contracs;

namespace DUBLIN_RTPI.Core.EndPoints
{
	public class LuasDataProvider : IEndPoint, IEndPointParser
	{
		public const string STATIONS = "/Content/App/LuasData.json";
		public const string STATION_DETAILS = "http://pipes.yahoo.com/pipes/pipe.run?_id=64aee2afc4e2531bc6ceced68e5a3914&_render=json"; // GET{ get : 'Harcourt' },

		public enum Line {
			Red = 1,
			Green = 2
		}

		public Boolean IsDataServiceOnline(){
			throw new NotImplementedException();
		}

		public List<Route> GetRoutes(){
			return new List<Route>(){
				new Route(Line.Green.ToString(), "Green Line"),
				new Route(Line.Red.ToString(), "Red Line")
			};
		}

		public List<Station> GetStations(){
			return new List<Station>();
		}

		public List<Station> GetStationsByRoute(string routeId){
			try{
				switch (Int32.Parse(routeId)) {

					case (int)Line.Red:
					return new List<Station>();

					case (int)Line.Green:
					return new List<Station>();

					default:
					return new List<Station>();

				}
			}
			catch(Exception ex){
				Debug.WriteLine(ex.Message);
				return new List<Station>();
			}
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