using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;

namespace Facebook_view
{
    [Activity(Label = "Facebook_view", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.feed);
            SetContentView(Resource.Layout.NewPostLayout);
/*            var feed = FindViewById<ListView>(Resource.Id.listviewFeed);//define list object
            var posts = GeneratePosts();//generate list of cars
            feed.Adapter = new CustomAdapter(this, posts);

            //test want to open new post view, when item clicked.....
            
            feed.ItemClick += Feed_ItemClick;
            */
        }
        /*


        private void Feed_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            var postActivity = new Intent(this, typeof(PostActivity));
            StartActivity(postActivity);
            Android.Widget.Toast.MakeText(this, "Vajutasid", Android.Widget.ToastLength.Short).Show();
        }

        private List<Post> GeneratePosts()
        {
            var posts = new List<Post>();
            var post1 = new Post();
            post1.Id = 1;
            post1.Name = "Kaspar Raudla";
            post1.Timestamp = "10.12.2017";
            post1.Status = "Tere, see on minu postituse staatus";
            post1.PostImageId = Resource.Drawable.mycar;
            post1.ProfileImageId = Resource.Drawable.unnamed;
            posts.Add(post1);

            var post2 = new Post();
            post2.Id = 1;
            post2.Name = "Kaspar Raudla";
            post2.Timestamp = "10.12.2017";
            post2.Status = "Tere, see on minu postituse staatus";
            post2.PostImageId = Resource.Drawable.mycar;
            post2.ProfileImageId = Resource.Drawable.unnamed;
            posts.Add(post2);

            var post3 = new Post();
            post3.Id = 1;
            post3.Name = "Kaspar Raudla";
            post3.Timestamp = "10.12.2017";
            post3.Status = "Tere, see on minu postituse staatus";
            post3.PostImageId = Resource.Drawable.mycar;
            post3.ProfileImageId = Resource.Drawable.unnamed;
            posts.Add(post3);

            var post4 = new Post();
            post4.Id = 1;
            post4.Name = "Kaspar Raudla";
            post4.Timestamp = "10.12.2017";
            post4.Status = "Tere, see on minu postituse staatus";
            post4.PostImageId = Resource.Drawable.mycar;
            post4.ProfileImageId = Resource.Drawable.unnamed;
            posts.Add(post4);


            return posts;
        }
        */
    }

}

