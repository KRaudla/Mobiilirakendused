using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using SQLite;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.Design.Widget;

namespace Facebook_view
{
    [Activity(Label = "Facebook_view", MainLauncher = true, Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.feed);

            //create database and table
            postsDB.Posts.createDatabase();
            
            //delete table
            postsDB.Posts.clearAllPosts();
            //insert some posts to database
            postsDB.Posts.initPostDB();

            var posts = postsDB.Posts.getAllPosts();
            var feed = FindViewById<ListView>(Resource.Id.listviewFeed);
            feed.Adapter = new CustomAdapter(this, posts);

            var fabButton = FindViewById<FloatingActionButton>(Resource.Id.fab);

            fabButton.Click += FabButton_Click;
        }

        private void FabButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(NewItemActivity));
            this.StartActivity(intent);
        }
    }
}

