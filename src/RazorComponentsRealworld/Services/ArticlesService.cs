using System.Collections.Generic;
using System.Net.Http;
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
            ArticlesResponse articles = await api.GetAsync<ArticlesResponse>($"/articles/", Params);
            return articles.Articles;
        }

        public async Task<ArticleModel> GetAsync(string Slug)
        {
            return await api.GetAsync<ArticleModel>($"/articles/{Slug}");
        }

        public async Task<HttpResponseMessage> DeleteAsync(string Slug)
        {
            return await api.DeleteAsync($"/articles/{Slug}");
        }

        public async Task<ArticleModel> SaveAsync(ArticleModel Value, string Slug = "")
        {
            if (string.IsNullOrWhiteSpace(Slug))
            {
                return await api.PostAsync<ArticleModel>(Value, $"/articles/");
            }
            else
            {
                return await api.PutAsync<ArticleModel>(Value, $"/articles/{Slug}");
            }
        }

        public async Task<ArticleModel> FavoriteAsync(string Slug)
        {
            return await api.PostAsync<ArticleModel>(new ArticleModel(), $"/articles/{Slug}/favorite");
        }

        public async Task<HttpResponseMessage> UnfavoriteAsync(string Slug)
        {
            return await api.DeleteAsync($"/articles/{Slug}/favorite");
        }
    }

    internal class ArticlesResponse
    {
        public ArticleModel[] Articles { get; set; }
    }
}
