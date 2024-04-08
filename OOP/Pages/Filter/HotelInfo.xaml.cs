using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class HotelInfo : ContentPage
{
	public Hotel Hotel { get; set; }
	public ObservableCollection<Tour> Tours { get; set; }
    readonly int countPeaple;

    public HotelInfo(Hotel hotel, List<Tour> tours, int _countPeaple)
	{
        countPeaple = _countPeaple;
        Hotel = hotel;
		Tours = new(tours);
		BindingContext = this;
        InitializeComponent();
	}
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Tour selectedTour)
        {
            await Navigation.PushAsync(new TourInfo(selectedTour, countPeaple));
        }
    }
}