namespace MemoryMAUI.Pages;

public partial class CreditsPage : ContentPage
{
	public CreditsPage()
	{
		InitializeComponent();
	}
    private async void NavigateToMainpage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///mainpage");
    }
}