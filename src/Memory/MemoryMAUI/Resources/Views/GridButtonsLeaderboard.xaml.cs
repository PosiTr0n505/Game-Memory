using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryMAUI.Resources.Views;

public partial class GridButtons : ContentView
{
    private Button? _selectedButton;

    public delegate void GridSizeSelectedEventHandler(object? sender, GridSize? gridSize);

    public event GridSizeSelectedEventHandler? GridSizeSelected;

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
            if (_selectedButton != null)
            {
                var primaryColor = (Color)Application.Current.Resources["PrimaryDark"];
                _selectedButton.BackgroundColor = primaryColor;
            }
            button.BackgroundColor = Colors.DarkGreen;
            _selectedButton = button;
            GridSizeSelected?.Invoke(this, selectedSize);
        }

    }
}