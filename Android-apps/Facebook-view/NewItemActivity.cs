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
using Android.Graphics;
using System.IO;


namespace Facebook_view
{
    [Activity(Label = "NewItemActivity", Theme = "@style/Theme.DesignDemo")]
    public class NewItemActivity : AppCompatActivity
    {
        private TextView name;
        private TextView status;
        private ImageView profilePicture;
        private ImageView postPicture;
        private Button btnAdd;
        private DateTime postTimeStamp;
        private Toolbar toolbar;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.newFeedItem);
            //toolbar
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            ActionBar.Title = "New post";

            //find controls
            name = FindViewById<TextView>(Resource.Id.txtName);
            status = FindViewById<TextView>(Resource.Id.txtStatus);
            profilePicture = FindViewById<ImageView>(Resource.Id.profileImage);
            postPicture = FindViewById<ImageView>(Resource.Id.postImage);
            btnAdd = FindViewById<Button>(Resource.Id.btnaddPost);
            //set values to controls
            postTimeStamp = DateTime.Now;
            profilePicture.SetImageResource(Resource.Drawable.profilePicture);//default profile picture
            //button listener
            btnAdd.Click += BtnAdd_Click;
        }

        //button listener
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //validation True
            if (Valitade_name(name )&& Valitade_status(status))
            {
                //new post object to save values
                var post = new Post();
                post.Name = name.Text;
                post.Timestamp = postTimeStamp;
                post.Status = status.Text;
                post.ProfileImageId = Resource.Drawable.profilePicture;
                //TO-DO take picture from gallery or take shot. 
                //post.PostImageId = Resource.Drawable.postPicture;

                //insert new post to database
                //postsDB.Posts.insertUpdateData(post);
                var db = new postsDB();
                db.makeConnection();
                db.insertUpdateData(post);

                Toast toast = Toast.MakeText(this, "Your post has been added", ToastLength.Long);
                toast.Show();
                name.Text = "";
                status.Text = "";

                var intent = new Intent(this, typeof(MainActivity));
                this.StartActivity(intent);
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
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
       
          
        
    }
}