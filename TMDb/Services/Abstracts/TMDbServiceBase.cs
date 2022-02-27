using Microsoft.Extensions.Options;
using TMDb.Options;

namespace TMDb.Services.Abstracts
{
    public abstract class TMDbServiceBase
    {
        protected readonly TMDbConfiguration config;
        protected readonly HttpClient client;

        public TMDbServiceBase(IOptions<TMDbConfiguration> config)
        {
            this.config = config.Value;
            client = new HttpClient();
        }
    }
}