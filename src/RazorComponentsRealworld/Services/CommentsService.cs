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
            return await api.PostAsync<CommentModel>(Comment, $"/articles/{Slug}/comments");
        }

        public async Task<CommentModel> AddAsync(ArticleModel Article, CommentModel Comment)
        {
            return await AddAsync(Article.Slug, Comment);
        }

        public async Task<IEnumerable<CommentModel>> GetAllAsync(string Slug)
        {
            CommentRepsonse comments = await api.GetAsync<CommentRepsonse>($"/articles/{Slug}/comments");
            return comments.Comments;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string Slug, int CommentId)
        {
            return await api.DeleteAsync($"/articles/{Slug}/comments/{CommentId.ToString()}");
        }

        public async Task<HttpResponseMessage> DeleteAsync(string Slug, CommentModel Comment)
        {
            return await DeleteAsync(Slug, Comment.Id);
        }

        public async Task<HttpResponseMessage> DeleteAsync(ArticleModel Article, CommentModel Comment)
        {
            return await DeleteAsync(Article.Slug, Comment.Id);
        }

        public async Task<HttpResponseMessage> DeleteAsync(ArticleModel Article, int CommentId)
        {
            return await DeleteAsync(Article.Slug, CommentId);
        }
    }

    internal class CommentRepsonse
    {
        public CommentModel[] Comments { get; set; }
    }
}
