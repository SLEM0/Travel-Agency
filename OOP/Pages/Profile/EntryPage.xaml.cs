using OOP.Entities;

namespace OOP;

public partial class EntryPage : ContentPage
{
    public static Client? CurrentClient {  get; set; }
	public EntryPage()
	{
		InitializeComponent();
	}
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        CurrentClient = MainPage.MyEntry.Login(Email.Text, Password.Text);
    }
}