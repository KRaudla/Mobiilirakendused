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
using Java.Lang;
using Excrcises;

namespace Exercises
{
    public class CustomAdapter : BaseAdapter
    {
        List<Car> items;
        Activity context;

        public CustomAdapter(Activity context, List<Car> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null; // could wrap a Contact in a Java.Lang.Object to return it here if needed
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.Customview, null);
            view.FindViewById<TextView>(Resource.Id.txtName).Text = items[position].Name;
            view.FindViewById<TextView>(Resource.Id.txtKw).Text = items[position].Kw.ToString();
            view.FindViewById<TextView>(Resource.Id.txtModel).Text = items[position].Model.ToString();
            return view;
        }
    }
}