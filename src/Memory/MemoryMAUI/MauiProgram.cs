using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MemoryLib.Managers;
using MemoryLib.Managers.Interface;
using MemoryStubPersistence;
using MemoryMAUI.Pages;
using MemoryLib.Models;
using MemoryJSONPersistence;
using MemoryXMLPersistence;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MemoryMAUI
{
    public static class MauiProgram
    {
        private readonly static MauiAppBuilder builder = MauiApp.CreateBuilder();

        public static MauiApp CreateMauiApp()
        {
            
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

        #if USE_JSON

            builder.Services.AddSingleton<ILoadManager>(s =>
                new JsonLoadManager(Path.Combine(FileSystem.AppDataDirectory, "scores.json")));

            builder.Services.AddSingleton<ISaveManager>(s =>
                new JsonSaveManager(Path.Combine(FileSystem.AppDataDirectory, "scores.json")));
#else
            string savePath = Path.Combine(FileSystem.AppDataDirectory, "scores.xml");

            builder.Services.AddSingleton<ILoadManager>(_ => new XmlLoadManager(savePath));
            builder.Services.AddSingleton<ISaveManager>(_ => new XmlSaveManager(savePath));
#endif



            builder.Services.AddSingleton<ILoadManager, StubLoadManager>();
            builder.Services.AddSingleton<ISaveManager, StubSaveManager>();
            builder.Services.AddSingleton<ScoreManager>();
            builder.Services.AddSingleton<LeaderboardPage>();

            builder.Services.AddTransient<SingleplayerGamePage>();
            Routing.RegisterRoute("singleplayergamepage", typeof(SingleplayerGamePage));

            builder.Services.AddTransient<TwoPlayersGamePage>();
            Routing.RegisterRoute("twoplayersgamepage", typeof(TwoPlayersGamePage));

            builder.Services.AddTransient<EndgameSingleplayerScreenPage>();
            Routing.RegisterRoute("endgamesingleplayerscreenpage", typeof(EndgameSingleplayerScreenPage));

            builder.Services.AddTransient<EndgameTwoPlayersScreenPage>();
            Routing.RegisterRoute("endgametwoplayersscreenpage", typeof(EndgameTwoPlayersScreenPage));

            return builder.Build();
        }
    }
}
