﻿using System;
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
        public event EventHandler<int> ItemClick;
        private readonly List<Category> _categories;

        public CategoryAdapter(List<Category> categories)
        {
            this._categories = categories;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var movieViewHolder = holder as CategoryItemHolder;
            movieViewHolder.CategoryTextView.Text = _categories[position].Name;
            movieViewHolder.CategoryImageView.SetImageResource(_categories[position].ImageId);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var layout = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.category_item, parent, false);

            return new CategoryItemHolder(layout,OnClick);

        }

        public override int ItemCount => _categories.Count;

        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }

    }
}