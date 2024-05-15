using System.Collections.ObjectModel;
using OOP.Entities;

namespace OOP;

public partial class AddTour : ContentPage
{
    private readonly Agency _agency;
    public List<Hotel> Hotels { get; set; }
    public Hotel? MyHotel { get; set; }

    public ObservableCollection<Room>? Rooms { get; set; }
    public ObservableCollection<string>? Eat { get; set; } = ["UAI", "AI", "FB", "HB", "BB", "RO"];
    public AddTour(Agency agency)
    {
        _agency = agency;
        Hotels = _agency.Hotels;
        InitializeComponent();
        BindingContext = this;
        hotelPicker.SelectedIndexChanged += (sender, e) =>
        {
            if (MyHotel != null)
            {
                Rooms = new(MyHotel.Rooms);
                OnPropertyChanged(nameof(Rooms));
            }
            else
            {
                _ = DisplayAlert("Внимание", "Сначала заполните поле \"Отель\"", "OK");
            }
        };
    }
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        if (MyHotel != null && 
            eatPicker.SelectedItem != null &&
            roomPicker.SelectedItem != null &&
            int.TryParse(plases.Text, out int intPlases) &&
            double.TryParse(price.Text, out double doublePrice) &&
            departure.Text != null && departure.Text != "")
        {
            if (eatPicker.SelectedItem is string eat && roomPicker.SelectedItem is Room room)
            {
                _agency.AddTour(MyHotel, intPlases, beginDate.Date, endDate.Date, departure.Text, new(eat), room, doublePrice);
                await Navigation.PopAsync();
            }
        }
        else
        {
            if (MyHotel == null)
            {
                _ = DisplayAlert("Внимание", "Чтобы добавить тур заполните поле \"Отель\"", "OK");
            }
            else if (eatPicker.SelectedItem == null)
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
            else if (departure.Text == null || departure.Text != "")
            {
                _ = DisplayAlert("Внимание", "Чтобы добавить тур заполните поле \"Место отправления\"", "OK");
            }
            else
            {
                _ = DisplayAlert("Ошибка", "Введите корректное значение в поле \"Стоимость\"", "OK");
            }
        }
    }
}