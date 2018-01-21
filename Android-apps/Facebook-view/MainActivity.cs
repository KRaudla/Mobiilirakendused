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
        BottomSheetBehavior bottomSheetBehavior;
        FloatingActionButton fabButton;

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

            //Modal bottom sheet
            LinearLayout sheet = FindViewById<LinearLayout>(Resource.Id.bottom_sheet);            
            bottomSheetBehavior = BottomSheetBehavior.From(sheet);
            bottomSheetBehavior.PeekHeight = 0;
            bottomSheetBehavior.Hideable = true;
            bottomSheetBehavior.SetBottomSheetCallback(new BottomCallBack());


            //action button to open modal bottom sheet
            fabButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fabButton.Click += FabButton_Click;


            //Test fill bottom sheet recyclerview
            List<Item> items = new List<Item>();
            var a = new Item();
            a.Category = "Lisa uus tulu";
            a.CategoryImage = Resource.Drawable.kodu48;
            var b = new Item();
            b.Category = "Lisa uus kulu";
            b.CategoryImage = Resource.Drawable.ilu48;
            var c = new Item();
            c.Category = "Lisa säästudesse";
            c.CategoryImage = Resource.Drawable.meelelahutus48;
            var d = new Item();
            d.Category = "Võta säästudest";
            d.CategoryImage = Resource.Drawable.muu48;

            items.Add(a);
            items.Add(b);
            items.Add(c);
            items.Add(d);


            var bottomfeed = FindViewById<RecyclerView>(Resource.Id.bottomRecyclerView);
            var bottomadapter = new FeedAdapter(items);
            bottomfeed.SetAdapter(bottomadapter);
            var feedLayoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            bottomfeed.SetLayoutManager(feedLayoutManager);


        }

        private void FabButton_Click(object sender, EventArgs e)
        {

            if (bottomSheetBehavior.State == 3 || bottomSheetBehavior.State == 2)
            {
                bottomSheetBehavior.State = BottomSheetBehavior.StateCollapsed;
                fabButton.SetImageResource(Resource.Drawable.plus);
            }
            if (bottomSheetBehavior.State == 4)
            {
                bottomSheetBehavior.State = BottomSheetBehavior.StateExpanded;
                fabButton.SetImageResource(Resource.Drawable.ic_action_content_save);
            }

        }

        public class BottomCallBack : BottomSheetBehavior.BottomSheetCallback
        {
            public override void OnSlide(View bottomSheet, float slideOffset)
            {
                //Sliding
            }

            public override void OnStateChanged(View bottomSheet, int newState)
            {
                //State changed
                BottomSheetBehavior bottomSheetBehavior = BottomSheetBehavior.From(bottomSheet);
                if (newState == BottomSheetBehavior.StateDragging)
                    bottomSheetBehavior.State = BottomSheetBehavior.StateExpanded;
                if (newState == 2)
                    bottomSheetBehavior.State = 3;
            }
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

