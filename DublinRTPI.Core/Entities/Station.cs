using System;
using System.Collections.Generic;

namespace DublinRTPI.Core.Entities
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
	}
}