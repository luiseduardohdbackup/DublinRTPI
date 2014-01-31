using System;
using System.Collections.Generic;
using DUBLIN_RTPI.Core.Entities;

namespace DUBLIN_RTPI.Core.Contracs
{
	public interface IEndPoint
	{
		Boolean IsDataServiceOnline();
		List<Route> GetRoutes();
		List<Station> GetStations();
		List<Station> GetStationsByRoute(string routeId);
		Station GetStationDetails(string stationId);
	}
}