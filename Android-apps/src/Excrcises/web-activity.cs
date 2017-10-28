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
using Android.Webkit;

namespace Excrcises
{
    [Activity(Label = "web_activity")]
    public class web_activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.webLayout);//web layout view

            var webview = FindViewById<WebView>(Resource.Id.webView1);
            webview.SetWebViewClient(new WebViewClient());
            webview.LoadUrl("http://www.ee/");
            
            

        }
    }
}