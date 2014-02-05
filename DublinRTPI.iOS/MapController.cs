using System;
using DublinRTPI.Core.Contracs;
using DublinRTPI.Core.Entities;

namespace DublinRTPI.iOS
{
	public class MapController : IMapController
	{
		public void RenderMap(){
			throw new NotImplementedException ();
		}

		public void AddMarker(MapMarker marker){
			throw new NotImplementedException ();
		}

		public void RemoveAllMarkers(){
			throw new NotImplementedException ();
		}

		public void SetFocusOnMarker(MapMarker marker){
			throw new NotImplementedException ();
		}

		public void SetUserLocationMarker(){
			throw new NotImplementedException ();
		}
	}
}