using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json.Linq;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;

namespace DublinRTPI.Core.EndPointParser
{
	internal class IrishRailDataParser : IEndPointParser
	{
		public Station ParseStationDetails(string json){

			var station = new Station () {
				TimeUpdates = new List<TimeUpdate>()
			};

			var o = JObject.Parse(json);
			var stationJson = o["value"]["items"].Children<JObject>();

			foreach (var time in stationJson) {
				station.TimeUpdates.Add(new TimeUpdate(){
					Traincode = time["Traincode"].ToString(),
					Destination = time["Destination"].ToString(),
					Time = time["Exparrival"].ToString()
				});
			}

			return station;
		}

		public Station ParseStation(string json){

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

		public List<Station> ParseStations(string json){
			var stations = new List<Station> ();
			var o = JObject.Parse(json);
			var stationsJson = o ["value"]["items"].Children<JObject>();
			foreach(var station in stationsJson){
				stations.Add(this.ParseStation(station.ToString()));
			}
			return stations;
		}

		public List<Route> ParseRoutes(string json) {
			throw new NotSupportedException();
		}

		public Route ParseRoute(string json) {
			throw new NotSupportedException();
		}

		public Route ParseRouteDetails(string json) {
			throw new NotSupportedException();
		}
	}
}