using OOP.Entities;

namespace OOP;

public partial class Registration : ContentPage
{
    private readonly AgencyEntry _agencyEntry;
	public Registration(AgencyEntry agencyEntry)
	{
		InitializeComponent();
        _agencyEntry = agencyEntry;
	}
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        if (Password.Text != null && FirstName.Text != null && Email.Text != null && Password.Text != "" && FirstName.Text != "" && Email.Text != "")
        {
            _agencyEntry.Register(Password.Text, FirstName.Text, LastName.Text, Email.Text);
            await Navigation.PopAsync();
        }
        else if (Password.Text == null || Password.Text == "")
            _ = DisplayAlert("Внимание", "Заполните поле \"Пароль\"", "OK");
        else if (FirstName.Text == null || FirstName.Text == "")
            _ = DisplayAlert("Внимание", "Заполните поле \"Имя\"", "OK");
        else if (LastName.Text == null || LastName.Text == "")
            _ = DisplayAlert("Внимание", "Заполните поле \"Фамилия\"", "OK");
        else 
            _ = DisplayAlert("Внимание", "Заполните поле \"Email\"", "OK");
    }
}