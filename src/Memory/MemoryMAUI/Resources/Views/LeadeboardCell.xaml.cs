namespace MemoryMAUI.Resources.Views;
using MemoryLib.Models;

public partial class LeadeboardCell : ContentView
{
	public static readonly BindableProperty NameTagProperty =
		BindableProperty.Create(nameof(Title), typeof(string), typeof(LeadeboardCell), string.Empty);
    public string Title
    {
        get => (string)GetValue(NameTagProperty);
        set => SetValue(NameTagProperty, value);
    }

    public static readonly BindableProperty MovesCountProperty =
        BindableProperty.Create(nameof(NumberOfMoves), typeof(int), typeof(LeadeboardCell), 0);

    public int NumberOfMoves
    {
        get => (int)GetValue(MovesCountProperty);
        set => SetValue(NameTagProperty, value);
    }

    public static readonly BindableProperty GridSizeProperty =
        BindableProperty.Create(nameof(GridSize), typeof(GridSize), typeof(LeadeboardCell), GridSize.Size1);

    public GridSize GridSize
    {
        get => (GridSize)GetValue(GridSizeProperty);
        set => SetValue(NameTagProperty, value);
    }

    public LeadeboardCell()
	{
		InitializeComponent();
	}
}