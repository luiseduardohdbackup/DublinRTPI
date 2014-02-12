using System;
using MonoTouch.Foundation;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using DublinRTPI.iOS.Views;

namespace DublinRTPI.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UITabBarController tabBarController;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var luasView = new LuasViewController();
			var trainView = new TrainViewController ();
			var bikeView = new BikeViewController();
			// TODO DUBLIN BUS

			tabBarController = new UITabBarController ();
			tabBarController.ViewControllers = new UIViewController[]{ 
				luasView,
				trainView,
				bikeView
			};

			tabBarController.ViewControllerSelected += (object sender, UITabBarSelectionEventArgs e) => {
				switch(e.ViewController.TabBarItem.Title){
				case "Luas":
					luasView.DisplayStations();
					break;
				case "Irish Rail":
					trainView.DisplayStations();
					break;
				case "Dublin Bike":
					bikeView.DisplayStations();
					break;
				default:
					throw new InvalidOperationException();
				}
			};
			
			window.RootViewController = tabBarController;
			window.MakeKeyAndVisible();
			
			return true;
		}
	}
}

