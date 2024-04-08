namespace OOP;

public partial class AdminProfile : ContentPage
{
	public AdminProfile()
	{
		InitializeComponent();
	}
    private async void Clients_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientsList());
    }
    private async void Hotel_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HotelList());
    }
    private async void Tours_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ToursList());
    }
    private async void Review_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminReply());
    }
}