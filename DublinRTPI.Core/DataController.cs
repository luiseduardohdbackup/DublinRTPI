using System;
using System.Collections.Generic;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;
using DublinRTPI.Core.EndPoints;
using System.Threading.Tasks;
using System.Linq;

namespace DublinRTPI.Core
{
	public class DataController : IDataController
	{
		private IEndPoint _dublinBikeDataProvider;
		private IEndPoint _irishRailDataProvider;
		private IEndPoint _luasDataProvider;
		private IEndPoint _dublinBusDataProvider;
		private IEndPoint _busEireannDataProvider;

		public DataController(){
			this._dublinBikeDataProvider = new DublinBikeDataProvider();
			this._irishRailDataProvider = new IrishRailDataProvider();
			this._luasDataProvider = new LuasDataProvider();
			this._dublinBusDataProvider = new DublinBusDataProvider();
			this._busEireannDataProvider = new BusEireannDataProvider();
		}

		private IEndPoint GetEnpointByDataProviderType(ServiceProviderEnum serviceProvider){

			switch (serviceProvider) {
			case ServiceProviderEnum.DublinBike:
				return this._dublinBikeDataProvider;
			case ServiceProviderEnum.IrishRail:
				return this._irishRailDataProvider;
			case ServiceProviderEnum.Luas:
				return this._luasDataProvider;
			case ServiceProviderEnum.DublinBus:
				return this._dublinBusDataProvider;
			case ServiceProviderEnum.BusEireann:
				return this._busEireannDataProvider;
			default:
				throw new InvalidOperationException ();
			}
		}

		public async Task<Boolean> IsServiceAvailable(ServiceProviderEnum serviceProvider){
			try
			{
				var dataProvider = this.GetEnpointByDataProviderType(serviceProvider);
				return await dataProvider.IsDataServiceOnline();
			}
			catch(Exception)
			{
				return false;
			}
		}

		public async Task<List<Station>> GetStations(ServiceProviderEnum serviceProvider){
			try
			{
				var dataProvider = this.GetEnpointByDataProviderType(serviceProvider);
				return await dataProvider.GetStations();
			}
			catch(Exception)
			{
				return new List<Station>();
			}
		}

		public async Task<Station> GetStationDetails(ServiceProviderEnum serviceProvider, string stationId){
			try
			{
				var dataProvider = this.GetEnpointByDataProviderType(serviceProvider);
				return await dataProvider.GetStationDetails(stationId);
			}
			catch(Exception)
			{
				return new Station();
			}
		}

		public async Task<List<Route>> GetRoutes(ServiceProviderEnum serviceProvider){
			try
			{
				var dataProvider = this.GetEnpointByDataProviderType(serviceProvider);
				return await dataProvider.GetRoutes();
			}
			catch(Exception)
			{
				return new List<Route>();
			}
		}

		public async Task<List<Station>> GetStationsByRoute(ServiceProviderEnum serviceProvider, string routeId){
			try
			{
				var dataProvider = this.GetEnpointByDataProviderType(serviceProvider);
				return await dataProvider.GetStationsByRoute(routeId);
			}
			catch(Exception)
			{
				return new List<Station>();
			}
		}
	}
}