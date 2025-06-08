namespace MemoryMAUI.Resources.Templates;
using MemoryLib.Models;

public partial class CardTemplate : ResourceDictionary
{
	public delegate void CardClicked(View sender, Card card);
	public static event CardClicked? OnCardClicked;

    public CardTemplate()
	{
		InitializeComponent();
	}

    private static void GridCardClicked(object sender, TappedEventArgs e)
    {
        if (sender is ContentView view && view.BindingContext is Card card)
        {
            OnCardClicked?.Invoke(view, card);
        }
    }
}