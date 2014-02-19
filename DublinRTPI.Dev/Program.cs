using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DublinRTPI.Core;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;
using Newtonsoft.Json;
using System.IO;

namespace DublinRTPI.Dev
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var dataController = new DataController();
            MainClass.Test(dataController, ServiceProviderEnum.IrishRail, "Irish Rail", false);
            MainClass.Test(dataController, ServiceProviderEnum.DublinBike, "Dublin Bikes", false);
            MainClass.Test(dataController, ServiceProviderEnum.Luas, "Luas", false);
            MainClass.Test(dataController, ServiceProviderEnum.DublinBus, "Dublin Bus", false);
            Console.WriteLine(String.Format("{0} - Press key to close", DateTime.Now.Second.ToString()));
            Console.ReadKey();
		}

        public static void Test(IDataController dataController, ServiceProviderEnum service, string name, bool addDetails)
        {
            Console.WriteLine(String.Format("{0} - {1}", DateTime.Now.Second.ToString(), name));
            var stations = dataController.GetStations(service).Result;
            if(addDetails.Equals(true)){
                foreach (var station in stations)
                {
                    var stationDetails = dataController.GetStationDetails(
                        service,
                        station.Id).Result;
                    station.TimeUpdates = stationDetails.TimeUpdates;
                    station.VehicleAvailabilityUpdate = stationDetails.VehicleAvailabilityUpdate;
                }            
            }
            MainClass.Log(stations, name);
        }

        public static void Log(List<Station> stations, string name) {
            var json = JsonConvert.SerializeObject(stations);
            File.WriteAllText(String.Format("{0}.json", name), json);
        }
	}
}