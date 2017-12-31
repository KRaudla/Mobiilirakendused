﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using SQLite;
using Android.Views;

namespace Facebook_view
{
    [Activity(Label = "Facebook_view", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Postitused";

            //create database and table
            postsDB.Posts.createDatabase();
            //delete table
            //postsDB.Posts.deleteTable("Post");
            var post = generateTestPost();
            postsDB.Posts.insertUpdateData(post);

            var posts = postsDB.Posts.getAllPosts();
            var feed = FindViewById<ListView>(Resource.Id.listviewFeed);
            feed.Adapter = new CustomAdapter(this, posts);
        }

        //TEST - generate random post (hardcoded)
        private Post generateTestPost()
        {
            var post = new Post();
            post.Name = "Caroly Kasemets";
            post.Timestamp = "29.12.2017";
            post.Status = "See on pikema tekstiga postitus";
            post.ProfileImageId = Resource.Drawable.profilePicture;
            //post.PostImageId = Resource.Drawable.postPicture;
            return post;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }  
    }
}

