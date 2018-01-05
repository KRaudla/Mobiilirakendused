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
    [Activity(Label = "EditItemActivity",Theme = "@style/Theme.DesignDemo")]
    public class EditItemActivity : AppCompatActivity
    {
        private TextView name;
        private TextView status;
        private ImageView profilePicture;
        private ImageView postPicture;
        private Button btnEdit;
        private DateTime postTimeStamp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.editFeedItem);
            //whatś inside intent
            var itemId = Intent.Extras.GetInt("id");
            //ask item from database
            var item = postsDB.Posts.getPostById(itemId);
            //find controls
            name = FindViewById<TextView>(Resource.Id.txtName2);
            status = FindViewById<TextView>(Resource.Id.txtStatus2);
            profilePicture = FindViewById<ImageView>(Resource.Id.profileImage2);
            postPicture = FindViewById<ImageView>(Resource.Id.postImage2);
            btnEdit = FindViewById<Button>(Resource.Id.btnEditPost);
            postTimeStamp = DateTime.Now;
            //set values to controls
            name.Text = item.Name;
            status.Text = item.Status;
            profilePicture.SetImageResource(Resource.Drawable.profilePicture);//default profile picture
            //TO-DO...
            //postPicture.SetImageResource

            //button listener
            btnEdit.Click += BtnEdit_Click;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (Valitade_name(name) && Valitade_status(status))
            {
                //new post object to save values
                var post = new Post();
                post.Id= Intent.Extras.GetInt("id");//get post id from intent
                post.Name = name.Text;
                post.Timestamp = postTimeStamp;
                post.Status = status.Text;
                post.ProfileImageId = Resource.Drawable.profilePicture;
                
                //TO-DO take picture from gallery or take shot. 
                //post.PostImageId = Resource.Drawable.postPicture;

                //insert new post to database
                postsDB.Posts.updateData(post);
                Toast toast = Toast.MakeText(this, "Your post has been edited", ToastLength.Long);
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
    }
} 