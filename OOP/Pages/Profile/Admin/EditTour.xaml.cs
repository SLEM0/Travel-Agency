using System.Collections.ObjectModel;
using OOP.Entities;

namespace OOP;

public partial class EditTour : ContentPage
{
    private readonly Agency _agency;
    public List<Hotel> Hotels { get; set; }
    public ObservableCollection<string> Eat { get; set; } = ["UAI", "AI", "FB", "HB", "BB", "RO"];
    public int MPlases { get; set; }
    public double MPrice { get; set; }
    public string MDeparture { get; set; }
    public Tour MyTour { get; set; }
    public ObservableCollection<Room> Rooms { get; set; }
    public EditTour(Agency agency, Tour tour)
    {
        _agency = agency;
        MPlases = tour.AvailablePlaces;
        MDeparture = tour.Departure;
        MyTour = tour;
        MPrice = tour.Price;
        Rooms = new(tour.Hotel.Rooms);
        Hotels = _agency.Hotels;
        InitializeComponent();
        BindingContext = this;
        hotelPicker.SelectedIndexChanged += (sender, e) =>
        {
            Rooms = new(MyTour.Hotel.Rooms);
            OnPropertyChanged(nameof(Rooms));
        };
    }
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        if (eatPicker.SelectedItem != null &&
            roomPicker.SelectedItem != null && 
            int.TryParse(plases.Text, out int intPlases) && 
            double.TryParse(price.Text, out double doublePrice) &&
            departure.Text != null && departure.Text != "")
        {
            if (eatPicker.SelectedItem is string eat && roomPicker.SelectedItem is Room room)
            {
                MyTour.UpdateInfo(intPlases, beginDate.Date, endDate.Date, MDeparture, new(eat), doublePrice, room);
                await Navigation.PopAsync();
            }
        }
        else
        {
            if (eatPicker.SelectedItem == null)
            {
                _ = DisplayAlert("Внимание", "Чтобы добавить тур заполните поле \"Питание\"", "OK");
            }
            else if (roomPicker.SelectedItem == null)
            {
                _ = DisplayAlert("Внимание", "Чтобы добавить тур заполните поле \"Комната\"", "OK");
            }
            else if (!int.TryParse(plases.Text, out int _))
            {
                _ = DisplayAlert("Ошибка", "Введите корректное значение в поле \"Количество мест\"", "OK");
            }
            else if (departure.Text == null || departure.Text == "")
            {
                _ = DisplayAlert("Внимание", "Чтобы добавить тур заполните поле \"Место отправления\"", "OK");
            }
            else
            {
                _ = DisplayAlert("Ошибка", "Введите корректное значение в поле \"Стоимость\"", "OK");
            }
        }
    }
    private async void Remove_Button_Clicked(object sender, EventArgs e)
    {
        _agency.RemoveTour(MyTour);
        await Navigation.PopAsync();
    }
}