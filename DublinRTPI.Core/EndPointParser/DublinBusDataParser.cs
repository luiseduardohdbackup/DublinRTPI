using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json.Linq;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;
using System.Globalization;

namespace DublinRTPI.Core.EndPointParser
{
	internal class DublinBusDataParser : IEndPointParser
	{

        string ExtractString(string s, string start, string end) {
            int startIndex = s.IndexOf(start) + start.Length;
            int endIndex = s.IndexOf(end, startIndex);
            if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
            {
                return s.Substring(startIndex, endIndex - startIndex);
            }
            else {
                return s;
            }
        }

        public Station ParseStationDetails(string html)
        {
            var station = new Station() { 
                TimeUpdates = new List<TimeUpdate>()
            };
            try
            {
                var start = @"<table id=""rtpi-results"" cellspacing=""0"">";
                var end = @"<table id=""rtpi-stops-key"">";
                html = ExtractString(html, start, end).Replace("</table>", String.Empty);

                string[] rows = html.Split(
                    new string[] { 
                        @"<tr class=""odd"">", 
                        @"<tr class=""even"">"
                    },
                    StringSplitOptions.RemoveEmptyEntries
                );

                for (var i = 0; i < rows.Length; i++)
                {
                    if (i > 0)
                    {
                        var row = rows[i];

                        string[] details = row.Split(
                            new string[] { 
                                @"<td>",
                                @"</td>"
                            },
                            StringSplitOptions.RemoveEmptyEntries
                        );

						var timeUpdate = new TimeUpdate() 
						{
							Time = details[5].Replace("\r\n", String.Empty).Trim(),
							Destination = details[3].Replace("\r\n", String.Empty).Trim(),
							Traincode = details[1].Replace("\r\n", String.Empty).Trim()
						};
						station.TimeUpdates.Add(timeUpdate);
                    }
                }
                return station;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
		}

		public Station ParseStation(string json){
            var o = JObject.Parse(json);
            return new Station()
            {
				Id = o["StopRef"].ToString(), //PublicAccessCode
                Name = o["StopNameShort"].ToString(),
                Longitude = Double.Parse(o["Longitude"].ToString()),
                Latitude = Double.Parse(o["Latitude"].ToString()),
                TimeUpdates = null,
                VehicleAvailabilityUpdate = null
            };
		}

		public List<Station> ParseStations(string json){
            var stations = new List<Station>();
            var o = JObject.Parse(json);
            var stationsNode = o["d"].ToString().Replace("ServiceDataResponse=", String.Empty);
            var stationsJson = JObject.Parse(stationsNode)["AllStops"];
            foreach (var stationJson in stationsJson)
            {
                stations.Add(this.ParseStation(stationJson.ToString()));
            }
            return stations;
		}

		public List<Route> ParseRoutes(string json){
            var routes = new List<Route>();
            var o = JObject.Parse(json);
            var routesJson = o["d"]["Items"];
            foreach (var routeJson in routesJson)
            {
                var route = this.ParseRoute(routeJson.ToString());
                if(route != null){
                    routes.Add(route);
                }
            }
            return routes;
		}

		public Route ParseRoute(string json){
            var o = JObject.Parse(json);
            if (o["Enabled"].ToString() == "True")
            {
                return new Route()
                {
                    Id = o["Value"].ToString(),
                    Name = o["Text"].ToString()
                };
            }
            else {
                return null;
            }
		}

		public Route ParseRouteDetails(string json){
			throw new NotSupportedException();
		}
	}
}