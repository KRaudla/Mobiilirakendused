using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using SQLite;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Facebook_view.CategoryRecyclerView;
using Android.Support.V4.View;
using System;
using Facebook_view.Fragments;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;

namespace Facebook_view
{
    [Activity(Label = "Rahalugeja", MainLauncher = true, Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.feed);

            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            SetUpViewPager(viewPager);
            tabs.SetupWithViewPager(viewPager);

            //create database and table
            var db = new ItemDB();
            db.makeConnection();
            db.createTable();
            //delete table
            //db.ClearAllItems();
            //insert some posts to database
            //db.InitItems();

            SupportToolbar toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //Enable support action bar to display home icon
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.plus);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);


            //var fabButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //fabButton.Click += FabButton_Click;
        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new Fragment1(), "Koond");
            adapter.AddFragment(new Fragment2(), "Tulud");
            adapter.AddFragment(new Fragment3(), "Kulud");
            viewPager.Adapter = adapter;
        }
        
    }
    
}

