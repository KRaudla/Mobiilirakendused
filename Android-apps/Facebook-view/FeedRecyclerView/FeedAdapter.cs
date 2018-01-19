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

namespace Facebook_view.FeedRecyclerView
{
    public class FeedAdapter : RecyclerView.Adapter
    {
        List<Item> _items;

        public FeedAdapter(List<Item> items)
        {
            this._items = items;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item, parent, false);
            return new FeedItemHolder(itemView);
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = _items[position];
            // Replace the contents of the view with that element
            var holder = viewHolder as FeedItemHolder;
            //set values
            holder.CategoryImage.SetImageResource(item.CategoryImage);//item image
            holder.Category.Text = item.Category;//item name
            holder.TimeStamp.Text = item.Timestamp.ToString("dd.MM.yyyy");// timestamp
            holder.Comment.Text = item.Comment; //comment
            holder.Amount.Text = item.Amount.ToString();
        }

        public override int ItemCount => _items.Count;
    }
}