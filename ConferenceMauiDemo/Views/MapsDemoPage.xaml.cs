using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace ConferenceMauiDemo.Views;

public partial class MapsDemoPage : ContentPage
{
	public MapsDemoPage()
	{
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        Pin qualityBytesPin = new Pin
        {
            Location = new Location(50.5014483, 7.308297599999),
            Label = "Quality Bytes GmbH",
            Address = "Bad Breisig",
            Type = PinType.Place            
        };

        qualityBytesPin.MarkerClicked += OnMarkerClickedAsync;

        map.Pins.Add(qualityBytesPin);
        base.OnNavigatedTo(args);
    }

    async void OnMarkerClickedAsync(object sender, PinClickedEventArgs e)
    {
       // e.HideInfoWindow = true;
        string pinName = ((Pin)sender).Label;
        await DisplayAlert("Pin angeklickt", $"{pinName} wurde angeklickt.", "Ok");
    }

    void OnButtonClicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        switch (button.Text)
        {
            case "Straﬂe":
                map.MapType = MapType.Street;
                break;
            case "Satellit":
                map.MapType = MapType.Satellite;
                break;
            case "Hybrid":
                map.MapType = MapType.Hybrid;
                break;
        }
    }
}