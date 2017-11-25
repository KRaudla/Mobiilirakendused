using Android.App;
using Android.Widget;
using Android.OS;

namespace Facebook_view
{
    [Activity(Label = "Facebook_view", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            //var button = FindViewById<ImageButton>(Resource.Id.txtName);
        }
    }
}

