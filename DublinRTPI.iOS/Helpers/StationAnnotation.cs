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
	public class StationAnnotation : MKPointAnnotation
	{
		public Station Model;
	}
}