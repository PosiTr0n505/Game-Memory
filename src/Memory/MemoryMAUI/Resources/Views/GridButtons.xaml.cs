using MemoryLib.Managers;
using MemoryLib.Models;
using MemoryMAUI.Converters;

namespace MemoryMAUI.Resources.Views;

public partial class GridButtons : ContentView
{
	GridSizeToString converter = new();

    public GridButtons()
	{
		InitializeComponent();
		BindingContext = this;
	}
}