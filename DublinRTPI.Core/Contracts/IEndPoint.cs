using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DUBLIN_RTPI.Core.Entities;

namespace DUBLIN_RTPI.Core.Contracs
{
	public interface IEndPoint
	{
		Task<Boolean> IsDataServiceOnline();
		Task<List<Route>> GetRoutes();
		Task<List<Station>> GetStations();
		Task<List<Station>> GetStationsByRoute(string routeId);
		Task<Station> GetStationDetails(string stationId);
	}
}