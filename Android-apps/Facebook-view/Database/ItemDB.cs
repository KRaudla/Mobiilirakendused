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
    public class ItemDB
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
                dbConnection.CreateTable<Item>();
                return "Database for posts created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        //get all items
        public List<Item> GetAllItems()
        {
            var items = new List<Item>();

            var query = dbConnection.Table<Item>();
            foreach (var i in query)
            {
                items.Add(i);
            }
            return items;
        }

        //update
        public void UpdateData(Item item)
        {
            dbConnection.Update(item);
        }

        //insert
        public void InsertData (Item item)
        {
            dbConnection.Insert(item);
        }
               
        //delete table
        public void ClearAllItems()
        {
            dbConnection.DeleteAll<Item>();
        }

        // get item by id
        public Item GetItemById(int id)
        {
            return dbConnection.Table<Item>().FirstOrDefault(x => x.ID == id);
        }

        //delete post by id
        public void DeleteItemById(int id)
        {
            dbConnection.Delete<Item>(id);
        }

        //initialize items: TEST
        public void InitItems()
        {
            var item = new Item();
            item.Type = "INCOME";
            item.Category = "Töötasu";
            item.Timestamp = DateTime.Now;
            item.Comment = "";
            item.Amount = 1600;
            item.CategoryImage = Resource.Drawable.muu48;

            var item2 = new Item();
            item2.Type = "EXPENSE";
            item2.Category = "Toit";
            item2.Timestamp = DateTime.Now;
            item2.Comment = "Selver";
            item2.Amount = 55.55;
            item2.CategoryImage = Resource.Drawable.toit48;

            var item3 = new Item();
            item3.Type = "INCOME";
            item3.Category = "Salong";
            item3.Timestamp = DateTime.Now;
            item3.Comment = "";
            item3.Amount = 85.00;
            item3.CategoryImage = Resource.Drawable.muu48;

            var item4 = new Item();
            item4.Type = "EXPENSE";
            item4.Category = "Meelelahutus";
            item4.Timestamp = DateTime.Now;
            item4.Comment = "kino";
            item4.Amount = 12.45;
            item4.CategoryImage = Resource.Drawable.meelelahutus48;

            dbConnection.Insert(item);
            dbConnection.Insert(item2);
            dbConnection.Insert(item3);
            dbConnection.Insert(item4);           
        }

    }
}