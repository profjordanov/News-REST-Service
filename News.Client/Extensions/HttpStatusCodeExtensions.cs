using System.Net;

namespace News.Client.Extensions
{
    public static class HttpStatusCodeExtensions
    {
        public static bool IsSuccessStatusCode(this HttpStatusCode httpWebResponse) =>
            ((int)httpWebResponse >= 200) && ((int)httpWebResponse <= 299);
    }
}
