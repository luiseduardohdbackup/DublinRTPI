using System;
using System.Collections.Generic;
using DUBLIN_RTPI.Core.Entities;

namespace DUBLIN_RTPI.Core.EndPoints
{
	public interface IEndPoint
	{
		List<Route> GetRoutes();
		List<Station> GetStations();
		List<Station> GetStationsByRoute(string routeId);
		List<Station> GetStationDetails(string stationId);
	}
}