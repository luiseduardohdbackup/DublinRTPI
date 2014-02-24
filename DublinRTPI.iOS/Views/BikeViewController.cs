using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;
using MonoTouch.MapKit;
using DublinRTPI.Core.Entities;
using DublinRTPI.iOS.Helpers;
using MonoTouch.CoreLocation;
using System.Threading.Tasks;

namespace DublinRTPI.iOS.Views
{
	public class BikeViewController : UIViewController 
	{
		public MKMapView Map;
		public MapActionsHelper MapActionsHelper;

		public BikeViewController()
		{
			this.Title = "DUBLIN RTPI";
			this.TabBarItem = new UITabBarItem();
			this.TabBarItem.Title = "Dublin Bike";
			this.TabBarItem.Image = UIImage.FromBundle("bike");
		}

		public async Task<bool> DisplayStations()
		{
			return await this.MapActionsHelper.DisplayStations();
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
			this.View = this.Map;
			this.MapActionsHelper = new MapActionsHelper(this.Map, ServiceProviderEnum.DublinBike);
			await DisplayStations();
		}
	}
}