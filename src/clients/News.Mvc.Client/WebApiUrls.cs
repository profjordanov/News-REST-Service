namespace News.Mvc.Client
{
    public class WebApiUrls
    {
        private const string BaseUrl = "https://jnewsapi.azurewebsites.net/api/";

        public static readonly string GetAllNews = $"{BaseUrl}News";
    }
}