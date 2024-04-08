using System.Collections.ObjectModel;
using OOP.Entities;

namespace OOP;

public partial class EditTour : ContentPage
{
    public List<Hotel> Hotels { get; set; } = MainPage.MyAgency.Hotels;
    public ObservableCollection<string> Eat { get; set; }
    public int MPlases { get; set; }
    public string MDeparture { get; set; }
    public Tour MyTour { get; set; }
    public ObservableCollection<Room> Rooms { get; set; }
    public EditTour(Tour tour)
    {
        MPlases = tour.AvailablePlaces;
        MDeparture = tour.Departure;
        MyTour = tour;
        Eat = new(tour.Hotel.Eat);
        Rooms = new(tour.Hotel.Rooms);
        InitializeComponent();
        BindingContext = this;
        hotelPicker.SelectedIndexChanged += (sender, e) =>
        {
            Rooms = new(MyTour.Hotel.Rooms);
            Eat = new(MyTour.Hotel.Eat);
            OnPropertyChanged(nameof(Rooms));
            OnPropertyChanged(nameof(Eat));
        };
    }
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        MyTour.UpdateInfo(MPlases, beginDate.Date, endDate.Date, MDeparture, eatPicker.SelectedItem.ToString());
        await Navigation.PopAsync();
    }
    private async void Remove_Button_Clicked(object sender, EventArgs e)
    {
        MainPage.MyAgency.RemoveTour(MyTour);
        await Navigation.PopAsync();
    }
}