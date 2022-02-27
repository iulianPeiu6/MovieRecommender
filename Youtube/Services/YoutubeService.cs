using Microsoft.Extensions.Options;
using System.Net.Http;
using Youtube.Options;
using Youtube.Services.Abstracts;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace Youtube.Services
{
    public class YoutubeService : YoutubeServiceBase, IYoutubeService
    {
        public YoutubeService(IOptions<YoutubeConfiguration> config) : base(config)
        {
        }

        public async Task<string> GetFirstSearchVideoLinkAsync(string searchText)
        {
            var query = new Dictionary<string, string>()
            {
                ["part"] = "snippet",
                ["q"] = searchText,
                ["key"] = config.ApiKey
            };

            var request = QueryHelpers.AddQueryString(config.WebApiEndpoint.SearchV3, query);

            var response = await client.GetAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            var parsedResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);

            var videoId = parsedResponse.items[0].id.videoId;
            
            return $"{config.WebUiEndpoint.Watch}?v={videoId}";
        }
    }
}
