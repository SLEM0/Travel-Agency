using OOP.Entities;

namespace OOP;

public partial class Profile : ContentPage
{
    private readonly AgencyEntry _agencyEntry;
    private readonly Agency _agency;
    private readonly IDbService _dbService;
    public Profile(Agency agency, AgencyEntry agencyEntry, IDbService dbService)
	{
		InitializeComponent();
        _agencyEntry = agencyEntry;
        _agency = agency;
        _dbService = dbService;
    }
    private async void OpenEntry_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EntryPage(_agency, _agencyEntry, _dbService));
    }
    private async void OpenRegistration_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Registration(_agencyEntry));
    }
}