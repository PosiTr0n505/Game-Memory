namespace MemoryMAUI.Resources.Templates;
using MemoryLib.Models;

public partial class CardTemplate : ResourceDictionary
{
	public delegate void CardClicked(Grid sender, Card card);
	public static event CardClicked? OnCardClicked;

    public double LabelOpacity;

    public CardTemplate()
	{
		InitializeComponent();
	}

    private static void GridCardClicked(object sender, TappedEventArgs e)
    {
        if (sender is not null && sender is Grid grid && grid.BindingContext is Card card)
        {
            OnCardClicked?.Invoke(grid, card);
        }
    }
}