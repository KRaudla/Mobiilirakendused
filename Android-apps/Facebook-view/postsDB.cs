using System;
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
        SQLiteConnection dbConnection;
        private const string _dbName = "db_sqlite.s3db";

        public void makeConnection()
        {
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docsFolder, _dbName);
            dbConnection = new SQLiteConnection(path);
        }

        //Create database
        public string createTable()
        {
            try
            {
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

            var query = dbConnection.Table<Post>();
            foreach (var i in query)
            {
                posts.Add(i);
            }
            return posts;
        }
        //update
        public void updateData(Post post)
        {
            dbConnection.Update(post);
        }
        //insert
        public void insertData (Post post)
        {
            dbConnection.Insert(post);
        }
               
        //delete table
        public void clearAllPosts()
        {
            dbConnection.DeleteAll<Post>();
        }
        // get post by id
        public Post getPostById(int id)
        {
            return dbConnection.Table<Post>().FirstOrDefault(x => x.ID == id);
        }

        //delete post by id
        public void deletePostById(int id)
        {
            dbConnection.Delete<Post>(id);
        }

        //initialize posts
        public void initPostDB()
        {
            var post = new Post();
            //post.Id = 1;
            post.Name = "Caroly Kasemets";
            post.Timestamp = DateTime.Today;
            post.Status = "See on pikema tekstiga postitus abadskjsadkjsadkjsakdksad";
            post.ProfileImageId = Resource.Drawable.profilePicture;
            //post.PostImageId = Resource.Drawable.postPicture;

            var post2 = new Post();
            //post2.Id = 2;
            post2.Name = "Kaspar Raudla";
            post2.Timestamp = DateTime.Today;
            post2.Status = "Staatus";
            post2.ProfileImageId = Resource.Drawable.profilePicture;
            //post2.PostImageId = Resource.Drawable.postPicture;

            var post3 = new Post();
            //post3.Id = 3;
            post3.Name = "Jimmy";
            post3.Timestamp = DateTime.Today;
            post3.Status = "ei oska midagi öelda";
            post3.ProfileImageId = Resource.Drawable.profilePicture;
            post3.PostImageId = Resource.Drawable.postPicture;

            var post4 = new Post();
            //post4.Id = 2;
            post4.Name = "Kaspar Raudla";
            post4.Timestamp = DateTime.Today;
            post4.Status = "Postitus abc1321231";
            post4.ProfileImageId = Resource.Drawable.profilePicture;
            //post4.PostImageId = Resource.Drawable.postPicture;

            var post5 = new Post();
            //post5.Id = 2;
            post5.Name = "Kaspar Raudla";
            post5.Timestamp = DateTime.Today;
            post5.Status = "Staatus adlfkalskdlksadewq";
            post5.ProfileImageId = Resource.Drawable.profilePicture;
            //post5.PostImageId = Resource.Drawable.postPicture;

            var post6 = new Post();
            //post6.Id = 2;
            post6.Name = "Kaspar Raudla";
            post6.Timestamp = DateTime.Today;
            post6.Status = "Staatus dsakflkfkdfweqfr";
            post6.ProfileImageId = Resource.Drawable.profilePicture;
            //post6.PostImageId = Resource.Drawable.postPicture;

            dbConnection.Insert(post);
            dbConnection.Insert(post2);
            dbConnection.Insert(post3);
            dbConnection.Insert(post4);
            dbConnection.Insert(post5);
            dbConnection.Insert(post6);
            
        }

    }
}