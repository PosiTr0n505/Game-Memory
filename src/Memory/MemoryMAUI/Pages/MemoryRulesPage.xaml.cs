namespace MemoryMAUI.Pages;

public partial class MemoryRulesPage : ContentPage
{
	public MemoryRulesPage()
	{
		InitializeComponent();
	}
    private async void NavigateToMainpage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///mainpage");
    }
}