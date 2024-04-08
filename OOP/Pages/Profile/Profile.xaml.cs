namespace OOP;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
        MainPage.MyEntry.LoginEvent += AdminEntry;
        MainPage.MyEntry.ClientLoginEvent += ClientEntry;
    }
    private async void OpenEntry_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EntryPage());
    }
    private async void OpenRegistration_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Registration());
    }
    public async void AdminEntry()
    {
        await Navigation.PushAsync(new AdminProfile());
    }
    public async void ClientEntry()
    {
        await Navigation.PushAsync(new ClientProfile());
    }
}