using Android.App;
using Android.Widget;
using Android.OS;

namespace Excrcises
{
    [Activity(Label = "Excrcises", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
           
            SetContentView(Resource.Layout.Main);//show main view
            var btnsecondView = FindViewById<Button>(Resource.Id.btnSecondView);//define button variable

            btnsecondView.Click += delegate
            {
                StartActivity(typeof(second_activity));
            };

            var btnChangeText = FindViewById<Button>(Resource.Id.btnChangeText);
            var txtview1 = FindViewById<TextView>(Resource.Id.txtview1);
            btnChangeText.Click += delegate
            {
                txtview1.Text = "Tekst muutus";
            };
        }
    }
}

