using MemoryLib.Managers;
using MemoryLib.Models;
using System.Diagnostics;

namespace MemoryMAUI.Resources.Views;

public partial class GridSizes : ContentView
{
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
            GridSizeSelected?.Invoke(this, selectedSize);
        }
    }
}