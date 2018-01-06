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
    [Table("Post")]
    public class Post
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; }
        public int PostImageId { get; set; }
        public int ProfileImageId { get; set; }

        /*public override string ToString()
        {
            return string.Format($"[Post: ID={0}, Name={1}, TimeStamp={2}]", Id, Name, Timestamp);
        }*/
    }
}