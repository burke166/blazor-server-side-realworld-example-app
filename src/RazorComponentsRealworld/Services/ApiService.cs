using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace RazorComponentsRealworld.Services
{
    public class ApiService : IApiService
    {
        const string BaseUrl = "https://conduit.productionready.io/api";
        private HttpClient httpClient;

        public ApiService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public void SetToken(string Token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", Token);
        }

        public void ClearToken()
        {
            httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<T> GetAsync<T>(string Path, IDictionary<string, string> Params = null)
        {
            return await httpClient.GetJsonAsync<T>(BuildUri(Path, Params));
        }

        public async Task<T> PutAsync<T>(T Value, string Path, IDictionary<string, string> Params = null)
        {
            return await httpClient.PutJsonAsync<T>(BuildUri(Path, Params), Value);
        }

        public async Task<T> PostAsync<T>(T Value, string Path, IDictionary<string, string> Params = null)
        {
            return await httpClient.PostJsonAsync<T>(BuildUri(Path, Params), Value);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string Path, IDictionary<string, string> Params = null)
        {
            return await httpClient.DeleteAsync(BuildUri(Path, Params));
        }

        protected string BuildUri(string Path, IDictionary<string, string> Params = null)
        {
            UriBuilder result = new UriBuilder($"{BaseUrl}{Path}");

            if (Params != null && Params.Count > 0)
            {
                foreach(string key in Params.Keys)
                {
                    string queryPart = key + "=" + Params[key];
                    if (result.Query != null && result.Query.Length > 1)
                        result.Query = result.Query.Substring(1) + "&" + queryPart;
                    else
                        result.Query = queryPart;
                }
            }

            return result.Uri.AbsoluteUri;
        }
    }
}
