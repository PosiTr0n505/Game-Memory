using System.Security.Cryptography.X509Certificates;
using MemoryLib.Models;

namespace MemoryMAUI
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }
        private async void BindSinglePlayerView(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///singleplayerpage");
        }
        private async void BindTwoPlayersView(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///twoplayerspage");
        }
        private async void BindGamerulesPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///gamerulespage");
        }
        private async void BindLeaderboardPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///leaderboardpage");
        }
        private async void BindCreditsPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///creditspage");
        }
        private void QuitButton_Clicked(object sender, EventArgs e)
        {
#if ANDROID
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#elif WINDOWS
            System.Environment.Exit(0);
#else
            Application.Current.Quit();
#endif
        }
    }

}
