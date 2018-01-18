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
        View view;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //return categories
            view = inflater.Inflate(Resource.Layout.Fragment1, container, false);
            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var categories = new Category().GenerateDummyData();
            var adapter = new CategoryAdapter(categories);
            recyclerView.SetAdapter(adapter);
            var layoutManager = new LinearLayoutManager(view.Context, LinearLayoutManager.Horizontal, false);
            recyclerView.SetLayoutManager(layoutManager);
            adapter.ItemClick += _adapter_ItemClick;


            //REPLACE CUSTOM ADAPTER WITH RECYCLERVIEW ADAPTER
            //return posts
            /*
            var db = new postsDB();
            db.makeConnection();
            var posts = db.getAllPosts();
            var recyclerview2 = view.FindViewById<RecyclerView>(Resource.Id.listviewFeed);
            var adapter2 = new CustomAdapter(posts);
            recyclerview2.SetAdapter(adapter2);
            var layoutManager2 = new LinearLayoutManager(view.Context, LinearLayoutManager.Vertical, false);
            recyclerView.SetLayoutManager(layoutManager2);
            */
            return view;
        }

        private void _adapter_ItemClick(object sender, int e)
        {
            int CategoryNum = e + 1;
            Toast.MakeText(View.Context, "This is category no: " + CategoryNum, ToastLength.Short).Show();
        }
    }
}