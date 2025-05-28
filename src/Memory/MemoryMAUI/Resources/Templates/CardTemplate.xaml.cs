namespace MemoryMAUI.Resources.Templates;
using MemoryLib.Models;

public partial class CardTemplate : ResourceDictionary
{
	public delegate void CardClicked(Card card);
	public static event CardClicked? OnCardClicked;

	public CardTemplate()
	{
		InitializeComponent();
	}

    private static void GridCardClicked(object sender, TappedEventArgs e)
    {
        if (sender is not null && sender is Grid grid && grid.BindingContext is Card card)
        {
            OnCardClicked?.Invoke(card);
            /*card.Flip();
            foreach (var element in grid.Children)
            {
                if (element is Label label)
                {
                    label.Opacity = (label.Opacity == 0) ? 1 : 0;
                }
            }*/
        }
    }
}