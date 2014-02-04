using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json.Linq;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;

namespace DublinRTPI.Core.EndPointParser
{
	internal class DublinBikeDataParser : IEndPointParser
	{
		public Station ParseStationDetails(string json){

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

		public Station ParseStation(string json){

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

		public List<Station> ParseStations(string json){
			var stations = new List<Station> ();
			var o = JObject.Parse(json);
			var stationsJson = o ["value"]["items"][0]["markers"] ["marker"].Children<JObject>();
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