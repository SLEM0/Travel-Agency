using OOP.Entities;

namespace OOP;

public partial class ClientProfile : ContentPage
{
    private readonly AgencyEntry _agencyEntry;
    private readonly Agency _agency;
    private readonly IDbService _dbService;
    public ClientProfile(Agency agency, AgencyEntry agencyEntry, IDbService dbService)
	{
        _agency = agency;
        _agencyEntry = agencyEntry;
        _dbService = dbService;
		InitializeComponent();
	}
    private async void Settings_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Settings(_agencyEntry));
    }
    private async void Review_Button_Clicked(object sender, EventArgs e)
    {
        if (_agencyEntry.GetUserReviews().Count == 0)
            await Navigation.PushAsync(new Nothing("Вы пока не оставляли отзывов", "вы можете написать отзыв после оформления заказа", "sms.png"));
        else
            await Navigation.PushAsync(new ReviewList(_agencyEntry, _agencyEntry.GetUserReviews(), true));
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