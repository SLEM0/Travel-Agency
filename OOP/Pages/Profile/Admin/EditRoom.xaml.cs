using OOP.Entities;

namespace OOP;

public partial class EditRoom : ContentPage
{
	public Room MyRoom { get; set; }
    public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
    private readonly Hotel _hotel;
    public EditRoom(Hotel hotel, Room room)
	{
        MyRoom = room;
        _hotel = hotel;
		InitializeComponent();
		BindingContext = this;
        peaplePicker.SelectedItem = room.CountPeaple;
    }
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        string? peapleString;
        if (peaplePicker.SelectedItem != null)
            peapleString = peaplePicker.SelectedItem.ToString();
        else
            peapleString = null;
        if (peapleString != null && Name.Text != null && Name.Text != "")
        {
            MyRoom.UpdateInfo(Name.Text, Int32.Parse(peapleString));
            await Navigation.PopAsync();
        }
        else if (Name.Text == null || Name.Text == "")
        {
            _ = DisplayAlert("Внимание", "Заполните поле \"Название\"", "OK");
        }
        else
        {
            _ = DisplayAlert("Внимание", "Заполните поле \"Количество человек\"", "OK");
        }
    }
    private async void Remove_Button_Clicked(object sender, EventArgs e)
    {
        _hotel.RemoveRoom(MyRoom);
        //MyRoom.PrepareToRemove();
        await Navigation.PopAsync();
    }
}