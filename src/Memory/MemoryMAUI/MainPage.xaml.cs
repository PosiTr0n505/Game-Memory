using MemoryMAUI.Resources.Views;
using MemoryLib.Managers;
using MemoryLib.Managers.Interface;

namespace MemoryMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly ScoreManager _scoreManager;

        public MainPage(ScoreManager scoreManager)
        {
            _scoreManager = scoreManager;

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
        private  void BindGamerulesPage(object sender, EventArgs e)
        {
            RightSideContentView = new GamerulesView();
        }
        private async void NavigateToLeaderboardPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///leaderboardpage");
        }
        private  void BindCreditsPage(object sender, EventArgs e)
        {
            RightSideContentView = new CreditsPageView();
        }
        private void QuitButton_Clicked(object sender, EventArgs e)
        {
            _scoreManager.SaveScores();
            Application.Current?.Quit();
        }
    }

}
