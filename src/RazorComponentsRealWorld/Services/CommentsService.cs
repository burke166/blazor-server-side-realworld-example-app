using System.Threading.Tasks;
using RazorComponentsRealWorld.Models;

namespace RazorComponentsRealWorld.Services
{
    public class CommentsService
    {
        private IApiService api;

        public CommentsService(IApiService _api)
        {
            api = _api;
        }

        public async Task<ApiResponse<CommentResponse>> AddAsync(string Slug, CommentModel Comment)
        {
            var response = await api.PostAsync<CommentResponse>($"/articles/{Slug}/comments", Comment);
            return response;
        }

        public async Task<ApiResponse<CommentResponse>> AddAsync(ArticleModel Article, CommentModel Comment)
        {
            return await AddAsync(Article.Slug, Comment);
        }

        public async Task<ApiResponse<CommentsResponse>> GetAllAsync(string Slug)
        {
            var response = await api.GetAsync<CommentsResponse>($"/articles/{Slug}/comments");
            return response;
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

    public class CommentsResponse
    {
        public CommentModel[] Comments { get; set; }
    }

    public class CommentResponse
    {
        public CommentModel Comment { get; set; }
    }
}
