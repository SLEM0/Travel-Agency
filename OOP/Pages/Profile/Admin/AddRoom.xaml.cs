using OOP.Entities;
namespace OOP;

public partial class AddRoom : ContentPage
{
    readonly Hotel myHotel;
    public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
    public AddRoom(Hotel hotel)
	{
		InitializeComponent();
        myHotel = hotel;
        BindingContext = this;
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
            myHotel.AddRoom(Name.Text, Int32.Parse(peapleString));
            await Navigation.PopAsync();
        }
        else if (Name.Text == null || Name.Text == "")
        {
            _ = DisplayAlert("Внимание", "Чтобы добавить комнату заполните поле \"Название\"", "OK");
        }
        else
        {
            _ = DisplayAlert("Внимание", "Чтобы добавить комнату заполните поле \"Количество человек\"", "OK");
        }
    }
}