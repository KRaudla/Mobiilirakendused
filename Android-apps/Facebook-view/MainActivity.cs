using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using SQLite;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Facebook_view.CategoryRecyclerView;

namespace Facebook_view
{
    [Activity(Label = "Facebook_view", MainLauncher = true, Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView _recyclerView;
        RecyclerView.LayoutManager _layoutManager;
        CategoryAdapter _adapter;
        List<Category> _categoryList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.feed);

            //create database and table
            var db = new postsDB();
            db.makeConnection();
            db.createTable();

            //delete table
            //db.clearAllPosts();
            //insert some posts to database
            db.initPostDB();


            

            //generate list of categories ... TEST
            _categoryList = new List<Category>();

            var category1 = new Category();
            category1.Name = "Toit";
            category1.ImageId = Resource.Drawable.toit48;
            _categoryList.Add(category1);

            var category2 = new Category();
            category2.Name = "Kingitused";
            category2.ImageId = Resource.Drawable.kingitused48;
            _categoryList.Add(category2);

            var category3 = new Category();
            category3.Name = "Meelelahutus";
            category3.ImageId = Resource.Drawable.meelelahutus48;
            _categoryList.Add(category3);

            var category4 = new Category();
            category4.Name = "Kodu";
            category4.ImageId = Resource.Drawable.kodu48;
            _categoryList.Add(category4);

            var category5 = new Category();
            category5.Name = "Auto";
            category5.ImageId = Resource.Drawable.auto48;
            _categoryList.Add(category5);

            var category6 = new Category();
            category6.Name = "Tervis";
            category6.ImageId = Resource.Drawable.tervis48;
            _categoryList.Add(category6);

            var category7 = new Category();
            category7.Name = "Ilu";
            category7.ImageId = Resource.Drawable.ilu48;
            _categoryList.Add(category7);

            var category8 = new Category();
            category8.Name = "Muu";
            category8.ImageId = Resource.Drawable.muu48;
            _categoryList.Add(category8);

            // Get our RecyclerView layout:
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _adapter = new CategoryAdapter(_categoryList);
            _recyclerView.SetAdapter(_adapter);
            _layoutManager = new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);
            _recyclerView.SetLayoutManager(_layoutManager);
            _adapter.ItemClick += _adapter_ItemClick;



            var posts = db.getAllPosts();
            var feed = FindViewById<ListView>(Resource.Id.listviewFeed);
            feed.Adapter = new CustomAdapter(this, posts);

            //var fabButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //fabButton.Click += FabButton_Click;
        }

        private void _adapter_ItemClick(object sender, int e)
        {
            int CategoryNum = e + 1;
            Toast.MakeText(this, "This is category no: " + CategoryNum, ToastLength.Short).Show();
        }

        private void FabButton_Click(object sender, System.EventArgs e)
        {
            //var intent = new Intent(this, typeof(NewItemActivity));
            var intent = new Intent(this, typeof(NewItemActivity));
            this.StartActivity(intent);
        }

        
    }
    
}

