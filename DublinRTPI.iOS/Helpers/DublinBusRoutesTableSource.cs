using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;
using DublinRTPI.Core.Entities;
using DublinRTPI.iOS.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DublinRTPI.Core;
using DublinRTPI.iOS.Views;

namespace DublinRTPI.iOS
{
	public class DublinBusRoutesTableSource : UITableViewSource 
	{
		List<Route> tableItems;
		UINavigationController parent;
		string cellIdentifier = "TableCell";

		public DublinBusRoutesTableSource (List<Route> items, UINavigationController parent)
		{
			this.parent = parent;
			tableItems = items;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Count;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var routeId = tableItems [indexPath.Row].Id;
			var mapView = new DublinBusViewController(routeId);
			this.parent.PushViewController(mapView, true);
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			}
			cell.TextLabel.Text = tableItems[indexPath.Row].Name;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			cell.ImageView.Image = UIImage.FromFile("bus.png");
			return cell;
		}
	}
}