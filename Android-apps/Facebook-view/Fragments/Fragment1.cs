using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Facebook_view.CategoryRecyclerView;
using Facebook_view.FeedRecyclerView;

namespace Facebook_view.Fragments
{
    public class Fragment1 : SupportFragment
    {
        View view;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            view = inflater.Inflate(Resource.Layout.Fragment1, container, false);

            //categories
            var categories = new Category().GenerateDummyData();
            var categoryView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var categoryAdapter = new CategoryAdapter(categories);
            categoryView.SetAdapter(categoryAdapter);
            var categoryLayoutManager = new LinearLayoutManager(view.Context, LinearLayoutManager.Horizontal, false);
            categoryView.SetLayoutManager(categoryLayoutManager);

            //items
            var db = new ItemDB();
            db.makeConnection();
            var items = db.GetAllItems();
            var feed = view.FindViewById<RecyclerView>(Resource.Id.listviewFeed);
            var feedadapter = new FeedAdapter(items);
            feed.SetAdapter(feedadapter);
            var feedLayoutManager = new LinearLayoutManager(view.Context, LinearLayoutManager.Vertical, false);
            feed.SetLayoutManager(feedLayoutManager);


            
            return view;
        }

    }
}