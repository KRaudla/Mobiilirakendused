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

            FindViewById<TextView>(Resource.Id.txtFullName).Text = Intent.GetStringExtra("FullName");
            FindViewById<TextView>(Resource.Id.txtTimestamp).Text = Intent.GetStringExtra("TimeStamp");
            FindViewById<TextView>(Resource.Id.txtStatus).Text = Intent.GetStringExtra("StatusMsg");

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