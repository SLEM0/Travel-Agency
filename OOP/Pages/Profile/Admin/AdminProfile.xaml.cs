using OOP.Entities;

namespace OOP;

public partial class AdminProfile : ContentPage
{
    private readonly AgencyEntry _agencyEntry;
    private readonly Agency _agency;
    private readonly IDbService _dbService;
    public AdminProfile(Agency agency, AgencyEntry agencyEntry, IDbService dbService)
	{
        _agency = agency;
        _agencyEntry = agencyEntry;
		InitializeComponent();
        _dbService = dbService;
	}
    private async void Clients_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientsList(_agencyEntry));
    }
    private async void Hotel_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HotelList(_agency, _dbService));
    }
    private async void Tours_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ToursList(_agency));
    }
    private async void Review_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReviewList(_agencyEntry, _agencyEntry.Reviews, true));
    }
    private void Logout_Button_Clicked(object sender, EventArgs e)
    {
        _agencyEntry.Logout();
        var tabBar = Shell.Current.FindByName<TabBar>("TabBarName");
        var tab1 = tabBar.Items[1];
        tab1.Items.Clear();
        tab1.Items.Add(new ShellContent { Content = new Profile(_agency, _agencyEntry, _dbService) });
        var tab2 = tabBar.Items[3];
        tab2.Items.Clear();
        tab2.Items.Add(new ShellContent { Content = new Profile(_agency, _agencyEntry, _dbService) });
    }
}