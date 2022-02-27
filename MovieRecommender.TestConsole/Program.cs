using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Youtube;
using Youtube.Options;

RunTestYoutubeConsoleTests();

void RunTestYoutubeConsoleTests()
{
    var services = new ServiceCollection()
        .AddYoutube()
        .BuildServiceProvider();

    var config = services.GetRequiredService<IOptions<YoutubeConfiguration>>();
}
