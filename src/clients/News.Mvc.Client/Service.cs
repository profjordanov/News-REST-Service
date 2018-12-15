using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using News.Mvc.Client.Models;
using Newtonsoft.Json;

namespace News.Mvc.Client
{
    public static class Service
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static NewsUxModel[] GetAllNews()
        {
            try
            {
                var response = HttpClient.GetStringAsync(WebApiUrls.BaseUrl)
                    .GetAwaiter()
                    .GetResult();

                var news = JsonConvert.DeserializeObject<List<NewsUxModel>>(response);

                return news.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static bool PostNews(NewsBindingModel model)
        {
            try
            {
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(model),
                    Encoding.UTF8,
                    "application/json");

                var response = HttpClient.PostAsync(WebApiUrls.BaseUrl, stringContent)
                    .GetAwaiter()
                    .GetResult();

                return response.IsSuccessStatusCode;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string Delete(BaseModel baseModel)
        {
            try
            {
                var response = HttpClient.DeleteAsync($"{WebApiUrls.BaseUrl}/?id={baseModel.Id}")
                    .GetAwaiter()
                    .GetResult();

                var result = response.Content
                    .ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                var messageModel = JsonConvert.DeserializeObject<MessageModel>(result);

                return messageModel.Messages[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static bool RegisterUser(RegisterUserModel model)
        {
            try
            {
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(model),
                    Encoding.UTF8,
                    "application/json");

                var response = HttpClient.PostAsync(WebApiUrls.RegisterUser, stringContent)
                    .GetAwaiter()
                    .GetResult();

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}