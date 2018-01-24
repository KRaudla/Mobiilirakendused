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
    public class BottomAdapter : RecyclerView.Adapter
    {
        //Create an Event when user clicks on item
        public event EventHandler<int> ItemClick;
        List<BottomItem> _items;

        public BottomAdapter(List<BottomItem> items)
        {
            this._items = items;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.BottomItem, parent, false);
            //Create our ViewHolder to cache the layout view references and register
            //the OnClick event.
            return new BottomItemHolder(itemView,OnClick);
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = _items[position];
            // Replace the contents of the view with that element
            var holder = viewHolder as BottomItemHolder;
            //set values
            holder.Image.SetImageResource(item.Image);//item image
            holder.Name.Text = item.Name;//item name
        }

        public override int ItemCount => _items.Count;

        //This will fire any event handlers that are registered with our ItemClick
        //event.
        private void OnClick(int position)
        {
            if (ItemClick != null)
            {
                ItemClick(this, position);
            }
        }
    }
}