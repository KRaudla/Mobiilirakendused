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
using Android.Provider;
using Android.Content.PM;
using Java.IO;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

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

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(App._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display
            // Loading the full sized image will consume to much memory 
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = postPicture.Height;
            App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
            
            if (App.bitmap != null)
            {
                postPicture.SetImageBitmap(App.bitmap);
                App.bitmap = null;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
        }
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
                postsDB.Posts.insertUpdateData(post);
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
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.TitleFormatted.ToString() == "Photo")
            {
                //take pictures
                if (IsThereAnAppToTakePictures())
                {
                    CreateDirectoryForPictures();
                    Intent intent = new Intent(MediaStore.ActionImageCapture);
                    App._file = new Java.IO.File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
                    intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));
                    StartActivityForResult(intent, 0);
                }
            }

            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();


            return base.OnOptionsItemSelected(item);
        }

        //take picture
        public static class App
        {
            public static Java.IO.File _file;
            public static Java.IO.File _dir;
            public static Bitmap bitmap;
        }
        private void CreateDirectoryForPictures()
        {
            App._dir = new Java.IO.File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "CameraAppDemo");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }
          
        
    }
}