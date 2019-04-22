using System.Collections.Generic;
using System.Threading.Tasks;
using RazorComponentsRealworld.Model;

namespace RazorComponentsRealworld.Services
{
    public class ArticlesService
    {
        private IApiService api;

        public ArticlesService(IApiService _api)
        {
            api = _api;
        }

        public async Task<ApiResponse<ArticlesResponse>> QueryAsync(IDictionary<string, string> Params = null)
        {
            return await api.GetAsync<ArticlesResponse>($"/articles/", Params);
        }

        public async Task<ApiResponse<ArticlesResponse>> GetAllAsync()
        {
            return await QueryAsync();
        }

        public async Task<ApiResponse<ArticleResponse>> GetAsync(string Slug)
        {
            return await api.GetAsync<ArticleResponse>($"/articles/{Slug}");
        }

        public async Task<ApiResponse<ArticlesResponse>> GetFeedAsync()
        {
            return await api.GetAsync<ArticlesResponse>($"/articles/feed");
        }

        public async Task<ApiResponse<ArticlesResponse>> GetByAuthorAsync(string author)
        {
            return await QueryAsync(new Dictionary<string, string>
            {
                {  "author", author }
            });
        }

        public async Task<ApiResponse<ArticlesResponse>> GetByTagAsync(string tag)
        {
            return await QueryAsync(new Dictionary<string, string>
            {
                {  "tag", tag }
            });
        }

        public async Task<bool> DeleteAsync(string Slug)
        {
            ApiResponse<ArticleModel> response = await api.DeleteAsync<ArticleModel>($"/articles/{Slug}");
            return response?.HasSuccessStatusCode ?? false;
        }

        public async Task<ArticleModel> SaveAsync(ArticleModel Value, string Slug = "")
        {
            ApiResponse<ArticleModel> response;

            if (string.IsNullOrWhiteSpace(Slug))
            {
                response = await api.PostAsync<ArticleModel>($"/articles/", Value);
            }
            else
            {
                response = await api.PutAsync<ArticleModel>($"/articles/{Slug}", Value);
            }

            return response?.Value;
        }

        public async Task<bool> FavoriteAsync(string Slug)
        {
            ApiResponse<ArticleModel> response = await api.PostAsync<ArticleModel>($"/articles/{Slug}/favorite", new ArticleModel());
            return response?.HasSuccessStatusCode ?? false;
        }

        public async Task<bool> UnfavoriteAsync(string Slug)
        {
            ApiResponse<ArticleModel> response = await api.DeleteAsync<ArticleModel>($"/articles/{Slug}/favorite");
            return response?.HasSuccessStatusCode ?? false;
        }
    }

    public class ArticlesResponse
    {
        public ArticleModel[] Articles { get; set; }
    }

    public class ArticleResponse
    {
        public ArticleModel Article { get; set; }
    }
}
