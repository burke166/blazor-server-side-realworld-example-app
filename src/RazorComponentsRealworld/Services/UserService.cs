using System.Threading.Tasks;
using RazorComponentsRealworld.Model;

namespace RazorComponentsRealworld.Services
{
    public class UserService
    {
        private IJwtService jwtService;
        private IApiService api;
        private IConsoleLogService console;
        public UserModel User { get; set; }
        public bool IsAuthenticated { get; set; }
        
        public UserService(IJwtService _jwtService, IConsoleLogService _console, IApiService _api)
        {
            jwtService = _jwtService;
            api = _api;
            console = _console;
        }

        public async void PopulateAsync()
        {
            if (!string.IsNullOrEmpty(await jwtService.GetTokenAsync())) {
                var response = await api.GetAsync<UserResponse>("/user");
                User = response?.Value?.User ?? new UserModel();
            }
            else
            {
                PurgeAuth();
            }
        }

        private async void SetAuth(UserModel user)
        {
            if (user != null)
            {
                await jwtService.SaveTokenAsync(user.Token);
                User = user;
                IsAuthenticated = true;
            }
            else
            {
                PurgeAuth();
            }

        }

        private async void PurgeAuth()
        {
            await jwtService.DestroyTokenAsync();
            User = new UserModel();
            IsAuthenticated = false;
        }

        public async Task<ApiResponse<UserResponse>> AttemptAuth(string authType, UserCredentials credentials)
        {
            var response = await api.PostAsync<UserResponse>($"/users{authType}", new
            {
                user = credentials
            });

            SetAuth(response?.Value?.User);
            return response;
        }

        public async Task<ApiResponse<UserResponse>> Update(UserModel user)
        {
            var response = await api.PutAsync<UserResponse>("/user", user);

            if (response?.Value != null)
                User = response.Value.User;

            return response;
        }
    }

    public class UserResponse
    {
        public ErrorsModel Errors { get; set; }
        public UserModel User { get; set; }
    }

    public static class AuthenticationType
    {
        public const string Login = "/login";
        public const string Register = "";
    }
}
