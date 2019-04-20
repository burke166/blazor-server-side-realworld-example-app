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

        public async Task<IEnumerable<ArticleModel>> QueryAsync(IDictionary<string, string> Params = null)
        {
            ApiResponse<ArticlesResponse> articles = await api.GetAsync<ArticlesResponse>($"/articles/", Params);
            return articles?.Value?.Articles;
        }

        public async Task<IEnumerable<ArticleModel>> GetAllAsync()
        {
            return await QueryAsync();
        }

        public async Task<ArticleModel> GetAsync(string Slug)
        {
            ApiResponse<ArticleResponse> article = await api.GetAsync<ArticleResponse>($"/articles/{Slug}");
            return article?.Value?.Article;
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

    internal class ArticlesResponse
    {
        public ArticleModel[] Articles { get; set; }
    }

    internal class ArticleResponse
    {
        public ArticleModel Article { get; set; }
    }
}
