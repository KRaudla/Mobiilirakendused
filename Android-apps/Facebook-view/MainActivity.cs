using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

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

            var databaseview = FindViewById<Button>(Resource.Id.btnDatabase);

            databaseview.Click += delegate
            {
                var databaseActivity = new Intent(this, typeof(DatabaseActivity));
                //databaseActivity.PutExtra("MyData", "Hello World");//define data
                StartActivity(databaseActivity);
            };

            //var button = FindViewById<ImageButton>(Resource.Id.txtName);
        }
    }
}

