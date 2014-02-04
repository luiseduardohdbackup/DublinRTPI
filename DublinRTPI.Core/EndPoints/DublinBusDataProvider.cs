using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;
using DublinRTPI.Core.DataAccess;
using DublinRTPI.Core.EndPointParser;

namespace DublinRTPI.Core.EndPoints
{
	internal class DublinBusDataProvider : IEndPoint
	{
		public const string ROUTES = "";
		public const string STATIONS = "";
		public const string STATION_DETAILS = "";

		private HttpClientHelper _httpClient;
		private IEndPointParser _dataParser;

		public DublinBusDataProvider() {
			this._httpClient = new HttpClientHelper();
			this._dataParser = new DublinBusDataParser();
		}

		public async Task<Boolean> IsDataServiceOnline(){
			throw new NotImplementedException();
		}

		public async Task<List<Route>> GetRoutes(){
			throw new NotImplementedException();
		}

		public async Task<List<Station>> GetStations(){
			throw new NotSupportedException();
		}

		public async Task<List<Station>> GetStationsByRoute(string routeId){
			/*
			// http://www.dublinbus.ie/en/RTPI/Sources-of-Real-Time-Information/?searchtype=route&searchquery=16
			$('#rtpi-results tr').each(function(index, row){ 
				if($(row).attr('class') != 'yellow'){ 
					$(row).find('td').each(function(index2, column){ 
						console.log($(column).text().trim()); 
					}); 
				};
			});
			*/
			throw new NotImplementedException();
		}

		public async Task<Station> GetStationDetails(string stationId){
			// http://www.dublinbus.ie/en/RTPI/Sources-of-Real-Time-Information/?searchtype=view&searchquery=6041
			throw new NotImplementedException();
		}

	}
}