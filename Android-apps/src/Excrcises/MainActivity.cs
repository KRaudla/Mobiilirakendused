using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Excrcises
{
    [Activity(Label = "Excrcises", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);//show main view

            //direct to second view
            var secondview = FindViewById<Button>(Resource.Id.btnSecondView);//define button 
            secondview.Click += delegate
            {
                var secondActivity = new Intent(this, typeof(second_activity));
                secondActivity.PutExtra("MyData", "Hello World");//define data
                StartActivity(secondActivity);
            };

            var btnChange = FindViewById<Button>(Resource.Id.btnChangeText);
            var txtchange = FindViewById<TextView>(Resource.Id.txtview1);
            btnChange.Click += delegate
            {
                txtchange.Text = "Tekst muutus";
            };

            //direct to web view
            var btnwebview = FindViewById<Button>(Resource.Id.btnWebview);
            btnwebview.Click += delegate
            {
                var webActivity = new Intent(this, typeof(web_activity));
                StartActivity(webActivity);
            };
            //direct to listview
            var btnlistview = FindViewById<Button>(Resource.Id.btnShowListview);
            btnlistview.Click += delegate
            {
                var listview = new Intent(this, typeof(listview_activity));
                StartActivity(listview);
            };
        }
    }
}

