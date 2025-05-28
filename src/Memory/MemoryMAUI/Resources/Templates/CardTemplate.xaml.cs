namespace MemoryMAUI.Resources.Templates;
using MemoryLib.Models;

public partial class CardTemplate : ResourceDictionary
{
	public CardTemplate()
	{
		InitializeComponent();
	}

    private void CardClicked(object sender, TappedEventArgs e)
    {
		if (sender is not null && sender is Grid grid && grid.BindingContext is Card card)
		{ 
			card.Flip();
			foreach (var element in grid.Children)
			{
				if (element is Label label)
				{
					label.Opacity = (label.Opacity == 0) ? 1 : 0;
				}
			}
		}

		
    }
}