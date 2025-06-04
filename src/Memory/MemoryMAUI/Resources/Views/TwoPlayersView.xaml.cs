namespace MemoryMAUI.Resources.Views;

public partial class TwoPlayersView : ContentView
{
	public TwoPlayersView()
	{
		InitializeComponent();
	}
    private async void OnClickedStartGame(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///twoplayersgamepage");
    }
}