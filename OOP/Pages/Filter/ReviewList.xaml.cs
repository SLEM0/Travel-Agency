using System.Collections.ObjectModel;
using OOP.Entities;

namespace OOP;
public partial class ReviewList : ContentPage
{
    readonly AgencyEntry _agencyEntry;
    public ObservableCollection<Review> Reviews { get; set; }
    readonly bool _isCLient;
    public ReviewList(AgencyEntry agencyEntry, List<Review> reviews, bool isClient)
	{
        _agencyEntry = agencyEntry;
        _isCLient = isClient;
        Reviews = new(reviews);
        BindingContext = this;
        InitializeComponent();

	}
    private void OnExpandClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        var review = (Review)button.BindingContext;
        HorizontalStackLayout horizontalStackLayout = (HorizontalStackLayout)button.Parent;
        StackLayout stackLayout = (StackLayout)horizontalStackLayout.Parent;
        Label commentLabel = (Label)stackLayout.FindByName("commentLabel");
        if (review.Text != commentLabel.Text)
        {
            commentLabel.Text = review.Text;
            button.Text = "Свернуть";
        }
        else
        {
            commentLabel.Text = review.Text[..130];
            button.Text = "Развернуть";
        }
    }

    private async void Reply_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Review review = (Review)button.CommandParameter;
        if (_isCLient)
            await Navigation.PushAsync(new ClientReplyList(_agencyEntry, review));
        else
        {
            if (review.Reply.Count == 0)
                await Navigation.PushAsync(new Nothing("На этот отзыв пока нет ответов", "", "sms.png"));
            else
                await Navigation.PushAsync(new ReplyList(review));
        }
    }
}