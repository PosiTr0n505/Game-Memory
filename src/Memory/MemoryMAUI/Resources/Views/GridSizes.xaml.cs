using MemoryLib.Managers;
using MemoryLib.Models;
using System.Diagnostics;

namespace MemoryMAUI.Resources.Views;

public partial class GridSizes : ContentView
{
    private Button? _selectedButton;
    public event EventHandler<GridSize?>? GridSizeSelected;

    public IReadOnlyCollection<GridSize> Sizes { get; private init; } = [.. GridSizeManager.Values.Keys];

    public GridSizes()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public void OnGridSizeButtonClicked(object sender, EventArgs e)
    {
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