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
    public class Post
    {
        [PrimaryKey,AutoIncrement]
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Timestamp { get; set; }
        public string Status { get; set; }
        public int PostImageId { get; set; }
        public int ProfileImageId { get; set; }
    }
}