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
        //private postsDB postsDB = postsDB.Posts;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.feedItem);

            var itemId = Intent.Extras.GetInt("id");
            //TO-DO....getpostbyid do not return object
            var item=postsDB.Posts.getPostById(itemId);
            
             
            FindViewById<TextView>(Resource.Id.txtFullName).Text =item.Name;
            FindViewById<TextView>(Resource.Id.txtTimestamp).Text = item.Timestamp;
            FindViewById<TextView>(Resource.Id.txtStatus).Text = item.Status;

            FindViewById<ImageButton>(Resource.Id.btnItemMenu).Visibility = ViewStates.Gone;

            var btnEdit = FindViewById<Button>(Resource.Id.buttonEdit);
            btnEdit.Click += BtnEdit_Click;
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            
            Toast.MakeText(this, "Data Changed Sucessfully", ToastLength.Short).Show();
        }        
    }
}