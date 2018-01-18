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

namespace Facebook_view.Fragments
{
    public class Fragment1 : SupportFragment
    {
        RecyclerView _recyclerView;
        RecyclerView.LayoutManager _layoutManager;
        CategoryAdapter _adapter;
        View view;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.Fragment1, container, false);
            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var categories = new Category().GenerateDummyData();
            _adapter = new CategoryAdapter(categories);
            _recyclerView.SetAdapter(_adapter);
            _layoutManager = new LinearLayoutManager(view.Context, LinearLayoutManager.Horizontal, false);
            _recyclerView.SetLayoutManager(_layoutManager);

            _adapter.ItemClick += _adapter_ItemClick;

            var db = new postsDB();
            db.makeConnection();
            var posts = db.getAllPosts();
            var feed = view.FindViewById<ListView>(Resource.Id.listviewFeed);
            feed.Adapter = new CustomAdapter(posts);

            return view;
        }

        private void _adapter_ItemClick(object sender, int e)
        {
            int CategoryNum = e + 1;
            Toast.MakeText(View.Context, "This is category no: " + CategoryNum, ToastLength.Short).Show();
        }
    }
}