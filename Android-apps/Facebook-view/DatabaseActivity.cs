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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.DatabaseLayout);

            //create document folder - database
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlite.db");

            //crreate database
            var connection = new SQLiteConnection(pathToDatabase);
            //create table
            connection.CreateTable<User>();

            //add new user






        }
    }
}