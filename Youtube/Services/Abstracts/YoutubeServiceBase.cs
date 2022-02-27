using Microsoft.Extensions.Options;
using Youtube.Options;

namespace Youtube.Services.Abstracts
{
    public abstract class YoutubeServiceBase
    {
        protected readonly YoutubeConfiguration config;
        protected readonly HttpClient client;

        public YoutubeServiceBase(IOptions<YoutubeConfiguration> config)
        {
            this.config = config.Value;
            client = new HttpClient();
        }
    }
}
