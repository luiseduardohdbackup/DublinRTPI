using System;
using System.Collections.Generic;
using DublinRTPI.Core.Entities;
using System.Threading.Tasks;

namespace DublinRTPI.Core.Contracs
{
	public interface IDataController
	{
		Task<Boolean> IsServiceAvailable(ServiceProviderEnum serviceProvider);
		Task<List<Station>> GetStations(ServiceProviderEnum serviceProvider);
		Task<Station> GetStationDetails(ServiceProviderEnum serviceProvider, string id);
		Task<List<Route>> GetRoutes(ServiceProviderEnum serviceProvider);
		Task<List<Station>> GetStationsByRoute(ServiceProviderEnum serviceProvider, string routeId);
	}
}