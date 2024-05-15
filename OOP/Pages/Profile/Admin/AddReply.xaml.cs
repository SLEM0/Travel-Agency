using OOP.Entities;

namespace OOP;

public partial class AddReply : ContentPage
{
    readonly Review _review;
    readonly AgencyEntry _agencyEntry;
	public AddReply(AgencyEntry agencyEntry, Review review)
	{
        _agencyEntry = agencyEntry;
        _review = review;
		InitializeComponent();
	}
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        if (_review != null && Text.Text != null && Text.Text != "" && _agencyEntry.CurrentUser != null)
        {
            _review.AddReplyToReview(_agencyEntry.CurrentUser, Text.Text);
        }
        else
        {
            _ = DisplayAlert("Внимание", "Напишите ответ", "OK");
        }
        await Navigation.PopAsync();
    }
}