using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MemoryLib.Managers;
using MemoryLib.Managers.Interface;
using Persistence;
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
            var saveFilePath = Path.Combine(FileSystem.AppDataDirectory, "scores.json");
            builder.Services.AddSingleton<ILoadManager>(_ => new JsonLoadManager(saveFilePath));
            builder.Services.AddSingleton<ISaveManager>(_ => new JsonSaveManager(saveFilePath));
        #else
            var saveFilePath = Path.Combine(FileSystem.AppDataDirectory, "scores.xml");
            builder.Services.AddSingleton<ILoadManager>(_ => new XmlLoadManager(saveFilePath));
            builder.Services.AddSingleton<ISaveManager>(_ => new XmlSaveManager(saveFilePath));
        #endif


            builder.Services.AddSingleton<LeaderboardPage>();
            builder.Services.AddTransient<SingleplayerGamePage>();

            return builder.Build();
        }
    }
}
