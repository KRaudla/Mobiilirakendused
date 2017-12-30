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

namespace Facebook_view
{
    [Activity(Label = "Item_activity")]
    public class Item_activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.feedItem);


            string id = Intent.GetStringExtra("id") ?? "Data not available";
            string name = Intent.GetStringExtra("name") ?? "Data not available";
            string timeStamp = Intent.GetStringExtra("timeStamp") ?? "Data not available";
            string status = Intent.GetStringExtra("status") ?? "Data not available";
            string profileImageId = Intent.GetStringExtra("profileImageId") ?? "Data not available";
            string PostImageId = Intent.GetStringExtra("PostImageId") ?? "Data not available";

            FindViewById<TextView>(Resource.Id.txtFullName).Text = name;
            FindViewById<TextView>(Resource.Id.txtTimestamp).Text = timeStamp;
            FindViewById<TextView>(Resource.Id.txtStatus).Text = status;
            FindViewById<ImageButton>(Resource.Id.btnItemMenu).Visibility = ViewStates.Gone;

            var btnDelete = FindViewById<Button>(Resource.Id.buttonDelete);
            var btnEdit = FindViewById<Button>(Resource.Id.buttonEdit);

            btnDelete.Click += BtnDelete_Click;
            btnEdit.Click += BtnEdit_Click;

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Data Changed Sucessfully", ToastLength.Short).Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Data Removed Sucessfully", ToastLength.Short).Show();
        }

        
    }
}