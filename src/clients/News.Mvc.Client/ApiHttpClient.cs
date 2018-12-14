using System;
using System.Collections.Generic;
using System.Net.Http;
using News.Mvc.Client.Models;
using Newtonsoft.Json;

namespace News.Mvc.Client
{
    public static class ApiHttpClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static NewsUxModel[] GetAllNews()
        {
            try
            {
                var result = HttpClient.GetStringAsync(WebApiUrls.GetAllNews)
                    .GetAwaiter()
                    .GetResult();

                var news = JsonConvert.DeserializeObject<List<NewsUxModel>>(result);

                return news.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}