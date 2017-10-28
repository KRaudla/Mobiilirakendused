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
    [Activity(Label = "second_activity")]
    public class second_activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.secondLayout);//show second activity view   


            var textview1 = FindViewById<TextView>(Resource.Id.txtview1);
            var mytext = Intent.GetStringExtra("MyData");
            //replace text gotten from intent, sent by mainactivity
            textview1.Text = mytext;


        }
    }
}