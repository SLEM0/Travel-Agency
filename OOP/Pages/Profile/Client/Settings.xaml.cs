using OOP.Pages.Profile.Client;

namespace OOP.Pages.Profile;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
	}
    private async void Name_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientChangeName());
    }
    private async void Password_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientChangePassword());
    }
}