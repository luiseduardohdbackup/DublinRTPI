using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;
using MonoTouch.MapKit;
using DublinRTPI.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using DublinRTPI.Core;
using MonoTouch.CoreLocation;

namespace DublinRTPI.iOS.Helpers
{
	public class MapActionsHelper
	{
		public MKMapView _map;
		public DataController DataController;

		public MapActionsHelper(MKMapView map)
		{
			this._map = map;
			this.DataController = new DataController();
		}

		public void AddStationMarker(Station station){
			var marker = new MKPointAnnotation () {
				Title = station.Name,
				Coordinate = new CLLocationCoordinate2D (station.Latitude, station.Longitude)
			};
			this._map.AddAnnotation (marker);
		}

		public void DisplayStations(ServiceProviderEnum source){
			var stations = this.DataController.GetStations(source).Result;
			stations.ForEach( station => this.AddStationMarker(station) );
		}
	}
}