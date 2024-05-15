using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class AddHotel : ContentPage
{
    private readonly Agency _agency;
    private readonly IDbService _dbService;
    Hotel? myHotel;
    public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
    public ObservableCollection<Room> Rooms { get; set; }
    public AddHotel(Agency agency, IDbService dbService)
    {
        _agency = agency;
        _dbService = dbService;
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
            Rooms = new(myHotel.Rooms);
        }
        else
            Rooms = [];
        OnPropertyChanged(nameof(Rooms));
    }
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        if (myHotel == null || myHotel.Rooms.Count == 0)
            _ = DisplayAlert("��������", "�������� ���� �� ���� �������", "OK");
        else
        {
            string? categoryString;
            if (categoryPicker.SelectedItem != null)
                categoryString = categoryPicker.SelectedItem.ToString();
            else
                categoryString = null;
            if (categoryString != null && Country.Text != null && Curort.Text != null && Name.Text != null && Description.Text != null
                && categoryString != "" && Country.Text != "" && Curort.Text != "" && Name.Text != "" && Description.Text != "")
            {
                myHotel.UpdateInfo(Country.Text, Curort.Text, Int32.Parse(categoryString), Name.Text, Description.Text);
                _agency.AddHotel(myHotel);
                await Navigation.PopAsync();
            }
            else if (Country.Text == null || Country.Text == "")
            {
                _ = DisplayAlert("��������", "����� �������� ����� ��������� ���� \"������\"", "OK");
            }
            else if (Curort.Text == null || Curort.Text == "")
            {
                _ = DisplayAlert("��������", "����� �������� ����� ��������� ���� \"������\"", "OK");
            }
            else if (Name.Text == null || Name.Text == "")
            {
                _ = DisplayAlert("��������", "����� �������� ����� ��������� ���� \"��������\"", "OK");
            }
            else if (Description.Text == null || Description.Text == "")
            {
                _ = DisplayAlert("��������", "����� �������� ����� ��������� ���� \"��������\"", "OK");
            }
            else
            {
                _ = DisplayAlert("��������", "����� �������� ����� ��������� ���� \"���������\"", "OK");
            }
        }
    }
    private async void Room_Button_Clicked(object sender, EventArgs e)
    {
        if (myHotel == null)
        {
            List<Room> rooms = [];
            string? categoryString;
            if (categoryPicker.SelectedItem != null)
                categoryString = categoryPicker.SelectedItem.ToString();
            else
                categoryString = null;
            if (categoryString != null && Country.Text != null && Curort.Text != null && Name.Text != null && Description.Text != null
                && categoryString != "" && Country.Text != "" && Curort.Text != "" && Name.Text != "" && Description.Text != "")
            {
                myHotel = new(_dbService, rooms, Country.Text, Curort.Text, Int32.Parse(categoryString), Name.Text, Description.Text);
            }
            else if (Country.Text == null || Country.Text == "")
            {
                _ = DisplayAlert("��������", "������� ��������� ���� \"������\"", "OK");
                return;
            }
            else if (Curort.Text == null || Curort.Text == "")
            {
                _ = DisplayAlert("��������", "������� ��������� ���� \"������\"", "OK");
                return;
            }
            else if (Name.Text == null || Name.Text == "")
            {
                _ = DisplayAlert("��������", "������� ��������� ���� \"��������\"", "OK");
                return;
            }
            else if (Description.Text == null || Description.Text == "")
            {
                _ = DisplayAlert("��������", "������� ��������� ���� \"��������\"", "OK");
                return;
            }
            else
            {
                _ = DisplayAlert("��������", "������� ��������� ���� \"���������\"", "OK");
                return;
            }
        }
        await Navigation.PushAsync(new AddRoom(myHotel));
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Room selectedRoom)
        {
            if (myHotel != null)
                await Navigation.PushAsync(new EditRoom(myHotel, selectedRoom));
        }
    }
}