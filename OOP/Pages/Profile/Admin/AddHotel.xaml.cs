using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class AddHotel : ContentPage
{
    Hotel? myHotel;
    public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
    public ObservableCollection<Room> Rooms { get; set; }
    public AddHotel()
    {
        InitializeComponent();
        if (myHotel != null)
            Rooms = new(myHotel.Rooms);
        else
            Rooms = [];
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (myHotel != null)
        {
            myHotel.RemoveRooms();
            Rooms = new(myHotel.Rooms);
        }
        else
            Rooms = [];
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
            if (myHotel == null)
                myHotel = new([], Country.Text, Curort.Text, Int32.Parse(categoryString), Name.Text, Description.Text, eat);
            else
                myHotel.UpdateInfo(Country.Text, Curort.Text, Int32.Parse(categoryString), Name.Text, Description.Text, eat);
            MainPage.MyAgency.AddHotel(myHotel);
            await Navigation.PopAsync();
        }
        else
        {
            // Обработка ситуации
        }
    }
    private async void Room_Button_Clicked(object sender, EventArgs e)
    {
        if (myHotel == null)
        {
            List<Room> rooms = [];
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
                myHotel = new(rooms, Country.Text, Curort.Text, Int32.Parse(categoryString), Name.Text, Description.Text, eat);
            }
            else
            {
                // Обработка ситуации
                return;
            }
        }
        await Navigation.PushAsync(new AddRoom(myHotel));
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Room selectedRoom)
        {
            await Navigation.PushAsync(new EditRoom(selectedRoom));
        }
    }
}