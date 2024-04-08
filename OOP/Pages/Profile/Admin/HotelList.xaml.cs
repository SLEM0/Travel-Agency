using OOP.Entities;
using System.Collections.ObjectModel;
namespace OOP;

public partial class HotelList : ContentPage
{
    public ObservableCollection<Hotel> Hotels { get; set; }

    public HotelList()
    {
        InitializeComponent();
        Hotels = new(MainPage.MyAgency.Hotels);
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Hotels = new(MainPage.MyAgency.Hotels);
        OnPropertyChanged(nameof(Hotels));
    }
    private async void Add_Hotel_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddHotel());
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Hotel selectedHotel)
        {
            await Navigation.PushAsync(new EditHotel(selectedHotel));
        }
    }
}