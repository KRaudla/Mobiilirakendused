using Android.App;
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
        private string path;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.feed);
            var feed = FindViewById<ListView>(Resource.Id.listviewFeed);//define list object

            //create document folder - database
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docsFolder, "db_sqlite.db");
            createDatabase(path);

            var posts = findAllPosts(path);


            //TEST
            var post1 = new Post();
            post1.Name = "Madis Kõpper";
            post1.Timestamp = "10.12.2017";
            post1.Status = "Tere, see on minu postituse staatus";
            post1.PostImageId = Resource.Drawable.mycar;
            post1.ProfileImageId = Resource.Drawable.unnamed;

            insertUpdateData(post1, path);


            var posts2 = findAllPosts(path);





            //var posts = GeneratePosts();//generate list of cars
            //feed.Adapter = new CustomAdapter(this, posts);

        }

        //https://stackoverflow.com/questions/36213948/what-is-the-difference-between-asynchronous-calls-and-callbacks


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
        private int findNumberRecords(string path)
        {
            try
            {
                var db = new SQLiteConnection(path);
                // this counts all records in the database, it can be slow depending on the size of the database
                var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Post");

                // for a non-parameterless query
                // var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");

                return count;
            }
            catch (SQLiteException ex)
            {
                return -1;
            }
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

        //TEST 
        private List<Post> GeneratePosts()
        {
            var posts = new List<Post>();
            var post1 = new Post();
            post1.Id = 1;
            post1.Name = "Kaspar Raudla";
            post1.Timestamp = "10.12.2017";
            post1.Status = "Tere, see on minu postituse staatus";
            post1.PostImageId = Resource.Drawable.mycar;
            post1.ProfileImageId = Resource.Drawable.unnamed;
            posts.Add(post1);

            var post2 = new Post();
            post2.Id = 1;
            post2.Name = "Kaspar Raudla";
            post2.Timestamp = "10.12.2017";
            post2.Status = "Tere, see on minu postituse staatus";
            post2.PostImageId = Resource.Drawable.mycar;
            post2.ProfileImageId = Resource.Drawable.unnamed;
            posts.Add(post2);

            var post3 = new Post();
            post3.Id = 1;
            post3.Name = "Kaspar Raudla";
            post3.Timestamp = "10.12.2017";
            post3.Status = "Tere, see on minu postituse staatus";
            post3.PostImageId = Resource.Drawable.mycar;
            post3.ProfileImageId = Resource.Drawable.unnamed;
            posts.Add(post3);

            var post4 = new Post();
            post4.Id = 1;
            post4.Name = "Kaspar Raudla";
            post4.Timestamp = "10.12.2017";
            post4.Status = "Tere, see on minu postituse staatus";
            post4.PostImageId = Resource.Drawable.mycar;
            post4.ProfileImageId = Resource.Drawable.unnamed;
            posts.Add(post4);


            return posts;
        }
        
    }

}

