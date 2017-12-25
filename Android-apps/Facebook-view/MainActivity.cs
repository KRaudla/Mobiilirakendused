﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using SQLite;

namespace Facebook_view
{
    [Activity(Label = "Facebook_view", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.feed);
            var feed = FindViewById<ListView>(Resource.Id.listviewFeed);//define list object

            //create document folder - database
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docsFolder, "db_sqlite.db");
            //DELETE TABLE
            //var conn = new SQLiteConnection(path);
            //conn.Execute("DELETE FROM Post");
            createDatabase(path);
            var allPosts = findAllPosts(path);
            feed.Adapter = new CustomAdapter(this, allPosts);
            feed.ItemClick += Feed_ItemClick;


        }

        private void Feed_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var ItemActivity = new Intent(this, typeof(Item_activity));
            ItemActivity.PutExtra("FullName", e.View.FindViewById<TextView>(Resource.Id.txtFullName).Text);
            ItemActivity.PutExtra("TimeStamp", e.View.FindViewById<TextView>(Resource.Id.txtTimestamp).Text);
            ItemActivity.PutExtra("StatusMsg", e.View.FindViewById<TextView>(Resource.Id.txtStatus).Text);
            ItemActivity.PutExtra("ItemId", e.Id);

            StartActivity(ItemActivity);
        }

        private string createDatabase(string path)
        {
            try
            {
                var connection = new SQLiteConnection(path);
                connection.CreateTable<Post>();
                return "Database for posts created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        //TEST

        private List<Post> findAllPosts(string path)
        {
            var connection = new SQLiteConnection(path);
            var posts = new List<Post>();
            foreach (var post in connection.Table<Post>())
            {
                posts.Add(post);
            }
            return posts;
        }

        
        //TEST
        private string insertUpdateData(Post post, string path)
        {
            try
            {
                var db = new SQLiteConnection(path);
                if (db.Insert(post) != 0)
                    db.Update(post);
                return "Single data file inserted or updated";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
    }

}

