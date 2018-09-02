using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using News.Client.Data;
using News.Client.Extensions;
using News.Client.Models;
using static News.Client.WebServiceUrl;

namespace News.Client.Services
{
    public class NewsServices
    {
        private readonly HttpApiClient _httpClient;

        public NewsServices(HttpApiClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiObjectResponse<NewsViewModel>> CreateNews(NewsBindModel model)
            => await _httpClient.PostAsync<NewsBindModel, NewsViewModel>(NewsUrl, model);

        public async Task<List<NewsViewModel>> GetNews()
            => await _httpClient.GetJsonAsync<List<NewsViewModel>>(NewsUrl);

        public async Task<ApiObjectResponse<NewsViewModel>> GetSingleNews(int id)
            => await _httpClient.GetAsync<NewsViewModel>(string.Format(NewsWithIdUrl, id));

        //TODO: Update and delete
    }
}