using System.Net;

namespace News.Client.Models
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public Error Error { get; set; }
    }
}