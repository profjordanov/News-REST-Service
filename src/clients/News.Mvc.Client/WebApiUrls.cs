namespace News.Mvc.Client
{
    public class WebApiUrls
    {
        private const string Base = "https://jnewsapi.azurewebsites.net/api/";

        public static readonly string BaseUrl = $"{Base}News";

        public static readonly string RegisterUser = $"{BaseUrl}Users/register";
    }
}