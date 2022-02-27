using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Youtube;
using Youtube.Options;
using Youtube.Services.Abstracts;

await RunTestYoutubeConsoleTestsAsync();

async Task RunTestYoutubeConsoleTestsAsync()
{
    var services = new ServiceCollection()
        .AddYoutube()
        .BuildServiceProvider();

    var config = services.GetRequiredService<IOptions<YoutubeConfiguration>>();
    var youtubeService = services.GetRequiredService<IYoutubeService>();
    var result = await youtubeService.GetFirstSearchVideoLinkAsync("spider+man+trailer");
}
