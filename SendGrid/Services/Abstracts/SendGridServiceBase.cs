using Microsoft.Extensions.Options;
using SendGrid.Options;

namespace SendGrid.Services.Abstracts
{
    public abstract class SendGridServiceBase
    {
        protected readonly SendGridConfiguration config;
        protected readonly HttpClient client;
        public SendGridServiceBase(IOptions<SendGridConfiguration> config)
        {
            this.config = config.Value;
            this.client = new HttpClient();
        }
    }
}