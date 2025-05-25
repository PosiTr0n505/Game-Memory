using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryMAUI.Resources.Views;

public partial class GridButtons : ContentView
{
	public event EventHandler<GridSize?>? GridSizeSelected;

    public IReadOnlyCollection<GridSize> Sizes { get; private init; } = [.. GridSizeManager.Values.Keys];

    public GridButtons()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private void ButtonClicked(object sender, EventArgs e)
    {
        if (sender == ResetButton)
        {
            GridSizeSelected?.Invoke(this, null);
            return;
        }

        if (sender is Button button && button.BindingContext is GridSize selectedSize)
        {
            GridSizeSelected?.Invoke(this, selectedSize);
            return;
        }

    }
}