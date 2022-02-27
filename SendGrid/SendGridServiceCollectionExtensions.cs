using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Options;
using System.Reflection;

namespace SendGrid
{
    public static class SendGridServiceCollectionExtensions
    {
        public static IServiceCollection AddSendGrid(this IServiceCollection services)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("sendgridSettings.json", false)
                .AddJsonFile("sendgridSettings.Development.json", true)
                .AddUserSecrets<SendGridConfiguration>(true)
                .Build();

            services.Configure<SendGridConfiguration>(options => configuration.Bind("SendGridConfig", options));

            return services;
        }
    }
}
