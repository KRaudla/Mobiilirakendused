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
            var secondview = FindViewById<Button>(Resource.Id.btnSecondView);//define button variable

            secondview.Click += delegate
            {
                var secondActivity = new Intent(this, typeof(second_activity));
                secondActivity.PutExtra("MyData", "Hello World");
                StartActivity(secondActivity);
            };

            var btnChange = FindViewById<Button>(Resource.Id.btnChangeText);
            var txtchange = FindViewById<TextView>(Resource.Id.txtview1);
            btnChange.Click += delegate
            {
                txtchange.Text = "Tekst muutus";
            };
        }
    }
}

