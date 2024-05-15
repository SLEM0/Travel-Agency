using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class ClientReplyList : ContentPage
{
    readonly AgencyEntry _agencyEntry;
    public Review Review { get; set; }
    public ObservableCollection<Reply> Replies { get; set; }
    public ClientReplyList(AgencyEntry agencyEntry, Review review)
    {
        _agencyEntry = agencyEntry;
        BindingContext = this;
        Review = review;
        Replies = new(review.Reply);
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Replies = new(Review.Reply);
        OnPropertyChanged(nameof(Replies));
    }
    private void OnExpandClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        var reply = (Reply)button.BindingContext;
        StackLayout stackLayout = (StackLayout)button.Parent;
        Label commentLabel = (Label)stackLayout.FindByName("commentLabel");
        if (reply.Text != commentLabel.Text)
        {
            commentLabel.Text = reply.Text;
            button.Text = "Свернуть";
        }
        else
        {
            commentLabel.Text = reply.Text[..130];
            button.Text = "Развернуть";
        }
    }
    private async void Reply_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddReply(_agencyEntry, Review));
    }
}