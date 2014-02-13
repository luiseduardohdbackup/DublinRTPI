using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;
using MonoTouch.MapKit;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core;
using System.Linq;

namespace DublinRTPI.iOS.Helpers
{
	public class CustomMapDelegate: MKMapViewDelegate
	{
		public ServiceProviderEnum service;
		public DataController DataController;
		public string pId = "PinAnnotation";
		public string bId = "BasicAnnotation";

		public CustomMapDelegate(ServiceProviderEnum service, DataController dataController){
			this.service = service;
			this.DataController = dataController;
		}

		public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, NSObject annotation)
		{
			// save resoureces
			MKPinAnnotationView anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation (pId);
			if (anView == null) anView = new MKPinAnnotationView (annotation, pId);

			anView.CanShowCallout = true;

			// set custom marker and tooltip image
			switch (this.service) {
			case ServiceProviderEnum.Luas:
				anView.LeftCalloutAccessoryView = new UIImageView (UIImage.FromFile ("luas.png"));
				// anView.Image = UIImage.FromFile ("luas.png");
				break;
			case ServiceProviderEnum.DublinBike:
				anView.LeftCalloutAccessoryView = new UIImageView (UIImage.FromFile ("bike.png"));
				// anView.Image = UIImage.FromFile ("luas.png");
				break;
			case ServiceProviderEnum.IrishRail:
				anView.LeftCalloutAccessoryView = new UIImageView (UIImage.FromFile ("dart.png"));
				// anView.Image = UIImage.FromFile ("luas.png");
				break;
			default:
				throw new InvalidOperationException ();
			}

			// set custom tooltip touch action
			var detailButton = UIButton.FromType(UIButtonType.DetailDisclosure);
			anView.RightCalloutAccessoryView = detailButton;

			return anView;
		}

		public override async void CalloutAccessoryControlTapped (MKMapView mapView, MKAnnotationView view, UIControl control)
		{
			var point = (view.Annotation as MKPointAnnotation); 
			if (point != null) {
				var title = point.Title;
				// TODO it should be StationAnnotation so we don't need this hack :(
				var details = await this.DataController.GetStationDetailsByName(this.service, title);

				var status = "";
				// time
				if (details.TimeUpdates != null) {
					details.TimeUpdates.ForEach (
						u => status += String.Format ("{0} {1}\n", u.Destination, u.Time)
					);
				}

				// bikes
				if(details.VehicleAvailabilityUpdate != null){
					status += String.Format ("Total : {0}\n Available : {1}",
						details.VehicleAvailabilityUpdate.Total,
						details.VehicleAvailabilityUpdate.Available
					);
				}

				var alert = new UIAlertView (title, status, null, "OK", null);
				alert.Show();
			} 
			else 
			{
				var alert = new UIAlertView ("Error", "Sorry there has been an error.", null, "OK", null);
				alert.Show();
			}
		}
	}
}