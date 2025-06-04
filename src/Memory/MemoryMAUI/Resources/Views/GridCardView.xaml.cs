namespace MemoryMAUI.Resources.Views;
using MemoryLib.Models;

public partial class GridCardView : ContentView
{
    private double _labelFontSize;
    public double LabelFontSize
    {
        get => _labelFontSize;
        set
        {
            _labelFontSize = value;
            OnPropertyChanged();
        }
    }

    private double _labelOpacity = 0;

    public double LabelOpacity 
	{
		get => _labelOpacity;

        set 
		{
			_labelOpacity = value;
			OnPropertyChanged();
        }
	}

    public GridCardView()
	{
		InitializeComponent();
        SizeChanged += (_,_) => LabelFontSize = Width * 0.4;
    }

    private void OnCardVisibilityChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(Card.IsVisible))
            if (sender is Card card)
                LabelOpacity = (card.IsVisible || card.IsFound) ? 1 : 0;
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (BindingContext is Card card)
        {
            card.PropertyChanged += OnCardVisibilityChanged;

            LabelOpacity = (card.IsVisible || card.IsFound) ? 1 : 0;
        }

    }

}