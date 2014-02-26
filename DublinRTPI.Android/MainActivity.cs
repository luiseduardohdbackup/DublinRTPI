using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using DublinRTPI.Core.Entities;

namespace DublinRTPI.Android
{
	[Activity (Label = "Dublin RTPI", MainLauncher = true)]
	public class MainActivity : Activity
	{
		private MapHelper _mapHelper;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Enable tab navigation
			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			// Dsibale ActionBar Icon
			ActionBar.SetHomeButtonEnabled (false);
			//ActionBar.SetDisplayShowHomeEnabled (false);

			// Create Map
			var mapFragment = new MapFragment();
			FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
			fragmentTx.Add(Resource.Id.MapContainer, mapFragment);
			fragmentTx.Commit();
			GoogleMap map = mapFragment.Map;

			// Set Main View
			SetContentView (Resource.Layout.Main);

			// Configure Map
			if (map != null) {
				this._mapHelper = new MapHelper (map);
			}

			// Tab 1
			ActionBar.Tab tab1 = ActionBar.NewTab();
			tab1.SetText(Resources.GetString(Resource.String.tab1));
			//tab.SetIcon(Resource.Drawable.tab1_icon);
			tab1.TabSelected += async (sender, args) => {
				var ok = await this._mapHelper.DisplayStations(ServiceProviderEnum.Luas);
				if(!ok){
					// TODO Let user know there was a connection error
				}
			};
			ActionBar.AddTab(tab1);

			// Tab 2
			ActionBar.Tab tab2 = ActionBar.NewTab();
			tab2.SetText(Resources.GetString(Resource.String.tab2));
			//tab.SetIcon(Resource.Drawable.tab1_icon);
			tab2.TabSelected += async (sender, args) => {
				var ok = await this._mapHelper.DisplayStations(ServiceProviderEnum.IrishRail);
				if(!ok){
					// TODO Let user know there was a connection error
				}
			};
			ActionBar.AddTab(tab2);

			// Tab 3
			ActionBar.Tab tab3 = ActionBar.NewTab();
			tab3.SetText(Resources.GetString(Resource.String.tab3));
			//tab.SetIcon(Resource.Drawable.tab1_icon);
			tab3.TabSelected += async (sender, args) => {
				var ok = await this._mapHelper.DisplayStations(ServiceProviderEnum.DublinBike);
				if(!ok){
					// TODO Let user know there was a connection error
				}
			};
			ActionBar.AddTab(tab3);

			// Tab 4
			ActionBar.Tab tab4 = ActionBar.NewTab();
			tab4.SetText(Resources.GetString(Resource.String.tab4));
			//tab.SetIcon(Resource.Drawable.tab1_icon);
			tab4.TabSelected += async (sender, args) => {
				var ok = await this._mapHelper.DisplayRoutes(ServiceProviderEnum.DublinBus);
				if(!ok){
					// TODO Let user know there was a connection error
				}
			};
			ActionBar.AddTab(tab4);
		}
	}
}