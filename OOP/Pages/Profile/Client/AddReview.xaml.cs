using OOP.Entities;

namespace OOP;

public partial class AddReview : ContentPage
{
    readonly Hotel _hotel;
    readonly AgencyEntry _agencyEntry;
    public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
    public AddReview(AgencyEntry agencyEntry, Hotel hotel)
	{
        _agencyEntry = agencyEntry;
		_hotel = hotel;
		InitializeComponent();
        BindingContext = this;
    }

    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        string? ratingString;
        if (ratingPicker.SelectedItem != null)
            ratingString = ratingPicker.SelectedItem.ToString();
        else
            ratingString = null;
        if (ratingString != null && Text.Text != null && Text.Text != "")
        {
            if (_agencyEntry.CurrentUser is Client client)
                _agencyEntry.AddReview(client, _hotel.ID, Text.Text, Int32.Parse(ratingString));
		    await Navigation.PopAsync();
        }
        else if (Text.Text == null || Text.Text == "")
        {
            _ = DisplayAlert("Внимание", "Напишите отзыв", "OK");
        }
        else
        {
            _ = DisplayAlert("Внимание", "Чтобы добавить отзыв оцените тур", "OK");
        }
    }
}