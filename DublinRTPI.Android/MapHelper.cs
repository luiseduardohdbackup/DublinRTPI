using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using DublinRTPI.Core;
using DublinRTPI.Core.Entities;
using System.Threading.Tasks;
using Android.Gms.Maps.Model;

namespace DublinRTPI.Android
{
	public class MapHelper
	{
		private GoogleMap _map;
		private DataController _dataController;

		public MapHelper (GoogleMap map)
		{
			this._map = map;
			this._map.MapType = GoogleMap.MapTypeNormal;
			this._dataController = new DataController();
		}

		public void SetCamera(ServiceProviderEnum provider){
			LatLng location = new LatLng (53.3479095, -6.2559231);
			int zoom = 18;
			if (provider == ServiceProviderEnum.DublinBike) {
				location = new LatLng (53.3479095, -6.2559231);
				zoom = 18; //10000
			}
			else if(provider == ServiceProviderEnum.IrishRail)
			{
				location = new LatLng (53.3479095, -6.2559231);
				zoom = 18; //60000
			}
			else if(provider == ServiceProviderEnum.Luas)
			{
				zoom = 18; // 25000
				location = new LatLng (53.3162064, -6.2672187);
			}
			CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
			builder.Target(location);
			builder.Zoom(zoom);
			CameraPosition cameraPosition = builder.Build();
			CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
			this._map.MoveCamera(cameraUpdate);
		}

		public void ClearMarkers(){
			//TODO
		}

		public void AddMarker(ServiceProviderEnum provider, Station station){
			var marker = new MarkerOptions();
			marker.SetPosition(new LatLng(station.Latitude, station.Longitude));
			marker.SetTitle(station.Name);
			marker.InvokeIcon(BitmapDescriptorFactory.DefaultMarker (BitmapDescriptorFactory.HueCyan));
			this._map.AddMarker(marker);
		}

		public async Task<bool> DisplayRoutes(ServiceProviderEnum provider){
			var routes = await this._dataController.GetRoutes (provider);
			if (routes.Count > 0) {
				// TODO display route list
				return true;
			} 
			else 
			{
				return false;
			}
		}

		public async Task<bool> DisplayStations(ServiceProviderEnum provider){
			this.ClearMarkers();
			this.SetCamera(provider);
			var stations = await this._dataController.GetStations (provider);
			if (stations.Count > 0) 
			{
				foreach (var station in stations) {
					this.AddMarker (provider, station);
				}
				return true;
			} 
			else 
			{
				return false;
			}
		}

		public async Task<bool> DisplayStationsByRoute(ServiceProviderEnum provider, string route){
			this.ClearMarkers();
			this.SetCamera(provider);
			var stations = await this._dataController.GetStationsByRoute (provider, route);
			if (stations.Count > 0) 
			{
				foreach (var station in stations) 
				{
					this.AddMarker (provider, station);
				}
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}