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
using Android.Support.V7.Widget;

namespace Facebook_view
{
    public class FeedItemHolder : RecyclerView.ViewHolder
    {
        public ImageView CategoryImage { get; set; }
        public TextView Category { get; set; }
        public TextView TimeStamp { get; set; }
        public TextView Comment { get; set; }
        public TextView Amount { get; set; }

        public FeedItemHolder(View itemView) : base(itemView)
        {
            CategoryImage = itemView.FindViewById<ImageView>(Resource.Id.Image);
            Category = itemView.FindViewById<TextView>(Resource.Id.Name);
            TimeStamp = itemView.FindViewById<TextView>(Resource.Id.Timestamp);
            Comment = itemView.FindViewById<TextView>(Resource.Id.Comment);
            Amount = itemView.FindViewById<TextView>(Resource.Id.Amount);
        }
    }
}