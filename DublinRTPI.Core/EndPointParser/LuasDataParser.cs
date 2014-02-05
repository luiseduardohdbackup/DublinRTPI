using System;
using System.Linq;
using System.Collections.Generic;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace DublinRTPI.Core.EndPointParser
{
	internal class LuasDataParser : IEndPointParser
	{
		public Station ParseStationDetails(string json){
			var o = JObject.Parse(json);
			if (o["value"]["items"].Children().FirstOrDefault() != null) {
				var html = o["value"]["items"][0]["col_1"].ToString();

				string[] values = html.Split(
					new string[] { 
						"<div class=\"Outbound\"><h4>Outbound</h4>",
						"<div class=\"Inbound\"><h4>Inbound</h4>",
						"<div class=\"location\">",
						"<div class=\"time\">",
						"</div>",
						"No trams forecast"
					},
					StringSplitOptions.RemoveEmptyEntries);

				var timeUpdates = new List<TimeUpdate>();
				var currentTimeUpdate = new TimeUpdate();
				for(var i = 0; i < values.Length; i++){
					if (i % 2 == 0) {
						currentTimeUpdate = new TimeUpdate();
						currentTimeUpdate.Destination = values[i];
						currentTimeUpdate.Traincode = values[i];
					} else {
						currentTimeUpdate.Time = values[i];
						timeUpdates.Add(currentTimeUpdate);
					}
				}
				return new Station(){ TimeUpdates = timeUpdates };
			}
			return new Station(){ TimeUpdates = new List<TimeUpdate>() };
		}

		public Station ParseStation(string json){
			throw new NotSupportedException();
		}

		public List<Station> ParseStations(string json){
			throw new NotSupportedException();
		}

		public List<Route> ParseRoutes(string json){
			throw new NotSupportedException();
		}

		public Route ParseRoute(string json){
			throw new NotSupportedException();
		}

		public Route ParseRouteDetails(string json){
			throw new NotSupportedException();
		}
	}
}