namespace OOP.Pages.Profile.Client;

public partial class ClientChangeName : ContentPage
{
	public ClientChangeName()
	{
		InitializeComponent();
	}
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        EntryPage.CurrentClient?.UpdateInfo(Password.Text, FirstName.Text, LastName.Text);
        await Navigation.PopAsync();
    }
}