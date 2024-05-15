using OOP.Entities;

namespace OOP;

public partial class ClientChangePassword : ContentPage
{
	readonly AgencyEntry _agencyEntry;
	public ClientChangePassword(AgencyEntry agencyEntry)
	{
		_agencyEntry = agencyEntry;
		InitializeComponent();
	}
	private async void Ok_Button_Clicked(object sender, EventArgs e)
	{
		if (Old.Text != null && New.Text != null && _agencyEntry.CurrentUser is Client client && Old.Text != "" && New.Text != "")
		{
			if (client.UpdatePassword(Old.Text, New.Text))
				await Navigation.PopAsync();
			else
                _ = DisplayAlert("Ошибка", "Неверный старый пароль", "OK");
        }
		else if (Old.Text == null || Old.Text == "")
		{
            _ = DisplayAlert("Внимание", "Заполните поле \"Старый пароль\"", "OK");
        }
		else
		{
            _ = DisplayAlert("Внимание", "Заполните поле \"Новый пароль\"", "OK");
        }
    }
}