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
using Android.Support.V7.App;
using Refractored.Controls;

namespace Facebook_view
{
    [Activity(Label = "Item_activity", Theme = "@style/Theme.DesignDemo")]
    public class Item_activity : AppCompatActivity
    {
        //private postsDB postsDB = postsDB.Posts;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.feedItem);

            var itemId = Intent.Extras.GetInt("id");
            var item=postsDB.Posts.getPostById(itemId);
            
             
            FindViewById<TextView>(Resource.Id.txtFullName).Text =item.Name;
            FindViewById<TextView>(Resource.Id.txtTimestamp).Text = item.Timestamp.ToString();
            FindViewById<TextView>(Resource.Id.txtStatus).Text = item.Status;
            FindViewById<CircleImageView>(Resource.Id.profileImage).SetImageResource(item.ProfileImageId);

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