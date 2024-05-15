using OOP.Entities;

namespace OOP;

public partial class ClientChangeName : ContentPage
{
    readonly AgencyEntry _agencyEntry;
	public ClientChangeName(AgencyEntry agencyEntry)
	{
        _agencyEntry = agencyEntry;
		InitializeComponent();
	}
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        if (Password.Text != null && FirstName.Text != null && LastName.Text != null && _agencyEntry.CurrentUser != null
            && Password.Text != "" && FirstName.Text != "" && LastName.Text != "")
        {
            if (_agencyEntry.CurrentUser.UpdateInfo(Password.Text, FirstName.Text, LastName.Text))
                await Navigation.PopAsync();
            else
                _ = DisplayAlert("Ошибка", "Неверный пароль", "OK");
        }
        else if (Password.Text == null || Password.Text == "")
        {
            _ = DisplayAlert("Внимание", "Подтвердите пароль", "OK");
        }
        else if (FirstName.Text == null || FirstName.Text == "")
        {
            _ = DisplayAlert("Внимание", "Чтобы изменить данные заполните поле \"Имя\"", "OK");
        }
        else
        {
            _ = DisplayAlert("Внимание", "Чтобы изменить данные заполните поле \"Фамилия\"", "OK");
        }
    }
}