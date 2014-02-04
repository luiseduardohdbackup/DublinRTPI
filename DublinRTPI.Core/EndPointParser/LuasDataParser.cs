using System;
using System.Linq;
using System.Collections.Generic;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;
using Newtonsoft.Json.Linq;

namespace DublinRTPI.Core.EndPointParser
{
	internal class LuasDataParser : IEndPointParser
	{
		public Station ParseStationDetails(string json){
			var o = JObject.Parse(json);
			if (o["value"]["items"].Children().FirstOrDefault() != null) {
				var html = o["value"]["items"][0]["col_1"].ToString();
				html = html.ToString();
				// TODO
				return new Station(){ 
					TimeUpdates = new List<TimeUpdate>(){ 
						new TimeUpdate(){ Traincode = html} 
					} 
				};
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