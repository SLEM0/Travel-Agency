using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class EditHotel : ContentPage
{
    public ObservableCollection<Room> Rooms { get; set; }
    public Hotel MyHotel { get; set; }
    public string MCurort { get; set; }
    public string MName { get; set; }
    public string MCountry { get; set; }
    public string MDescription { get; set; }
    public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
    public EditHotel(Hotel hotel)
    {
        MName = hotel.Name;
        MCurort = hotel.Curort;
        MCountry = hotel.Country;
        MDescription = hotel.Description;
        MyHotel = hotel;
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
        MyHotel.RemoveRooms();
        Rooms = new(MyHotel.Rooms);
        OnPropertyChanged(nameof(Rooms));
    }
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        List<string> eat = [];
        if (UAI.IsChecked)
            eat.Add("UAI");
        if (AI.IsChecked)
            eat.Add("AI");
        if (FB.IsChecked)
            eat.Add("FB");
        if (HB.IsChecked)
            eat.Add("HB");
        if (BB.IsChecked)
            eat.Add("BB");
        if (RO.IsChecked)
            eat.Add("RO");
        string? categoryString;
        if (categoryPicker.SelectedItem != null)
            categoryString = categoryPicker.SelectedItem.ToString();
        else
            categoryString = null;
        if (categoryString != null)
        {
            MyHotel.UpdateInfo(Country.Text, Curort.Text, Int32.Parse(categoryString), Name.Text, Description.Text, eat);
            await Navigation.PopAsync();
        }
        else
        {
            // Обработка ситуации
        }
    }
    private async void Remove_Button_Clicked(object sender, EventArgs e)
    {
        MainPage.MyAgency.RemoveHotel(MyHotel);
        await Navigation.PopAsync();
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Room selectedRoom)
        {
            await Navigation.PushAsync(new EditRoom(selectedRoom));
        }
    }
    private async void Room_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddRoom(MyHotel));
    }
}