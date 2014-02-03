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
			TestBikes();
			Console.ReadKey();
			TestRail();
			Console.ReadKey();
			TestLuas ();
			Console.ReadKey();
		}

		public static void TestLuas(){
			Console.WriteLine ("\n\nLUAS:\n");
			// TODO
		}

		public static void TestRail(){
			Console.WriteLine ("\n\nIRISH RAIL:\n");
			var railSource = new IrishRailDataProvider();
			var stations = railSource.GetStations().Result;
			foreach (var station in stations) {
				var stationDetails = railSource.GetStationDetails(station.Id).Result;
				Console.WriteLine(String.Format(
					"{0} / {1} - [{2},{3}] ",
					stationDetails.Id,
					stationDetails.Name,
					stationDetails.Latitude,
					stationDetails.Longitude
				));
				foreach (var timeUpdate in stationDetails.TimeUpdates) {
					Console.WriteLine(String.Format(
						"{0} - {1} - {3} ",
						timeUpdate.Traincode,
						timeUpdate.Destination,
						timeUpdate.Time
					));
				}
			}
		}

		public static void TestBikes(){
			Console.WriteLine ("\n\nDUBLIN BIKE:\n");
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
				Console.WriteLine(String.Format(
					"\tTotal: {0} - Availabile: {1}",
					stationDetails.VehicleAvailabilityUpdate.Total,
					stationDetails.VehicleAvailabilityUpdate.Available
				));
			}
		}
	}
}