using MemoryMAUI.Resources.Views;

namespace MemoryMAUI
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private ContentView? _rightSideContentView = null;

        public ContentView? RightSideContentView 
        {
            get
            {
                return _rightSideContentView;
            }
            set
            {
                _rightSideContentView = value;
                OnPropertyChanged();
            }
        }

        private void BindSinglePlayerView(object sender, EventArgs e)
        {
            RightSideContentView = new SinglePlayerView();
        }
        private void BindTwoPlayersView(object sender, EventArgs e)
        {
            RightSideContentView = new TwoPlayersView();
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
