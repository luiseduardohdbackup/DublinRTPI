using System;
using DublinRTPI.Core.Entities;

namespace DublinRTPI.Core.Contracs
{
	public interface IMapController
	{
		void RenderMap();
		void AddMarker(MapMarker marker);
		void RemoveAllMarkers();
		void SetFocusOnMarker(MapMarker marker);
		void SetUserLocationMarker();
	}
}