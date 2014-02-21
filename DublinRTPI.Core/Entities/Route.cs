using System;
using System.Collections.Generic;

namespace DublinRTPI.Core.Entities
{
	public class Route
	{
		public string Id;
		public string Name;

		public Route(){}

		public Route (string id, string name)
		{
			this.Id = id;
			this.Name = name;
		}
	}
}