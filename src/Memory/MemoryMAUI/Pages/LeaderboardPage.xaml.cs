using MemoryLib.Models;
using Persistence;

namespace MemoryMAUI.Pages;

public partial class LeaderboardPage : ContentPage
{
	private readonly ScoreManager leaderboard = new(new StubLoadManager(), new StubSaveManager());

	public List<Score> Scores {  get; private set; }

	public LeaderboardPage()
	{
		InitializeComponent();
		Scores = [.. leaderboard.Scores];
        BindingContext = this;
    }
}