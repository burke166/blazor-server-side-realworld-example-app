using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace RazorComponentsRealworld.Services
{
    public class JwtService : IJwtService
    {
        private readonly IJSRuntime jsRuntime;

        public JwtService(IJSRuntime _jsRuntime)
        {
            jsRuntime = _jsRuntime;
        }

        public async Task<string> GetTokenAsync()
        {
            return await jsRuntime.InvokeAsync<string>("Realworld.getToken");
        }

        public async Task<bool> SaveTokenAsync(string Token)
        {
            return await jsRuntime.InvokeAsync<bool>("Realworld.saveToken", Token);
        }

        public async Task<bool> DestroyTokenAsync()
        {
            return await jsRuntime.InvokeAsync<bool>("Realworld.destroyToken");
        }
    }
}
