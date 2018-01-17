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
    public class CategoryItemHolder : RecyclerView.ViewHolder
    {
        public TextView CategoryTextView { get; set; }
        public ImageView CategoryImageView { get; set; }
    
        public CategoryItemHolder(View itemView, Action<int> listener) : base(itemView)
        {
            CategoryTextView = itemView.FindViewById<TextView>(Resource.Id.categoryTextView);
            CategoryImageView = itemView.FindViewById<ImageView>(Resource.Id.categoryImageView);
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}