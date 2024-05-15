using OOP.Entities;

namespace OOP;

public partial class Settings : ContentPage
{
    readonly AgencyEntry _agencyEntry;
	public Settings(AgencyEntry agencyEntry)
	{
        _agencyEntry = agencyEntry;
		InitializeComponent();
	}
    private async void Name_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientChangeName(_agencyEntry));
    }
    private async void Password_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientChangePassword(_agencyEntry));
    }
}