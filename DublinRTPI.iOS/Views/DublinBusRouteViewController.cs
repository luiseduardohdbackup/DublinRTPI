using MonoTouch.UIKit;
using System.Drawing;
using System;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.MapKit;
using DublinRTPI.Core.Entities;
using DublinRTPI.iOS.Helpers;
using System.Threading.Tasks;
using DublinRTPI.Core;
using DublinRTPI.iOS.Views;
using System.Collections.Generic;

namespace DublinRTPI.iOS
{
	public class DublinBusRouteViewController : UITableViewController
	{
		UITableView table;
		List<Route> tableItems;
		DataController dataController;

		public DublinBusRouteViewController(){
			this.Title = "ROUTES";
			this.TabBarItem = new UITabBarItem();
			this.TabBarItem.Title = "Dublin Bus";
			this.TabBarItem.Image = UIImage.FromFile("bus.png");
		}

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			table = new UITableView(this.View.Bounds);

			var tabBarHeight = ((AppDelegate)UIApplication.SharedApplication.Delegate)
				.tabBarController.TabBar.Frame.Size.Height;

			table.Frame = new System.Drawing.RectangleF(
				0, 0,
				this.View.Bounds.Size.Width,
				this.View.Bounds.Size.Height - tabBarHeight
			);
			table.AutoresizingMask = UIViewAutoresizing.All;
			dataController = new DataController();
			this.tableItems = await dataController.GetRoutes(
				ServiceProviderEnum.DublinBus
			);
			table.Source = new DublinBusRoutesTableSource(
				tableItems,
				this.ParentViewController as UINavigationController
			);
			Add(table);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			var tabBarController = ((AppDelegate)UIApplication.SharedApplication.Delegate).tabBarController;
			tabBarController.TabBar.Hidden = true;
		}
	}
}