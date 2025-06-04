namespace MemoryMAUI.Resources.Views;

public partial class SinglePlayerView : ContentView
{
	public SinglePlayerView()
	{
		InitializeComponent();
	}
    private async void OnClickedStartGame(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///singleplayergamepage");
    }
}