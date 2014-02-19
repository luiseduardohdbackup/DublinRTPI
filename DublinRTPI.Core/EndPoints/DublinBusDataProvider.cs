using System;
using System.Linq;
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
        public const string ROUTES = "https://www.dublinbus.ie/Templates/public/RoutePlannerService//RTPIWebServiceProxy.asmx/GetRoutesViaService";
        public const string ROUTES_BODY = "{\"context\":{\"Text\":\"\",\"NumberOfItems\":0,\"Filter\":\"Enter your Route\",\"MinStringLength\":2}}";
        public const string STATIONS = "http://www.rtpi.ie/ConnectService.svc/GetServiceDataSerialized";
        public const string STATIONS_BODY = @"{""publicServiceCode"":""{0}"",""operatorID"":1,""depotID"":1,""serviceVariantIDs"":"""",""routeLineNodes"":""none""}";
        public const string STATION_DETAILS = "https://www.dublinbus.ie/en/RTPI/Sources-of-Real-Time-Information";

		private HttpClientHelper _httpClient;
		private IEndPointParser _dataParser;

		public DublinBusDataProvider() {
			this._httpClient = new HttpClientHelper();
			this._dataParser = new DublinBusDataParser();
		}

		public async Task<Boolean> IsDataServiceOnline(){
            try
            {
                var temp = await this.GetRoutes();
                var temp2 = this.GetStationsByRoute(temp.First().Id);
                return true;
            }
            catch (Exception) {
                return false;
            }
		}

		public async Task<List<Route>> GetRoutes(){
            var json = await this._httpClient.PostJson(DublinBusDataProvider.ROUTES, DublinBusDataProvider.ROUTES_BODY);
            return this._dataParser.ParseRoutes(json);
		}

		public async Task<List<Station>> GetStations(){
            var stations = new List<Station>();
            var routes = await this.GetRoutes();
            foreach (var route in routes)
            {
                stations.AddRange(await this.GetStationsByRoute(route.Id));
            }
            return stations;
		}

		public async Task<List<Station>> GetStationsByRoute(string routeId){
            var body = DublinBusDataProvider.STATIONS_BODY.Replace("{0}", routeId);
            var json = await this._httpClient.PostJson(
                DublinBusDataProvider.STATIONS,
                body
            );
            return this._dataParser.ParseStations(json);
		}

		public async Task<Station> GetStationDetails(string stationId){
            var html = await this._httpClient.GetJson(
                DublinBusDataProvider.STATION_DETAILS,
                new Dictionary<string, string>() { 
                    { "searchtype", "view"},
                    { "searchquery", stationId }
                }
            );
            return this._dataParser.ParseStationDetails(html);
		}
	}
}