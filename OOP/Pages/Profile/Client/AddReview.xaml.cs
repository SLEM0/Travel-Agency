using OOP.Entities;

namespace OOP;

public partial class AddReview : ContentPage
{
    readonly Tour tour;
    public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
    public AddReview(Tour _tour)
	{
		tour = _tour;
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
        if (ratingString != null)
        {
            if (EntryPage.CurrentClient != null)
			tour.AddReview(EntryPage.CurrentClient, Text.Text, Int32.Parse(ratingString));
		await Navigation.PopAsync();
        }
        else
        {
            // Обработка ситуации
        }
    }
}