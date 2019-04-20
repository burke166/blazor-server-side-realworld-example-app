using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RazorComponentsRealworld.Model;

namespace RazorComponentsRealworld.Services
{
    public class CommentsService
    {
        private IApiService api;

        public CommentsService(IApiService _api)
        {
            api = _api;
        }

        public async Task<CommentModel> AddAsync(string Slug, CommentModel Comment)
        {
            var response = await api.PostAsync<CommentModel>($"/articles/{Slug}/comments", Comment);
            return response?.Value;
        }

        public async Task<CommentModel> AddAsync(ArticleModel Article, CommentModel Comment)
        {
            return await AddAsync(Article.Slug, Comment);
        }

        public async Task<IEnumerable<CommentModel>> GetAllAsync(string Slug)
        {
            var response = await api.GetAsync<CommentRepsonse>($"/articles/{Slug}/comments");
            return response?.Value?.Comments;
        }

        public async Task<bool> DeleteAsync(string Slug, int CommentId)
        {
            var response = await api.DeleteAsync<CommentModel>($"/articles/{Slug}/comments/{CommentId.ToString()}");
            return response?.HasSuccessStatusCode ?? false;
        }

        public async Task<bool> DeleteAsync(string Slug, CommentModel Comment)
        {
            return await DeleteAsync(Slug, Comment.Id);
        }

        public async Task<bool> DeleteAsync(ArticleModel Article, CommentModel Comment)
        {
            return await DeleteAsync(Article.Slug, Comment.Id);
        }

        public async Task<bool> DeleteAsync(ArticleModel Article, int CommentId)
        {
            return await DeleteAsync(Article.Slug, CommentId);
        }
    }

    internal class CommentRepsonse
    {
        public CommentModel[] Comments { get; set; }
    }
}
