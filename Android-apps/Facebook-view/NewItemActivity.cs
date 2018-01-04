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

namespace Facebook_view
{
    [Activity(Label = "NewItemActivity", Theme = "@style/Theme.DesignDemo")]
    public class NewItemActivity : AppCompatActivity
    {
        private TextView name;
        private TextView status;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.newFeedItem);

            name = FindViewById<TextView>(Resource.Id.txtName);
            status = FindViewById<TextView>(Resource.Id.txtStatus);
            var btnAdd = FindViewById<Button>(Resource.Id.btnaddPost);

            btnAdd.Click += BtnAdd_Click;

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Valitade_name(name )&& Valitade_status(status))
            {
                var post = new Post();
                post.Name = name.Text;
                post.Timestamp = DateTime.Today;
            }
            

        }

        private Boolean Valitade_name(TextView name)
        {
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                name.Error = GetString(Resource.String.err_msg_name);
                name.RequestFocus();
                return false; 
            }
            return true;
        }
        private Boolean Valitade_status(TextView status)
        {
            if (string.IsNullOrWhiteSpace(status.Text))
            {
                status.Error = GetString(Resource.String.err_msg_message);
                status.RequestFocus();
                return false;
            }
            return true;
        }
    }
}