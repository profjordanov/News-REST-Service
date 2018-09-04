using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using News.Client.Data;
using News.Client.Models;
using Newtonsoft.Json;

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
                var response = await httpClient.GetAsync(uri + queryString);
                TResponse resultResponse = default;
                Error error = null;
                if (response.IsSuccessStatusCode)
                {
                    resultResponse = JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    error = JsonConvert.DeserializeObject<Error>(await response.Content.ReadAsStringAsync());
                }
                return new ApiObjectResponse<TResponse>
                {
                    Error = error,
                    Response = resultResponse,
                    StatusCode = response.StatusCode
                };

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
                var response = await httpClient.GetAsync(uri);
                TResponse resultResponse = default;
                Error error = null;
                if (response.IsSuccessStatusCode)
                {
                    resultResponse = JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    error = JsonConvert.DeserializeObject<Error>(await response.Content.ReadAsStringAsync());
                }
                return new ApiObjectResponse<TResponse>
                {
                    Error = error,
                    Response = resultResponse,
                    StatusCode = response.StatusCode
                };

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
            var myContent = JsonConvert.SerializeObject(content);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            byteContent.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("charset", "utf-8"));

            var result = await httpClient.PostAsync(uri, byteContent);

            TResponse resultResponse = default;
            Error error = null;

            if (result.IsSuccessStatusCode)
            {
                var a = await result.Content.ReadAsStringAsync();
                resultResponse = JsonConvert.DeserializeObject<TResponse>(a);
            }
            else
            {
                error = JsonConvert.DeserializeObject<Error>(await result.Content.ReadAsStringAsync()); ;
            }

            return new ApiObjectResponse<TResponse>
            {
                Error = error,
                Response = resultResponse,
                StatusCode = result.StatusCode
            };

        }

        public static async Task<ApiResponse> UpdateAsync(
            this HttpApiClient httpClient, string requestUri, object content)
        {
            var myContent = JsonConvert.SerializeObject(content);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            byteContent.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("charset", "utf-8"));

            var result = await httpClient.PutAsync(requestUri, byteContent);

            Error error = null;

            if (!result.IsSuccessStatusCode)
            {
                error = JsonConvert.DeserializeObject<Error>(await result.Content.ReadAsStringAsync()); ;
            }

            return new ApiResponse
            {
                Error = error,
                StatusCode = result.StatusCode
            };
        }

        public static async Task<ApiResponse> DeleteAsync(this HttpClient httpClient, string requestUri)
        {
            var result = await httpClient.DeleteAsync(requestUri);

            Error error = null;

            if (!result.IsSuccessStatusCode)
            {
                error = JsonConvert.DeserializeObject<Error>(await result.Content.ReadAsStringAsync()); ;
            }

            return new ApiResponse
            {
                Error = error,
                StatusCode = result.StatusCode
            };

        }
    }
}