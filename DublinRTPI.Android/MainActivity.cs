﻿using Android.App;
using Android.OS;
using Android.Util;

namespace com.xamarin.example.actionbar.tabs
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : Activity
    {
        static readonly string Tag = "ActionBarTabsSupport";

        Fragment[] _fragments;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			//SetContentView(Resource.Layout.Main);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			//SetContentView(Resource.Layout.Main);

            _fragments = new Fragment[]
                         {
                             new WhatsOnFragment(),
                             new SpeakersFragment(),
                             new SessionsFragment()
                         };

			//AddTabToActionBar(Resource.String.tab1, Resource.Drawable.icon);
			//AddTabToActionBar(Resource.String.tab2, Resource.Drawable.icon);
			//AddTabToActionBar(Resource.String.tab3, Resource.Drawable.icon);
        }

        void AddTabToActionBar(int labelResourceId, int iconResourceId)
        {
            ActionBar.Tab tab = ActionBar.NewTab()
                                         .SetText(labelResourceId)
                                         .SetIcon(iconResourceId);
            tab.TabSelected += TabOnTabSelected;
            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            ActionBar.Tab tab = (ActionBar.Tab)sender;

            Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragments[tab.Position];
			//tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }
    }
}
