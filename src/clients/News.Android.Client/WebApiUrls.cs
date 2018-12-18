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

namespace News.Client
{
    public class WebApiUrls
    {
        private const string Base = "https://jnewsapi.azurewebsites.net/api/";

        public static readonly string BaseUrl = $"{Base}News";

        public static readonly string RegisterUser = $"{BaseUrl}Users/register";
    }
}