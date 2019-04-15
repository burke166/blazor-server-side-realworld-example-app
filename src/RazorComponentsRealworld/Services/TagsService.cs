using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorComponentsRealworld.Services
{
    public class TagsService
    {
        private IApiService api;

        public TagsService(IApiService _api)
        {
            api = _api;
        }

        public async Task<IEnumerable<string>> QueryAsync(IDictionary<string, string> Params = null)
        {
            TagResponse tags = await api.GetAsync<TagResponse>($"/tags/", Params);
            return tags.Tags;
        }

        public async Task<IEnumerable<string>> GetAllAsync()
        {
            return await QueryAsync();
        }
    }

    internal class TagResponse
    {
        public string[] Tags { get; set; }
    }
}
