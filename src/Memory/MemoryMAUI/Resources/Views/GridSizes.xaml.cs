using MemoryLib.Managers;
using MemoryLib.Models;
using System.Diagnostics;

namespace MemoryMAUI.Resources.Views;

public partial class GridSizes : ContentView
{
    public event EventHandler<GridSize?> GridSizeSelected;
    public IReadOnlyCollection<GridSize> Sizes { get; private init; } = [.. GridSizeManager.Values.Keys];

    public static readonly BindableProperty SelectedGridSizeProperty =
        BindableProperty.Create(
            nameof(SelectedGridSize),
            typeof(GridSize),
            typeof(GridSizes),
            default(GridSize),
            BindingMode.TwoWay
        );

    public GridSize SelectedGridSize
    {
        get => (GridSize)GetValue(SelectedGridSizeProperty);
        set => SetValue(SelectedGridSizeProperty, value);
    }

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

    //public void OnGridSizeSelected(GridSize selected) => SelectedGridSize = selected;
}