using System;
using System.Threading.Tasks;
using DublinRTPI.Core;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;

namespace DublinRTPI.Dev
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var dataController = new DataController();
			MainClass.TestRail(dataController);
			MainClass.TestBikes(dataController);
			MainClass.TestLuas (dataController);
		}

		public static void TestLuas(IDataController dataController){
			Console.WriteLine ("\n\nLUAS:\n");
			var stations = dataController.GetStations(ServiceProviderEnum.Luas).Result;
			foreach (var station in stations) {
			

				var stationDetails = dataController.GetStationDetails(
					ServiceProviderEnum.Luas, 
					station.Id).Result;

				Console.WriteLine(String.Format(
					"{0} - {1} - [{2},{3}] ",
					DateTime.Now.ToString(),
					stationDetails.Id,
					stationDetails.Latitude,
					stationDetails.Longitude
				));

				foreach (var timeUpdate in stationDetails.TimeUpdates) {
					Console.WriteLine(String.Format(
						"\t{0} - {1}",
						timeUpdate.Destination,
						timeUpdate.Time
					));
				}
			}
		}

		public static void TestRail(IDataController dataController){
			Console.WriteLine ("\n\nIRISH RAIL:\n");
			var stations = dataController.GetStations(ServiceProviderEnum.IrishRail).Result;
			foreach (var station in stations) {

				var stationDetails = dataController.GetStationDetails(
					ServiceProviderEnum.IrishRail, 
					station.Id).Result;

				Console.WriteLine(String.Format(
					"{0} - {1} | {2} - [{3},{4}] ",
					DateTime.Now.ToString(),
					stationDetails.Id,
					stationDetails.Name,
					stationDetails.Latitude,
					stationDetails.Longitude
				));

				foreach (var timeUpdate in stationDetails.TimeUpdates) {
					Console.WriteLine(String.Format(
						"\t{0} - {1} - {2} ",
						timeUpdate.Traincode,
						timeUpdate.Destination,
						timeUpdate.Time
					));
				}
			}
		}

		public static void TestBikes(IDataController dataController){
			Console.WriteLine ("\n\nDUBLIN BIKE:\n");
			var stations = dataController.GetStations(ServiceProviderEnum.DublinBike).Result;
			foreach (var station in stations) {

				var stationDetails = dataController.GetStationDetails(
					ServiceProviderEnum.DublinBike,
					station.Id).Result;

				Console.WriteLine(String.Format(
					"{0} - {1} | {2} - [{3},{4}] ",
					DateTime.Now.ToString(),
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