using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DublinRTPI.Android
{
	[Activity (Label = "DublinRTPI.Android", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			SetContentView (Resource.Layout.Main);

			// Tab 1
			ActionBar.Tab tab1 = ActionBar.NewTab();
			tab1.SetText(Resources.GetString(Resource.String.tab1));
			//tab.SetIcon(Resource.Drawable.tab1_icon);
			tab1.TabSelected += (sender, args) => {
				Console.WriteLine (1);
			};
			ActionBar.AddTab(tab1);

			// Tab 2
			ActionBar.Tab tab2 = ActionBar.NewTab();
			tab2.SetText(Resources.GetString(Resource.String.tab2));
			//tab.SetIcon(Resource.Drawable.tab1_icon);
			tab2.TabSelected += (sender, args) => {
				Console.WriteLine (2);
			};
			ActionBar.AddTab(tab2);

			// Tab 3
			ActionBar.Tab tab3 = ActionBar.NewTab();
			tab3.SetText(Resources.GetString(Resource.String.tab3));
			//tab.SetIcon(Resource.Drawable.tab1_icon);
			tab3.TabSelected += (sender, args) => {
				Console.WriteLine (3);
			};
			ActionBar.AddTab(tab3);

			// Tab 4
			ActionBar.Tab tab4 = ActionBar.NewTab();
			tab4.SetText(Resources.GetString(Resource.String.tab4));
			//tab.SetIcon(Resource.Drawable.tab1_icon);
			tab4.TabSelected += (sender, args) => {
				Console.WriteLine (4);
			};
			ActionBar.AddTab(tab4);
		}
	}
}