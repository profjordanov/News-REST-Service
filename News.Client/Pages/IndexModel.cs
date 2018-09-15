using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Browser.Http;
using Microsoft.AspNetCore.Blazor.Components;
using News.Client.Models;
using News.Client.Services;
using Newtonsoft.Json;

namespace News.Client.Pages
{
    public class IndexModel : BlazorComponent
    {
        [Inject]
        public NewsServices NewsServices { get; set; }

        public Error Error { get; set; }

        public List<NewsViewModel> News { get; set; }

        protected override async Task OnInitAsync()
        {
            var http = new HttpClient(new BrowserHttpMessageHandler())
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };
            var res = await http.GetAsync("News");

            var response = await res.Content.ReadAsStringAsync();

            var jsonRes = JsonConvert.DeserializeObject<List<NewsViewModel>>(response);

            News = jsonRes;
        }
    }
}