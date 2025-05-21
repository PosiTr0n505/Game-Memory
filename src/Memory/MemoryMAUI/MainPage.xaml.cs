using MemoryMAUI.Pages;

namespace MemoryMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void NavigateToSingleplayerPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SingleplayerPage());
        }
        private void NavigateToTwoplayersPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TwoPlayersPage());
        }
        private void NavigateToGamerulesPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MemoryRulesPage());
        }
        private void NavigateToLeaderboardPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LeaderboardPage());
        }
        private void NavigateToCreditsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreditsPage());
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
