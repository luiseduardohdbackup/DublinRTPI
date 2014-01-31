using System;
using System.Collections.Generic;

namespace DUBLIN_RTPI.Core.Entities
{
	public class Route
	{
		public string Id;
		public string Name;
		public List<Station> Stations;

		public Route (string id, string name)
		{
			this.Id = id;
			this.Name = name;
			this.Stations = new List<Station>();
		}
	}
}