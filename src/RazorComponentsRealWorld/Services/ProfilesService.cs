using System.Threading.Tasks;
using RazorComponentsRealWorld.Models;

namespace RazorComponentsRealWorld.Services
{
    public class ProfilesService
    {
        private readonly IApiService api;

        public ProfilesService(IApiService _api)
        {
            api = _api;
        }

        public async Task<ApiResponse<ProfileResponse>> GetAsync(string username)
        {
            return await api.GetAsync<ProfileResponse>($"/profiles/{username}");
        }

        public async Task<ApiResponse<ProfileResponse>> FollowAsync(string username)
        {
            return await api.PostAsync<ProfileResponse>($"/profiles/{username}/follow", null);
        }

        public async Task<ApiResponse<ProfileResponse>> UnfollowAsync(string username)
        {
            return await api.PostAsync<ProfileResponse>($"/profiles/{username}/follow", null);
        }

    }

    public class ProfileResponse
    {
        public ProfileModel Profile { get; set; }
    }
}
