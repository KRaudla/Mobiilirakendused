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
using Facebook_view.FeedRecyclerView;
using System.Drawing;

namespace Facebook_view
{
    [Activity(Label = "Rahalugeja", MainLauncher = true, Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        FloatingActionButton fabButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.feed);

            //Set toolbar
            SupportToolbar toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            //Enable support action bar to display home icon
            //SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.plus);
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            //set tabs
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

            //action button to open modal bottom sheet
            fabButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fabButton.Click += FabButton_Click;
        }

        private void FabButton_Click(object sender, EventArgs e)
        {
            //Modal Bottom Sheet
            BottomSheetDialog bottomSheetDiaolog = new BottomSheetDialog(this);
            View view = LayoutInflater.Inflate(Resource.Layout.BottomSheet, null);
            
            //generate bottom sheet items
            var bottomItems = InitBottomItems();
            var bottomfeed = view.FindViewById<RecyclerView>(Resource.Id.bottomRecyclerView);
            var bottomadapter = new BottomAdapter(bottomItems);
            bottomfeed.SetAdapter(bottomadapter);
            var feedLayoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            bottomfeed.SetLayoutManager(feedLayoutManager);



            bottomSheetDiaolog.SetContentView(view);
            bottomSheetDiaolog.Show();
        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new Fragment1(), "Koond");
            adapter.AddFragment(new Fragment2(), "Tulud");
            adapter.AddFragment(new Fragment3(), "Kulud");
            viewPager.Adapter = adapter;
        }

        private List<BottomItem> InitBottomItems()
        {
            List<BottomItem> items = new List<BottomItem>();
            var a = new BottomItem();
            a.Name = "Lisa tulu";
            a.Image = Resource.Drawable.arrowRight48;
            items.Add(a);

            var b = new BottomItem();
            b.Name = "Lisa kulu";
            b.Image = Resource.Drawable.arrowRight48;
            items.Add(b);

            var c = new BottomItem();
            c.Name = "Pane säästudesse";
            c.Image = Resource.Drawable.arrowRight48;
            items.Add(c);

            var d = new BottomItem();
            d.Name = "Võta säästudest";
            d.Image = Resource.Drawable.arrowRight48;
            items.Add(d);

            items.Add(a);
            items.Add(b);
            items.Add(c);
            items.Add(d);

            return items;
        }

    }
    
}

