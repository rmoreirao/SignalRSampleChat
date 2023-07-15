using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR(hubOptions =>
    {
        // Add the Language filter for this specific hub - all calls will be filtered
        hubOptions.AddFilter<LanguageHubFilter>();
    }).AddAzureSignalR();


builder.Services.AddSingleton<LanguageHubFilter>();


// This is the Code to add Debuging - also appsettings need to be adjusted
builder.Host.ConfigureLogging((hostingContext, logging) =>
        {
            logging.AddConsole();
            logging.AddDebug();
        });

var app = builder.Build();

app.UseDefaultFiles();
app.UseRouting();
app.UseStaticFiles();
app.MapHub<ChatSampleHub>("/chat");
app.Run();