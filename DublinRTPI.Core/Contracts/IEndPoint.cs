using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DublinRTPI.Core.Entities;

namespace DublinRTPI.Core.Contracs
{
	internal interface IEndPoint
	{
		Task<Boolean> IsDataServiceOnline();
		Task<List<Route>> GetRoutes();
		Task<List<Station>> GetStations();
		Task<List<Station>> GetStationsByRoute(string routeId);
		Task<Station> GetStationDetails(string stationId);
	}
}