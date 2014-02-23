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
        public string sId = "StationAnnotation";

		public CustomMapDelegate(ServiceProviderEnum service, DataController dataController){
			this.service = service;
			this.DataController = dataController;
		}

		public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, NSObject annotation)
		{
            if (annotation is MKUserLocation)
            {
                return null;
            }

			if (annotation is StationAnnotation)
            {
                // save resoureces
                MKPinAnnotationView anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(sId);
                if (anView == null)
                {
                    anView = new MKPinAnnotationView(annotation, sId);
                }

                anView.CanShowCallout = true;
				//anView.Image = UIImage.FromFile("pin.png");
				anView.PinColor = MKPinAnnotationColor.Red;

                // set custom marker and tooltip image
                switch (this.service)
                {
                    case ServiceProviderEnum.Luas:
                        anView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("luas.png"));
                        break;
                    case ServiceProviderEnum.DublinBike:
                        anView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("bike.png"));
                        break;
                    case ServiceProviderEnum.IrishRail:
                        anView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("dart.png"));
                        break;
                    case ServiceProviderEnum.DublinBus:
                        anView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("bus.png"));
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                // set custom tooltip touch action
                var detailButton = UIButton.FromType(UIButtonType.DetailDisclosure);
                anView.RightCalloutAccessoryView = detailButton;
				return anView;
            }
            else
            {
                // show pin annotation
                MKPinAnnotationView anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(pId);
                if (anView == null)
                {
                    anView = new MKPinAnnotationView(annotation, pId);
                }
                
				anView.PinColor = MKPinAnnotationColor.Green;
                anView.CanShowCallout = true;
				return anView;
            }
		}

		public override async void CalloutAccessoryControlTapped (MKMapView mapView, MKAnnotationView view, UIControl control)
		{
			LoadingOverlay loadingOverlay = new LoadingOverlay (UIScreen.MainScreen.Bounds);
            var point = (view.Annotation as StationAnnotation); 
			if (point != null) {
				try {
					var key = ((AppDelegate)UIApplication.SharedApplication.Delegate).window;
					key.Add(loadingOverlay);
					var title = point.Model.Name;
					var details = await this.DataController.GetStationDetails(this.service, point.Model.Id);

					var status = "";
					// time
					if (details.TimeUpdates != null) {
						details.TimeUpdates.ForEach (
							u => status += String.Format ("{0} {1}\n", u.Destination, u.Time)
						);
						if(details.TimeUpdates.Count == 0){
							status += "There are no time updates available at this time";
						}
					}

					// bikes
					if(details.VehicleAvailabilityUpdate != null){
						status += String.Format ("Total : {0}\n Available : {1}",
							details.VehicleAvailabilityUpdate.Total,
							details.VehicleAvailabilityUpdate.Available
						);
					}

					var alert = new UIAlertView (title, status, null, "OK", null);
					loadingOverlay.Hide();
					alert.Show();
				}
				catch(Exception){
					var alert = new UIAlertView ("Error", "Sorry there has been an error.", null, "OK", null);
					loadingOverlay.Hide();
					alert.Show();
				}
			} 
			else 
			{
				var alert = new UIAlertView ("Error", "Sorry there has been an error.", null, "OK", null);
				loadingOverlay.Hide();
				alert.Show();
			}
		}
	}
}