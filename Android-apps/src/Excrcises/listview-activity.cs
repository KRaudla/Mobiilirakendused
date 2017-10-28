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

namespace Excrcises
{
    [Activity(Label = "listview_activity")]
    public class listview_activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.listviewlayout);//call layout
            var listView = FindViewById<ListView>(Resource.Id.listview1);//define list object

            var item = new string[] {"esimene","teine","kolmas","neljas" };//define string array

            listView.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1,item);

        }
    }
}