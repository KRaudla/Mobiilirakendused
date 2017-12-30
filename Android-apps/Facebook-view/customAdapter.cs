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
                view.FindViewById<Button>(Resource.Id.buttonDelete).Visibility = ViewStates.Gone;
                view.FindViewById<Button>(Resource.Id.buttonEdit).Visibility = ViewStates.Gone;

                var itemButton = view.FindViewById<ImageButton>(Resource.Id.btnItemMenu);
                itemButton.Tag = position;
                itemButton.SetOnClickListener(new ButtonClickListener(this.context));

            return view;
        }

        private class ButtonClickListener : Java.Lang.Object, View.IOnClickListener
        {
            private Activity activity;

            public ButtonClickListener(Activity activity)
            {
                this.activity = activity;
            }

            public void OnClick(View v)
            {
                var itemId = (int)v.Tag;
                PopupMenu menu = new PopupMenu(this.activity, v);
                menu.Inflate(Resource.Menu.item_menu);
                menu.Show();
                menu.MenuItemClick += (s1, arg1) => {
                    switch (arg1.Item.TitleFormatted.ToString())
                    {
                        case "Muuda":
                            Android.Widget.Toast.MakeText(this.activity, "Muudan", Android.Widget.ToastLength.Short).Show();
                            var secondActivity = new Intent(this.activity, typeof(Item_activity));
                            
                            //secondActivity.PutExtra("MyData", "Hello World");
                            this.activity.StartActivity(secondActivity);
                            break;
                        case "Kustuta":
                            Android.Widget.Toast.MakeText(this.activity, "Kustutan", Android.Widget.ToastLength.Short).Show();
                            
                            break;
                    }
                };
                
            }
        }
    }
}