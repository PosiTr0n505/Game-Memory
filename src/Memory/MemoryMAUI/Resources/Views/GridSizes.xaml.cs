using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryMAUI.Resources.Views;

public partial class GridSizes : ContentView
{
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

    public void OnGridSizeSelected(GridSize selected) => SelectedGridSize = selected;
}