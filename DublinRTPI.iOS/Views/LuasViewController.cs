using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;
using MonoTouch.MapKit;
using DublinRTPI.Core.Entities;
using DublinRTPI.iOS.Helpers;

namespace DublinRTPI.iOS.Views
{
	public class LuasViewController : UIViewController 
	{
		public MKMapView Map;
		public MapActionsHelper MapActionsHelper;
		public ServiceProviderEnum serviceType;

		public LuasViewController()
		{
			this.serviceType = ServiceProviderEnum.Luas;
			this.Map = new MKMapView(UIScreen.MainScreen.Bounds);
			this.Map.Delegate = new CustomMapDelegate();
			this.Map.ShowsUserLocation = true;
			this.Map.ZoomEnabled = true;
			this.Map.ScrollEnabled = true;
			this.MapActionsHelper = new MapActionsHelper(this.Map);
			this.View = this.Map;
			this.TabBarItem = new UITabBarItem();
			this.TabBarItem.Title = "Luas";
			this.TabBarItem.Image = UIImage.FromFile("first.png");
		}

		public async void DisplayStations()
		{
			this.MapActionsHelper.DisplayStations(this.serviceType);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public void Test(string args){
			Console.Write (args);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}