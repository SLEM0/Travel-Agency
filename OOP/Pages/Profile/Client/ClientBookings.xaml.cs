using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class ClientBookings : ContentPage
{
	public ObservableCollection<Booking> Bookings { get; set; }
    readonly AgencyEntry _agencyEntry;
	public ClientBookings(AgencyEntry agencyEntry)
	{
        _agencyEntry = agencyEntry;
        if (_agencyEntry.CurrentUser is Client client)
		    Bookings = new(client.Bookings);
        else
            Bookings = [];
		BindingContext = this;
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (_agencyEntry.CurrentUser is Client client)
            Bookings = new(client.Bookings);
        OnPropertyChanged(nameof(Bookings));
    }

    private async void Remove_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Booking booking = (Booking)button.CommandParameter;
        if (_agencyEntry.CurrentUser is Client client)
        {
            client.RemoveBooking(booking);
            Bookings = new(client.Bookings);
        }
        
        OnPropertyChanged(nameof(Bookings));
		await Navigation.PopAsync();
    }
    private async void Review_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Booking booking = (Booking)button.CommandParameter;
        await Navigation.PushAsync(new AddReview(_agencyEntry, booking.Tour.Hotel));
    }
}