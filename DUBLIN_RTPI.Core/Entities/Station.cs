using System;
using System.Collections.Generic;

namespace DUBLIN_RTPI.Core.Entities
{
	public class Station
	{
		public string Id;
		public string Name;
		public double Longitude;
		public double Latitude;
		public List<TimeUpdate> TimeUpdates;
		public VehicleAvailabilityUpdate VehicleAvailabilityUpdate;

		public Station(){}

		public Station(string id, string name, double longitude, double latitude, List<TimeUpdate> timeUpdates, VehicleAvailabilityUpdate vehicleAvailabilityUpdate)
		{
			this.Id = id;
			this.Name = name;
			this.Longitude = longitude;
			this.Latitude = latitude;
			this.TimeUpdates = timeUpdates;
			this.VehicleAvailabilityUpdate = vehicleAvailabilityUpdate;
		}

		public Station(string id, string name, double longitude, double latitude)
		{
			this.Id = id;
			this.Name = name;
			this.Longitude = longitude;
			this.Latitude = latitude;
			this.TimeUpdates = null;
			this.VehicleAvailabilityUpdate = null;
		}
	}
}