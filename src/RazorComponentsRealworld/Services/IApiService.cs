using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RazorComponentsRealworld.Services
{
    public interface IApiService
    {
        void SetToken(string Token);
        void ClearToken();
        Task<T> GetAsync<T>(string Path, IDictionary<string, string> Params = null);
        Task<T> PutAsync<T>(T Value, string Path, IDictionary<string, string> Params = null);
        Task<T> PostAsync<T>(T Value, string Path, IDictionary<string, string> Params = null);
        Task<HttpResponseMessage> DeleteAsync(string Path, IDictionary<string, string> Params = null);
    }
}
