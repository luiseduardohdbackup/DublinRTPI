using System;
using System.Threading.Tasks;
using DUBLIN_RTPI.Core.Entities;
using DUBLIN_RTPI.Core.Contracs;
using DUBLIN_RTPI.Core.EndPoints;

namespace DublinRTPI.Dev
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var bikeSource = new DublinBikeDataProvider();
			var stations = bikeSource.GetStations().Result;
			foreach (var station in stations) {
				var stationDetails = bikeSource.GetStationDetails(station.Id).Result;
				Console.WriteLine(String.Format(
					"{0} / {1} - [{2},{3}] ",
					stationDetails.Id,
					stationDetails.Name,
					stationDetails.Latitude,
					stationDetails.Longitude
				));
			}
			Console.ReadKey();
		}
	}
}