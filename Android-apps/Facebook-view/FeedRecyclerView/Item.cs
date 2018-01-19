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
    [Table("Item")]
    public class Item
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Type { get; set; }//income or expense
        public DateTime Timestamp { get; set; }//date added
        public int CategoryImage { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public double Amount { get; set; }
    }
}