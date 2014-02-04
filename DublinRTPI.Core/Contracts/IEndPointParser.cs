using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;

namespace DublinRTPI.Core.Contracs
{
	internal interface IEndPointParser
	{
		Station ParseStationDetails(string json);
		Station ParseStation(string json);
		List<Station> ParseStations(string json);
		List<Route> ParseRoutes(string json);
		Route ParseRoute(string json);
		Route ParseRouteDetails(string json);
	}
}