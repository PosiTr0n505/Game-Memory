using MemoryMAUI.Pages;

namespace MemoryMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private async void NavigateToSingleplayerPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///singleplayerpage");
        }
        private async void NavigateToTwoplayersPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///twoplayerspage");
        }
        private async void NavigateToGamerulesPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///gamerulespage");
        }
        private async void NavigateToLeaderboardPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///leaderboardpage");
        }
        private async void NavigateToCreditsPage(object sender, EventArgs e)
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
