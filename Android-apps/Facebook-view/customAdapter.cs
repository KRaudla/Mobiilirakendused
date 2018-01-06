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
using Java.Lang;

namespace Facebook_view
{
    //public class CustomAdapter : BaseAdapter
    public class CustomAdapter :BaseAdapter

    {
        List<Post> items;
        Activity context;
        

        public CustomAdapter(Activity context, List<Post> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null; // could wrap a Contact in a Java.Lang.Object to return it here if needed
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.feedItem, null);
                view.FindViewById<TextView>(Resource.Id.txtFullName).Text = items[position].Name;
                view.FindViewById<TextView>(Resource.Id.txtTimestamp).Text = items[position].Timestamp.ToString();
                view.FindViewById<TextView>(Resource.Id.txtStatus).Text = items[position].Status.ToString();
                view.FindViewById<ImageView>(Resource.Id.postImage).SetImageResource(items[position].PostImageId);
            view.FindViewById<ImageView>(Resource.Id.profileImage).SetImageResource(items[position].ProfileImageId);
        //item button
            var itemButton = view.FindViewById<ImageButton>(Resource.Id.btnItemMenu);
            //avoid stealing itemclick focus
            itemButton.Focusable = false;
            itemButton.FocusableInTouchMode = false;
            itemButton.Clickable = true;

            itemButton.Tag = items[position].ID;

            itemButton.Click += (sender, args) =>
            {
                //int itemId = (int)itemButton.Tag;
                PopupMenu menu = new PopupMenu(this.context, itemButton);
                menu.Inflate(Resource.Menu.item_menu);
                menu.Show();

                menu.MenuItemClick += (s1, arg1) =>
                {
                    
                    switch (arg1.Item.TitleFormatted.ToString())
                    {
                        case "Muuda":
                            var editItemActivity = new Intent(context, typeof(EditItemActivity));
                            Bundle bundleMe = new Bundle();
                            bundleMe.PutInt("id",(int)itemButton.Tag);
                            //pass item id to next activity
                            editItemActivity.PutExtras(bundleMe);
                            context.StartActivity(editItemActivity);
                            break;
                        case "Kustuta":
                            var db = new postsDB();
                            db.makeConnection();

                            int id = (int)itemButton.Tag;//get id from tag
                            db.deletePostById(id);//delete post from database

                            this.items.RemoveAt(position);//delete item from adapter list
                            context.RunOnUiThread(() => this.NotifyDataSetChanged());//update adapter and listview

                            Android.Widget.Toast.MakeText(context, "Postitus kustutatud", Android.Widget.ToastLength.Short).Show();
                            
                            break;
                    }
                };
            };
        return view;
        }
        
    }
}