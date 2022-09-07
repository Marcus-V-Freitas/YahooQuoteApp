using Microsoft.AspNetCore.Components.WebView.Maui;
using YahooQuoteApp.Data;
using YahooQuoteApp.Models.WEB;
using Microsoft.Extensions.Configuration;
using YahooQuoteApp.Data.Context;
using YahooQuoteApp.Mapper;
using System.Data.SQLite;
using YahooQuoteApp.Services;
using MediatR;

namespace YahooQuoteApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddScoped<IHttpHelper, HttpHelper>();
        builder.Services.AddScoped<IDbContext, YahooContext>(x =>
        {
            var dbName = "database.db";
            string dbPath = string.Empty;
#if WINDOWS
            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dbName);
#else
            dbPath = Path.Combine(Directory.GetCurrentDirectory(), dbName);
#endif
            var yahooContext = new YahooContext(dbPath);
            return yahooContext;
        });

        builder.Services.AddAutoMapper(typeof(MapperProfile));
        builder.Services.AddMediatR(typeof(MauiProgram));
        builder.Services.AddScoped<IYahooService, YahooService>();

        return builder.Build();
    }
}
