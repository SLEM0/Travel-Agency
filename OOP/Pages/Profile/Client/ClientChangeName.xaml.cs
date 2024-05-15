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
                _ = DisplayAlert("������", "�������� ������", "OK");
        }
        else if (Password.Text == null || Password.Text == "")
        {
            _ = DisplayAlert("��������", "����������� ������", "OK");
        }
        else if (FirstName.Text == null || FirstName.Text == "")
        {
            _ = DisplayAlert("��������", "����� �������� ������ ��������� ���� \"���\"", "OK");
        }
        else
        {
            _ = DisplayAlert("��������", "����� �������� ������ ��������� ���� \"�������\"", "OK");
        }
    }
}