using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace Facebook_view.Fragments
{
    public class NewItemFragment : SupportFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.NewItem, container, false);
            //receive data sent to fragment and fill textview
            if (Arguments != null)
            {
                var selection = Arguments.GetString("Selection");
                view.FindViewById<TextView>(Resource.Id.textView1).Text = selection;
                
            }
            return view;
        }
    }
}