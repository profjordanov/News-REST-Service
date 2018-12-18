using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using News.Client.Models;
using Newtonsoft.Json;

namespace News.Client
{
    [Activity(Label = "Get All News")]
    public class GetNewsActivity : Activity
    {
        private static HttpClient httpClient = new HttpClient();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GetNews);

            FillNewsInSpinner();

            var btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Click += RenderMainActivity;
        }

        private void FillNewsInSpinner()
        {
            var spinner = FindViewById<Spinner>(Resource.Id.spinner1);

            var list = new List<NewsUxModel>();
            var uri = "http://10.0.2.2:56624/api/News";
            try
            {
                var result = httpClient.GetStringAsync(uri).GetAwaiter().GetResult(); 
                try
                {
                    var news = JsonConvert.DeserializeObject<List<NewsUxModel>>(result);
                    list.AddRange(news);
                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }
            catch (System.Exception exp)
            {
                var msg = exp.InnerException.Message;
                throw;
            }

            var newsTitleArr = list
                .Select(news => news.Title)
                .ToArray();

            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem,newsTitleArr);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
        }

        private void RenderMainActivity(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}