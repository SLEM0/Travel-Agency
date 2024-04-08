using OOP.Entities;

namespace OOP;

public partial class AddReply : ContentPage
{
    readonly Review review;
	public AddReply(Review _review)
	{
        review = _review;
		InitializeComponent();
	}
    private async void Ok_Button_Clicked(object sender, EventArgs e)
    {
        if (review != null)
        {
            if (EntryPage.CurrentClient == null)
                review.AddAdminReplyToReview(Text.Text);
            else
                review.AddReplyToReview(Text.Text);
        }
        await Navigation.PopAsync();
    }
}