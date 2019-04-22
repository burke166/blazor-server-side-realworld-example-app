using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorComponentsRealWorld.Models;

namespace RazorComponentsRealWorld.Services
{
    public class ProfilesService
    {
        private IApiService api;

        public ProfilesService(IApiService _api)
        {
            api = _api;
        }

        public async Task<ApiResponse<ProfileResponse>> GetAsync(string Slug)
        {
            return await api.GetAsync<ProfileResponse>($"/articles/{Slug}");
        }
    }

    public class ProfileResponse
    {
        public ProfileModel Profile { get; set; }
    }
}
