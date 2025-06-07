using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MemoryLib.Managers;
using MemoryLib.Managers.Interface;
using MemoryStubPersistence;
using MemoryMAUI.Pages;
using MemoryLib.Models;

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

            builder.Services.AddSingleton<ILoadManager, StubLoadManager>();
            builder.Services.AddSingleton<ISaveManager, StubSaveManager>();
            builder.Services.AddSingleton<IScoreManager, ScoreManager>();
            builder.Services.AddSingleton<LeaderboardPage>();

            return builder.Build();
        }
    }
}
