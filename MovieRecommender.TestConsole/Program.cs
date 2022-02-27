using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Models;
using SendGrid.Options;
using SendGrid.Services.Abstracts;
using Youtube;
using Youtube.Options;
using Youtube.Services.Abstracts;

//await RunYoutubeConsoleTestsAsync();
await RunSendGridConsoleTestsAsync();

async Task RunYoutubeConsoleTestsAsync()
{
    var services = new ServiceCollection()
        .AddYoutube()
        .BuildServiceProvider();

    var config = services.GetRequiredService<IOptions<YoutubeConfiguration>>();
    var youtubeService = services.GetRequiredService<IYoutubeService>();
    var result = await youtubeService.GetFirstSearchVideoLinkAsync("spider+man+trailer");
}

async Task RunSendGridConsoleTestsAsync()
{
    var services = new ServiceCollection()
        .AddSendGrid()
        .BuildServiceProvider();

    var config = services.GetRequiredService<IOptions<SendGridConfiguration>>();
    var sendgridService = services.GetRequiredService<ISendGridService>();
    var mail = new Mail
    {
        ReceiverEmailAddress = "iulianpeiu6@gmail.com",
        Body = "Test"
    };
    var result = await sendgridService.SendAsync(mail);
}
