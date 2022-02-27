using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Youtube.Options;
using Youtube.Services.Abstracts;

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

            var videoId = string.Empty;
            try
            {
                videoId = parsedResponse?.items[0]?.id?.videoId;
            }
            catch
            {
                // Ignored
            }

            return $"{config.WebUiEndpoint.Watch}?v={videoId}";
        }
    }
}
