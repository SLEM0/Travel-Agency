using OOP.Entities;

namespace OOP;

public partial class Registration : ContentPage
{
	public Registration()
	{
		InitializeComponent();
	}
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        MainPage.MyEntry.Register(Password.Text, FirstName.Text, LastName.Text, Email.Text);
    }
}