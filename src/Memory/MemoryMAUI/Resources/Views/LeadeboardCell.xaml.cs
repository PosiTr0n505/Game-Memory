namespace MemoryMAUI.Resources.Views;


using MemoryMAUI.Converters;
using System.Globalization;
using MemoryLib.Models;

public partial class LeadeboardCell : ContentView
{
    private readonly Score? score;

    private readonly GridSizeToString converter = new();

    public LeadeboardCell()
	{
		InitializeComponent();

        gridSizeLabel.Text = (string)converter.Convert(score!.GridSize, typeof(string), null, CultureInfo.CurrentCulture)!;
	}


}