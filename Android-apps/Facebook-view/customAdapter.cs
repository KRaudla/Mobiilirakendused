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
                
                
        //dont show buttons in feed
            view.FindViewById<Button>(Resource.Id.buttonEdit).Visibility = ViewStates.Gone;
        //item button
            var itemButton = view.FindViewById<ImageButton>(Resource.Id.btnItemMenu);
            
            itemButton.Tag = items[position].Id;

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
                            Android.Widget.Toast.MakeText(context, "Muudan", Android.Widget.ToastLength.Short).Show();
                            var itemActivity = new Intent(context, typeof(Item_activity));
                            Bundle bundleMe = new Bundle();
                            bundleMe.PutInt("id",(int)itemButton.Tag);
                            //pass item id to next activity
                            itemActivity.PutExtras(bundleMe);
                            context.StartActivity(itemActivity);
                            break;
                        case "Kustuta":
                            Android.Widget.Toast.MakeText(context, "Kustutan", Android.Widget.ToastLength.Short).Show();
                            break;
                    }
                };
            };
        return view;
        }

        
                
            
        
    }
}