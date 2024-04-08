using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class ClientBookings : ContentPage
{
	public ObservableCollection<Booking> Bookings { get; set; }
	public ClientBookings()
	{
        if (EntryPage.CurrentClient != null)
		    Bookings = new(EntryPage.CurrentClient.Bookings);
        else
            Bookings = [];
		BindingContext = this;
		InitializeComponent();
	}

    private async void Pay_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Booking booking = (Booking)button.CommandParameter;
		booking.Pay();
		await Navigation.PopAsync();
    }
    private async void Review_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Booking booking = (Booking)button.CommandParameter;
        await Navigation.PushAsync(new AddReview(booking.Tour));
    }
}