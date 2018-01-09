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

namespace Facebook_view
{
    [Activity(Label = "Facebook_view", MainLauncher = true, Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        RecyclerView.Adapter mAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.feed);

            //create database and table
            var db = new postsDB();
            db.makeConnection();
            db.createTable();

            //delete table
            //db.clearAllPosts();
            //insert some posts to database
            //db.initPostDB();

            
            // Get our RecyclerView layout:
            var mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            // Plug the adapter into the RecyclerView:
            



            var posts = db.getAllPosts();
            var feed = FindViewById<ListView>(Resource.Id.listviewFeed);
            feed.Adapter = new CustomAdapter(this, posts);

            var fabButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fabButton.Click += FabButton_Click;
        }

        private void FabButton_Click(object sender, System.EventArgs e)
        {
            //var intent = new Intent(this, typeof(NewItemActivity));
            var intent = new Intent(this, typeof(NewItemActivity));
            this.StartActivity(intent);
        }

    }
    
}

