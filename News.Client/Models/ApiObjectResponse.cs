namespace News.Client.Models
{
    public class ApiObjectResponse<T> : ApiResponse
    {
        public T Response { get; set; }
    }
}