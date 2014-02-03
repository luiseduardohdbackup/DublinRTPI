using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DUBLIN_RTPI.Core.Entities;
using DUBLIN_RTPI.Core.Contracs;

namespace DUBLIN_RTPI.Core.Contracs
{
	public interface IEndPointParser
	{
		Task<Route> ParseRoute (string json);
		Task<List<Route>> ParseRoutes(string json);
		Task<Station> ParseStation(string json);
		Task<List<Station>> ParseStations(string json);
	}
}