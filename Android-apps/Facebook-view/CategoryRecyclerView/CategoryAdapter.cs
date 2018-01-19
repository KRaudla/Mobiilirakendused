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

namespace Facebook_view.CategoryRecyclerView
{
    public class CategoryAdapter : RecyclerView.Adapter
    {
        private readonly List<Category> _categories;

        public CategoryAdapter(List<Category> categories)
        {
            this._categories = categories;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var layout = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.category_item, parent, false);
            return new CategoryItemHolder(layout);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var categoryViewHolder = holder as CategoryItemHolder;
            categoryViewHolder.CategoryTextView.Text = _categories[position].Name;
            categoryViewHolder.CategoryImageView.SetImageResource(_categories[position].ImageId);
        }

        public override int ItemCount => _categories.Count;

    }
}