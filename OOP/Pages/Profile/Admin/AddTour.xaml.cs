using System.Collections.ObjectModel;
using OOP.Entities;

namespace OOP;

public partial class AddTour : ContentPage
{
    public List<Hotel> Hotels { get; set; } = MainPage.MyAgency.Hotels;
    public Hotel? MyHotel { get; set; }
    public ObservableCollection<Room>? Rooms { get; set; }
    public ObservableCollection<string>? Eat { get; set; }
    public AddTour()
    {
        InitializeComponent();
        BindingContext = this;
        hotelPicker.SelectedIndexChanged += (sender, e) =>
        {
            if (MyHotel != null)
            {
                Rooms = new(MyHotel.Rooms);
                Eat = new(MyHotel.Eat);
                OnPropertyChanged(nameof(Rooms));
                OnPropertyChanged(nameof(Eat));
            }
            else
            {
                // Обработка ситуации
            }
        };
    }
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        if (MyHotel != null && eatPicker.SelectedItem != null && roomPicker.SelectedItem != null)
        {
            if (eatPicker.SelectedItem is string eat && roomPicker.SelectedItem is Room room)
            {
                MainPage.MyAgency.AddTour(MyHotel, Int32.Parse(plases.Text), beginDate.Date, endDate.Date, departure.Text, eat, room);
                await Navigation.PopAsync();
            }
        }
        else
        {
            // Обработка ситуации
        }
    }
}