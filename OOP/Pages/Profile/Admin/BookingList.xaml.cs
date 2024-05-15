using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class BookingList : ContentPage
{
    public ObservableCollection<Booking> Bookings { get; set; }
    readonly AgencyEntry _agencyEntry;
	public BookingList(AgencyEntry agencyEntry)
	{
        _agencyEntry = agencyEntry;
        BindingContext = this;
        Bookings = new(agencyEntry.AllBooking());
        InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Bookings = new(_agencyEntry.AllBooking());
        OnPropertyChanged(nameof(Bookings));
    }
    private void Change_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Booking booking = (Booking)button.CommandParameter;
        booking.ChangeStatus();
        OnAppearing();
    }
}