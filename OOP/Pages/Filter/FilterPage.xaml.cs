using OOP.Entities;
using System.Collections.ObjectModel;
namespace OOP;

public partial class FilterPage : ContentPage
{
    readonly List<Tour> tours;
    public ObservableCollection<Hotel> Hotels { get; set; }
    public List<Tour>? hotelTours;
    readonly int countPeaple;
    private readonly AgencyEntry _agencyEntry;
    public FilterPage(AgencyEntry agencyEntry, List<Tour> _tours, int _countPeaple)
	{
        countPeaple = _countPeaple;
		tours = _tours;
        Hotels = new(Filter.GetHotelsByTours(_tours));
        _agencyEntry = agencyEntry;
        InitializeComponent();
        BindingContext = this;
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Hotel selectedHotel)
        {
            hotelTours = Filter.GetToursByHotel(tours, selectedHotel);
            await Navigation.PushAsync(new HotelInfo(_agencyEntry, selectedHotel, hotelTours, countPeaple));
        }
    }
}