using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryMAUI.Resources.Views;

public partial class GridSizes : ContentView
{
    public IReadOnlyCollection<GridSize> Sizes { get; private init; } = [.. GridSizeManager.Values.Keys];

    public GridSizes()
    {
        InitializeComponent();
        BindingContext = this;
    }

}