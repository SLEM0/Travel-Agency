namespace OOP.Pages.Profile.Client;

public partial class ClientChangePassword : ContentPage
{
	public ClientChangePassword()
	{
		InitializeComponent();
	}
	private async void Ok_Button_Clicked(object sender, EventArgs e)
	{
        EntryPage.CurrentClient?.UpdatePassword(Old.Text, New.Text);
        await Navigation.PopAsync();
    }
}