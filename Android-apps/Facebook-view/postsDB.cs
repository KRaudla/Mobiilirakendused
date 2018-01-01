﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Facebook_view
{
    public class postsDB
    {
        private static readonly postsDB _postsDB = new postsDB();
        SQLiteConnection dbConnection;
        private const string _dbName = "Articles_DB.db3";

        public postsDB()
        {
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docsFolder, "db_sqlite.db");
            dbConnection = new SQLiteConnection(path);
        }
        public static postsDB Posts
        {
            get
            {
                return _postsDB;
            }

        }
        //Create database
        public string createDatabase()
        {
            try
            {
                //create document folder and path
                var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var path = System.IO.Path.Combine(docsFolder, "db_sqlite.db");
                dbConnection = new SQLiteConnection(path);
                dbConnection.CreateTable<Post>();
                return "Database for posts created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
        //get all posts
        public List<Post> getAllPosts()
        {
            var posts = new List<Post>();
            foreach (var post in dbConnection.Table<Post>())
            {
                posts.Add(post);
            }
            return posts;
        }

        //insert and update post
        public string insertUpdateData(Post post)
        {
            try
            {

                //bug here, new post ID wont´t autoincrement!!!
                int inserted = dbConnection.Insert(post); //will be 1 if successful
                if (inserted==0)
                {
                    dbConnection.Update(post);
                }
               
                return "Single data file inserted or updated";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
        //delete table
        public void clearAllPosts()
        {
            dbConnection.DeleteAll<Post>();
        }
        // get post by id
        public Post getPostById(int id)
        {
            return dbConnection.Table<Post>().FirstOrDefault(x => x.Id == id);
        }
        //delete post by id
        public void deletePostById(int id)
        {
            dbConnection.Delete<Post>(id);
        }
        public void initPostDB()
        {
            var post = new Post();
            //post.Id = 1;
            post.Name = "Caroly Kasemets";
            post.Timestamp = "29.12.2017";
            post.Status = "See on pikema tekstiga postitus";
            post.ProfileImageId = Resource.Drawable.profilePicture;
            //post.PostImageId = Resource.Drawable.postPicture;

            var post2 = new Post();
            //post2.Id = 2;
            post2.Name = "Kaspar Raudla";
            post2.Timestamp = "29.12.2017";
            post2.Status = "Staatus";
            post2.ProfileImageId = Resource.Drawable.profilePicture;
            //post2.PostImageId = Resource.Drawable.postPicture;

            var post3 = new Post();
            //post3.Id = 3;
            post3.Name = "Jimmy";
            post3.Timestamp = "29.12.2017";
            post3.Status = "ei oska midagi öelda";
            post3.ProfileImageId = Resource.Drawable.profilePicture;
            //post3.PostImageId = Resource.Drawable.postPicture;

            postsDB._postsDB.insertUpdateData(post);
            postsDB._postsDB.insertUpdateData(post2);
            postsDB._postsDB.insertUpdateData(post3);

        }

    }
}