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
                //if (dbConnection.Insert(post) != 0)
                //    dbConnection.Update(post);
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
        public string deleteTable(string tableName)
        {
            try
            {
                dbConnection.Execute($"DELETE FROM {tableName}");
                return "Table deleted";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
        // get post by id
        public Post getPostById(int id)
        {
            return dbConnection.Table<Post>().FirstOrDefault(x => x.Id == id);
        }

    }
}