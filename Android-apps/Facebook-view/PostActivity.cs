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
    [Activity(Label = "PostActivity")]
    public class PostActivity : Activity
    { 
        private EditText txtFullName;
        string path;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewPostLayout);

            //find buttons and text fields from layout
            txtFullName = FindViewById<EditText>(Resource.Id.txtName);
            var btnAddName = FindViewById<Button>(Resource.Id.btnAdd);
           
            
            //create document folder - database
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            path = System.IO.Path.Combine(docsFolder, "db_sqlite.db");

            
            
            //listen button and do something
            btnAddName.Click += BtnAddName_Click;

            //test.....buttons to create database and show info
            var btnCreateDatabase = FindViewById<Button>(Resource.Id.btnCreateDatabase);
            var btnDatabaseInfo = FindViewById<Button>(Resource.Id.btnShowDatainfo);
            btnCreateDatabase.Click += BtnCreateDatabase_Click;
            btnDatabaseInfo.Click += BtnDatabaseInfo_Click;
            


        }

        private void BtnDatabaseInfo_Click(object sender, EventArgs e)
        {
            
            //read from database
            var connection = new SQLiteConnection(path);
            List<Post> posts = new List<Post>();
            var users = connection.Table<Post>();//.Where(x => x.Id == 1);
            foreach (var user in users)
            {
                posts.Add(user);
            }
        }

        private void BtnCreateDatabase_Click(object sender, EventArgs e)
        {
            //create new table
            createDatabase(path);
        }

        private void BtnAddName_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text != "")
            {
                //user data
                var user = new Post();
                user.Name = txtFullName.Text;
                insertUpdateData(user, path);
                Android.Widget.Toast.MakeText(this, "Andmed lisatud", Android.Widget.ToastLength.Short).Show();
            }
            else
            {
                Android.Widget.Toast.MakeText(this, "Nimi ei tohi olla tühi", Android.Widget.ToastLength.Short).Show();
            }
        }

        private string createDatabase(string path)
        {
            try
            {
                var connection = new SQLiteAsyncConnection(path);
                connection.CreateTableAsync<Post>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
        private string insertUpdateData(Post user, string path)
        {
            try
            {
                //add or update user
                var db = new SQLiteConnection(path);
                if (db.Insert(user) != 0)
                {
                    db.Update(user);
                }
                return "Data added or updated";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
    }
}