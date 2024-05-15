using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class HotelInfo : ContentPage
{
	public Hotel Hotel { get; set; }
	public ObservableCollection<Tour> Tours { get; set; }
    readonly int countPeaple;
    readonly AgencyEntry _agencyEntry;
    public ObservableCollection<Review> Reviews { get; set; }

    public HotelInfo(AgencyEntry agencyEntry, Hotel hotel, List<Tour> tours, int _countPeaple)
	{
        _agencyEntry = agencyEntry;
        countPeaple = _countPeaple;
        Hotel = hotel;
		Tours = new(tours);
		BindingContext = this;
        Reviews = new(agencyEntry.GetHotelReviews(hotel.ID));
        InitializeComponent();
	}
    private void Add_Booking_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Tour tour = (Tour)button.CommandParameter;
        if (_agencyEntry.CurrentUser is Client client)
        {
            client.AddBooking(tour, countPeaple);
            if (client.Bookings.Count == 1)
            {
                var tabBar = Shell.Current.FindByName<TabBar>("TabBarName");
                var tab = tabBar.Items[1];
                tab.Items.Clear();
                tab.Items.Add(new ShellContent { Content = new ClientBookings(_agencyEntry) });
            }
            _ = DisplayAlert("Вы успешно забронировали тур", $"Количество мест: {countPeaple}", "OK");
        }
        else
        {
            _ = DisplayAlert("Внимание", "Сначала войдите в аккаунт", "OK");
        }
    }
    private async void Reviews_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReviewList(_agencyEntry, _agencyEntry.GetHotelReviews(Hotel.ID), false));
    }
}