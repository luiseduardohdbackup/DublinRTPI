using System;
using System.Collections.Generic;
using DUBLIN_RTPI.Core.Entities;
using DUBLIN_RTPI.Core.Contracs;

namespace DUBLIN_RTPI.Core.Contracs
{
	public interface IEndPointParser
	{
		Route ParseRoute (string json);
		List<Route> ParseRoutes(string json);
		Station ParseStation(string json);
		List<Station> ParseStations(string json);
	}
}