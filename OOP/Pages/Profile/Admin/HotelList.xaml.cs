using OOP.Entities;
using System.Collections.ObjectModel;
namespace OOP;

public partial class HotelList : ContentPage
{
    private readonly Agency _agency;
    private readonly IDbService _dbService;
    public ObservableCollection<Hotel> Hotels { get; set; }

    public HotelList(Agency agency, IDbService dbService)
    {
        _agency = agency;
        _dbService = dbService;
        InitializeComponent();
        Hotels = new(_agency.Hotels);
        BindingContext = this;
        _dbService = dbService;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Hotels = new(_agency.Hotels);
        OnPropertyChanged(nameof(Hotels));
    }
    private async void Add_Hotel_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddHotel(_agency, _dbService));
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Hotel selectedHotel)
        {
            await Navigation.PushAsync(new EditHotel(_agency, selectedHotel));
        }
    }
}