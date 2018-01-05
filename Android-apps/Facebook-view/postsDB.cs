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
        private static readonly postsDB _postsDB = new postsDB();
        SQLiteConnection dbConnection;
        private const string _dbName = "db_sqlite.db";

        /*public postsDB()
        {
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docsFolder, _dbName);
            dbConnection = new SQLiteConnection(path);
        }*/
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
        //insert
        public void updateData(Post post)
        {
            dbConnection.Update(post);
        }
        //insert and update post
        public string insertUpdateData(Post post)
        {
            try
            {
                int inserted = dbConnection.Insert(post); //1 if successfully inserted
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

            postsDB._postsDB.insertUpdateData(post);
            postsDB._postsDB.insertUpdateData(post2);
            postsDB._postsDB.insertUpdateData(post3);
            postsDB._postsDB.insertUpdateData(post4);
            postsDB._postsDB.insertUpdateData(post5);
            postsDB._postsDB.insertUpdateData(post6);

        }

    }
}