using OOP.Entities;

namespace OOP;

public partial class EditRoom : ContentPage
{
	public Room MyRoom { get; set; }
    public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
    public EditRoom(Room room)
	{
        MyRoom = room;
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
        if (peapleString != null)
        {
            MyRoom.UpdateInfo(Name.Text, Int32.Parse(peapleString));
            await Navigation.PopAsync();
        }
        else
        {
            // Обработка ситуации
        }
    }
    private async void Remove_Button_Clicked(object sender, EventArgs e)
    {
        MyRoom.PrepareToRemove();
        await Navigation.PopAsync();
    }
}