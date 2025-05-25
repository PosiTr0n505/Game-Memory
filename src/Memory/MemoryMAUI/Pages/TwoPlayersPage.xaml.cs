namespace MemoryMAUI.Pages;

public partial class TwoPlayersPage : ContentPage
{
	public TwoPlayersPage()
	{
		InitializeComponent();
	}
    private async void NavigateToMainpage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///mainpage");
    }
    private async void OnClickedStartGame(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///twoplayersgamepage");
    }
}
