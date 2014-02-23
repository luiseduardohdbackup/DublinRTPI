using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;
using MonoTouch.MapKit;
using DublinRTPI.Core.Entities;
using DublinRTPI.iOS.Helpers;
using System.Threading.Tasks;

namespace DublinRTPI.iOS.Views
{
	public class DublinBusViewController : UIViewController 
	{
		public MKMapView Map;
		public MapActionsHelper MapActionsHelper;
		public string RouteId;

		public DublinBusViewController(string routeId)
		{
			this.RouteId = routeId;
			this.Title = "DUBLIN RTPI";
			this.TabBarItem = new UITabBarItem();
			this.TabBarItem.Title = "Dublin Bus";
			this.TabBarItem.Image = UIImage.FromFile("bus.png");
		}

		public async Task<bool> DisplayStations()
		{
			return await this.MapActionsHelper.DisplayDisplayStationsByRoute(this.RouteId);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad();
			var tabBarController = ((AppDelegate)UIApplication.SharedApplication.Delegate).tabBarController;
			tabBarController.TabBar.Hidden = false;
			this.Map = new MKMapView(UIScreen.MainScreen.Bounds);
			this.MapActionsHelper = new MapActionsHelper(this.Map, ServiceProviderEnum.DublinBus);
			this.View = this.Map;
			await DisplayStations();
		}
	}
}