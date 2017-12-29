using Android.App;
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
            var feed = FindViewById<ListView>(Resource.Id.listviewFeed);//define list object


            //create document folder - database
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docsFolder, "db_sqlite.db");
            //DELETE TABLE
            //var conn = new SQLiteConnection(path);
            //conn.Execute("DELETE FROM Post");
            createDatabase(path);
            var post = generateTestPost();
            insertUpdateData(post, path);
            var allPosts = findAllPosts(path);
            feed.Adapter = new CustomAdapter(this, allPosts);

            
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

        //TEST - find posts
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
        
        //TEST - insert post
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

        //TEST - generate random post (hardcoded)
        private Post generateTestPost()
        {
            var post = new Post();
            post.Name = "Madis Kõpper";
            post.Timestamp = "24.12.2017";
            post.Status = "ho-ho-ho";
            post.ProfileImageId = Resource.Drawable.profilePicture;
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

