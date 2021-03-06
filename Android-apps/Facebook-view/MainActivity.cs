﻿using Android.App;
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
using SupportFragment = Android.Support.V4.App.Fragment;
using Facebook_view.FeedRecyclerView;
using System.Drawing;

namespace Facebook_view
{
    [Activity(Label = "Rahalugeja", MainLauncher = true, Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        FloatingActionButton fabButton;
        List<BottomItem> bottomItems;
        BottomSheetDialog bottomSheetDiaolog;
        SupportToolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main);
            //Set toolbar
            toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            //Enable support action bar to display home icon
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.plus);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            //create database and table
            var db = new ItemDB();
            db.makeConnection();
            db.createTable();
            //delete table
            //db.ClearAllItems();
            //insert some posts to database
            db.InitItems();
            //action button to open modal bottom sheet
            fabButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fabButton.Click += FabButton_Click;

            //add fragment to framelayout
            var feedFragment = new FeedFragment();
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.fragment_container, feedFragment);
            transaction.Commit();

        }

        private void FabButton_Click(object sender, EventArgs e)
        {
            //Modal Bottom Sheet
            bottomSheetDiaolog = new BottomSheetDialog(this);
            View view = LayoutInflater.Inflate(Resource.Layout.BottomSheet, null);
            
            //generate bottom sheet items
            bottomItems = InitBottomItems();
            var bottomfeed = view.FindViewById<RecyclerView>(Resource.Id.bottomRecyclerView);
            var bottomadapter = new BottomAdapter(bottomItems);
            bottomfeed.SetAdapter(bottomadapter);
            var feedLayoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            bottomfeed.SetLayoutManager(feedLayoutManager);
            bottomSheetDiaolog.SetContentView(view);
            bottomSheetDiaolog.Show();
            bottomadapter.ItemClick += Bottomadapter_ItemClick;
        }

        private void Bottomadapter_ItemClick(object sender, int e)
        {
            //Toast toast = Toast.MakeText(this, "Valisid "+ bottomItems[e].Name, ToastLength.Short);
            //toast.Show();
            switch (bottomItems[e].Name)
            {
                case "Lisa tulu":
                    
                    //hide fab button
                    //fabButton.Visibility = ViewStates.Invisible;
                    //hide toolbar and tablayout
                    //toolbar.Visibility = ViewStates.Gone;
                    //tabs.Visibility = ViewStates.Gone;
                    break;
                case "Lisa kulu":
                    FragmentTransaction transaction = FragmentManager.BeginTransaction();
                    IncomeFragment incomeDialog = new IncomeFragment();
                    incomeDialog.Show(transaction, "Income dialog");

                    break;
                case "Pane säästudesse":
                    break;
                case "Võta säästudest":
                    break;
            }
            //close bottom dialog
            bottomSheetDiaolog.Dismiss();
        }

        private List<BottomItem> InitBottomItems()
        {
            List<BottomItem> items = new List<BottomItem>();
            var a = new BottomItem();
            a.Name = "Lisa tulu";
            a.Image = Resource.Drawable.tulu48;
            items.Add(a);

            var b = new BottomItem();
            b.Name = "Lisa kulu";
            b.Image = Resource.Drawable.kulu48;
            items.Add(b);

            var c = new BottomItem();
            c.Name = "Pane säästudesse";
            c.Image = Resource.Drawable.paneSaastudesse48;
            items.Add(c);

            var d = new BottomItem();
            d.Name = "Võta säästudest";
            d.Image = Resource.Drawable.Votasaastudest48;
            items.Add(d);


            return items;
        }

    }
    
}

