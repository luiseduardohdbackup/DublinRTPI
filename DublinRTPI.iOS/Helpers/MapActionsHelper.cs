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
using System.Threading.Tasks;

namespace DublinRTPI.iOS.Helpers
{
	public class MapActionsHelper
	{
		public MKMapView _map;
		private ServiceProviderEnum _service;
		public DataController DataController;

		public MapActionsHelper(MKMapView map, ServiceProviderEnum service)
		{
			this._map = map;
			this.DataController = new DataController();
			this._service = service;
			this._map.Delegate = new CustomMapDelegate(this._service, this.DataController);
			this._map.ShowsUserLocation = true;
			this._map.ZoomEnabled = true;
			this._map.ScrollEnabled = true;
			//Enable 3D buildings (only when executed on device)
			this._map.MapType = MKMapType.Standard;
			this._map.ShowsBuildings = true;
			this._map.ShowsPointsOfInterest = false;
			CLLocationCoordinate2D target = new CLLocationCoordinate2D(53.3479095, -6.2559231);
			CLLocationCoordinate2D viewPoint = new CLLocationCoordinate2D(53.3479095, -6.2559231);
			int altitude = 25000;
			if (this._service == ServiceProviderEnum.DublinBike) {
				altitude = 10000;
			}
			else if(this._service == ServiceProviderEnum.IrishRail)
			{
				altitude = 60000;
			}
			else if(this._service == ServiceProviderEnum.Luas)
			{
				altitude = 25000;
				target = new CLLocationCoordinate2D(53.3162064, -6.2672187);
				viewPoint = new CLLocationCoordinate2D(53.3162064, -6.2672187);
			}
			var camera = MKMapCamera.CameraLookingAtCenterCoordinate(target, viewPoint, altitude);
			this._map.Camera = camera;
		}

		public void AddStationMarker(Station station){
			var marker = new StationAnnotation() {
				Title = station.Name,
				Coordinate = new CLLocationCoordinate2D (station.Latitude, station.Longitude),
				Model = station
			};
			this._map.AddAnnotation(marker);
		}

		public async void DisplayStations(){
			var stations = await this.DataController.GetStations(this._service);
			stations.ForEach( station => this.AddStationMarker(station) );
		}

		public async void DisplayDisplayStationsByRoute(string routeID){
			var stations = await this.DataController.GetStationsByRoute(this._service, routeID);
			stations.ForEach( station => this.AddStationMarker(station) );
		}
	}
}