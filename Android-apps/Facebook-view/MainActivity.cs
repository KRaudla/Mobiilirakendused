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

namespace Facebook_view
{
    [Activity(Label = "Facebook_view", MainLauncher = true, Theme = "@style/Theme.DesignDemo")]
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
            var db = new postsDB();
            db.makeConnection();
            db.createTable();
            //delete table
            //db.clearAllPosts();
            //insert some posts to database
            //db.initPostDB();

            var fabButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fabButton.Click += FabButton_Click;
        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new Fragment1(), "Päevaraamat");
            adapter.AddFragment(new Fragment2(), "Tulud");
            adapter.AddFragment(new Fragment3(), "Kulud");
            viewPager.Adapter = adapter;
        }

        private void FabButton_Click(object sender, System.EventArgs e)
        {
            //var intent = new Intent(this, typeof(NewItemActivity));
            var intent = new Intent(this, typeof(NewItemActivity));
            this.StartActivity(intent);
        }        
    }
    
}

