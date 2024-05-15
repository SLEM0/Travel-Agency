using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class EditHotel : ContentPage
{
    private readonly Agency _agency;
    public ObservableCollection<Room> Rooms { get; set; }
    public Hotel MyHotel { get; set; }
    public string MCurort { get; set; }
    public string MName { get; set; }
    public string MCountry { get; set; }
    public string MDescription { get; set; }
    public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
    public EditHotel(Agency agency, Hotel hotel)
    {
        _agency = agency;
        MName = hotel.Name;
        MCurort = hotel.Curort;
        MCountry = hotel.Country;
        MDescription = hotel.Description;
        MyHotel = hotel;
        Rooms = new(MyHotel.Rooms);
        InitializeComponent();
        BindingContext = this;
        categoryPicker.SelectedItem = hotel.Category;
    }
    protected override void OnAppearing()
    {
        MCurort = MyHotel.Curort;
        MName = MyHotel.Name;
        MCountry = MyHotel.Country;
        MDescription = MyHotel.Description;
        BindingContext = this;
        base.OnAppearing();
        Rooms = new(MyHotel.Rooms);
        OnPropertyChanged(nameof(Rooms));
    }
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        string? categoryString;
        if (categoryPicker.SelectedItem != null)
            categoryString = categoryPicker.SelectedItem.ToString();
        else
            categoryString = null;
        if (categoryString != null && Country.Text != null && Curort.Text != null && Name.Text != null && Description.Text != null && MyHotel.Rooms.Count > 0
            && Country.Text != "" && Curort.Text != "" && Name.Text != "" && Description.Text != "")
        {
            MyHotel.UpdateInfo(Country.Text, Curort.Text, Int32.Parse(categoryString), Name.Text, Description.Text);
            await Navigation.PopAsync();
        }
        else if (Country.Text == null || Country.Text == "")
        {
            _ = DisplayAlert("Внимание", "Чтобы добавить отель заполните поле \"Страна\"", "OK");
            return;
        }
        else if (Curort.Text == null || Curort.Text == "")
        {
            _ = DisplayAlert("Внимание", "Чтобы добавить отель заполните поле \"Курорт\"", "OK");
            return;
        }
        else if (Name.Text == null || Name.Text == "")
        {
            _ = DisplayAlert("Внимание", "Чтобы добавить отель заполните поле \"Название\"", "OK");
            return;
        }
        else if (Description.Text == null || Description.Text == "")
        {
            _ = DisplayAlert("Внимание", "Чтобы добавить отель заполните поле \"Описание\"", "OK");
            return;
        }
        else if (MyHotel.Rooms.Count == 0)
        {
            _ = DisplayAlert("Внимание", "Добавьте хотя бы одну комнату", "OK");
        }
        else
        {
            _ = DisplayAlert("Внимание", "Заполните поле \"Категория\"", "OK");
        }
    }
    private async void Remove_Button_Clicked(object sender, EventArgs e)
    {
        _agency.RemoveHotel(MyHotel);
        await Navigation.PopAsync();
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Room selectedRoom)
        {
            await Navigation.PushAsync(new EditRoom(MyHotel, selectedRoom));
        }
    }
    private async void Room_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddRoom(MyHotel));
    }
}