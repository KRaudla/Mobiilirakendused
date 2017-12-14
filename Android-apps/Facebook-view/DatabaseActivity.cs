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
    [Activity(Label = "DatabaseActivity")]
    public class DatabaseActivity : Activity
    { 
        private EditText txtFirstName;
        private TextView txtOutput; 
        string path;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DatabaseLayout);

            //find buttons and text fields from layout
            txtFirstName = FindViewById<EditText>(Resource.Id.txtName);
            var btnAddName = FindViewById<Button>(Resource.Id.btnAdd);
            txtOutput = FindViewById<TextView>(Resource.Id.txtResult);
            
            //create document folder - database
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            path = System.IO.Path.Combine(docsFolder, "db_sqlite.db");

            //create new table
            //createDatabase(path);
            
            //listen button and do something
            btnAddName.Click += BtnAddName_Click;
            /*
            //read from database
            var connection = new SQLiteConnection(path);
            List<User> userlist = new List<User>();
            var users = connection.Table<User>();//.Where(x => x.Id == 1);
            foreach (var user in users)
            {
                userlist.Add(user);
            }*/
            
            
        }

        private void BtnAddName_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "")
            {
                //user data
                var user = new Post();
                user.Name = txtFirstName.Text;
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