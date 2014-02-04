using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json.Linq;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;

namespace DublinRTPI.Core.EndPointParser
{
	internal class BusEireannDataParser : IEndPointParser
	{
		public Station ParseStationDetails(string json){
			throw new NotSupportedException();
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