using System;

namespace DUBLIN_RTPI.Core.Entities
{
	public class VehicleAvailabilityUpdate
	{
		public int Total;
		public int Available;

		public VehicleAvailabilityUpdate (int total, int available)
		{
			this.Total = total;
			this.Available = available;
		}
	}
}