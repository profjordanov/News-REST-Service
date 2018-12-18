using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System.Threading.Tasks;
using News.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Android.Content;

namespace News.Client
{
    [Activity(Label = "News Client App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button getBtn = FindViewById<Button>(Resource.Id.button1);
            Button createBtn = FindViewById<Button>(Resource.Id.button2);

            TextView text = FindViewById<TextView>(Resource.Id.textView1);
            getBtn.Click += RenderGetNewsActivity;
            createBtn.Click += RenderCreateNewsActivity;
        }

        private void RenderCreateNewsActivity(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(CreateNewsActivity));
            StartActivity(intent);
        }

        private void RenderGetNewsActivity(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(GetNewsActivity));
            StartActivity(intent);
        }
    }
}


