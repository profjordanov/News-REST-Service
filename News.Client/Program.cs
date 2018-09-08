using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using News.Client.Data;
using News.Client.Services;

namespace News.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var serviceProvider = new BrowserServiceProvider(services =>
            {
                services.AddScoped<HttpApiClient>();

                services.AddSingleton<NewsServices>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");

            CreateHostBuilder(args).Build().Run();

        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
