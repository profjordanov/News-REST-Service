using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Components;
using News.Client.Models;
using News.Client.Services;

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
            News = await NewsServices.GetNews();
        }
    }
}