using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using News.Client.Data;
using News.Client.Models;

namespace News.Client.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<ApiObjectResponse<TResponse>> GetAsync<TResponse>(
            this HttpApiClient httpClient, string uri, string queryString)
            where TResponse : new()
        {
            try
            {
                //var response = await httpClient.GetAsync(uri + queryString);
                //TResponse resultResponse = default(TResponse);
                //Error error = null;
                //if (response.IsSuccessStatusCode)
                //{
                //    resultResponse = JsonConvert.DeserializeObject<TResponse>(await result.Content.ReadAsStringAsync(););
                //}
                //else
                //{
                //    error = JsonConvert.DeserializeObject<Error>(await result.Content.ReadAsStringAsync());
                //}
                //return new ApiObjectResponse<TObject>
                //{
                //    Error = error,
                //    Response = resultResponse,
                //    StatusCode = response.StatusCode
                //};

                return new ApiObjectResponse<TResponse>();
            }
            catch (Exception e)
            {
                // LOG exeption
                throw;
            }
        }

        public static async Task<ApiObjectResponse<TResponse>> GetAsync<TResponse>(
            this HttpApiClient httpClient, string uri)
            where TResponse : new()
        {
            try
            {
                //var response = await httpClient.GetAsync(uri);
                //TResponse resultResponse = default(TResponse);
                //Error error = null;
                //if (response.IsSuccessStatusCode)
                //{
                //    resultResponse = JsonConvert.DeserializeObject<TResponse>(await result.Content.ReadAsStringAsync(););
                //}
                //else
                //{
                //    error = JsonConvert.DeserializeObject<Error>(await result.Content.ReadAsStringAsync());
                //}
                //return new ApiObjectResponse<TObject>
                //{
                //    Error = error,
                //    Response = resultResponse,
                //    StatusCode = response.StatusCode
                //};

                return new ApiObjectResponse<TResponse>();
            }
            catch (Exception e)
            {
                // LOG exeption
                throw;
            }
        }

        public static async Task<ApiObjectResponse<TResponse>> PostAsync<TRequest, TResponse>(
            this HttpApiClient httpClient, string uri, TRequest content)
            where TResponse : new()
        {
            //var myContent = JsonConvert.SerializeObject(content);
            //var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            //var byteContent = new ByteArrayContent(buffer);

            //byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //byteContent.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("charset", "utf-8"));

            //var result = await httpClient.PostAsync(uri, byteContent);

            //TResponse resultResponse = default;
            //Error error = null;

            //if (result.IsSuccessStatusCode)
            //{
            //    var a = await result.Content.ReadAsStringAsync();
            //    resultResponse = JsonConvert.DeserializeObject<TResponse>(a);
            //}
            //else
            //{
            //    error = JsonConvert.DeserializeObject<Error>(await result.Content.ReadAsStringAsync()); ;
            //}

            //return new ApiObjectResponse<TResponse>
            //{
            //    Error = error,
            //    Response = resultResponse,
            //    StatusCode = result.StatusCode
            //};

            return new ApiObjectResponse<TResponse>();
        }

        public static async Task<ApiResponse> UpdateAsync(
            this HttpApiClient httpClient, string requestUri, object content)
        {
            //var myContent = JsonConvert.SerializeObject(content);
			//var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
			//var byteContent = new ByteArrayContent(buffer);

			//byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			//byteContent.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("charset", "utf-8"));

			//var result = await httpClient.PutAsync(requestUri, byteContent);

			//Error error = null;

			//if (!result.IsSuccessStatusCode)
			//{
			//	error = JsonConvert.DeserializeObject<Error>(await result.Content.ReadAsStringAsync());;
			//}

			//return new ApiResponse
			//{
			//	Error = error,
			//	StatusCode = result.StatusCode
			//};

            return new ApiResponse();
        }

        public static async Task<ApiResponse> DeleteAsync(this HttpClient httpClient, string requestUri)
        {
            //var result = await httpClient.DeleteAsync(requestUri);

            //Error error = null;

            //if (!result.IsSuccessStatusCode)
            //{
            //    error = JsonConvert.DeserializeObject<Error>(await result.Content.ReadAsStringAsync()); ;
            //}

            //return new ApiResponse
            //{
            //    Error = error,
            //    StatusCode = result.StatusCode
            //};

            return new ApiResponse();
        }
    }
}