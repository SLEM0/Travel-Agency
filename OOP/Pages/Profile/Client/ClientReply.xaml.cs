using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Compatibility;
using OOP.Entities;

namespace OOP;

public partial class ClientReply : ContentPage
{
    public ObservableCollection<Review> Reviews { get; set; }
    //public ObservableCollection<Reply> Replies { get; set; }
    public ClientReply()
    {
        Reviews = new(MainPage.MyAgency.GetClientReviews(EntryPage.CurrentClient));
        BindingContext = this;
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (Reviews.Count > 0)
            Reviews[0] = new(EntryPage.CurrentClient, "HELOOOOOOOOOOOO", 2, MainPage.MyAgency.Tours[0]);
        OnPropertyChanged(nameof(Reviews));
    }

    private async void Reply_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Review review = (Review)button.CommandParameter;
        await Navigation.PushAsync(new AddReply(review));
    }
}