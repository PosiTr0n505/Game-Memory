namespace MemoryMAUI.Resources.Views;


using System;
using System.Globalization;
using MemoryLib.Models;

public partial class LeadeboardCell : ContentView
{
	Score score1 = new(new Player("Test"), 50, GridSize.Size3);

    private IValueConverter converter = new GridSizeToString();

    public LeadeboardCell()
	{
		InitializeComponent();
		BindingContext = score1;
		gridSizeLabel = converter.Convert();
	}


}