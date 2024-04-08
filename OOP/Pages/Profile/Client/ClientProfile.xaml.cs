using OOP.Pages.Profile;

namespace OOP;

public partial class ClientProfile : ContentPage
{
	public ClientProfile()
	{
		InitializeComponent();
	}
    private async void Settings_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Settings());
    }
    private async void Bookings_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientBookings());
    }
    private async void Review_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminReply());
    }
}