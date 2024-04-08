using System.Collections.ObjectModel;
using OOP.Entities;

namespace OOP;

public partial class ToursList : ContentPage
{
    public ObservableCollection<Tour> Tours { get; set; }

    public ToursList()
    {
        InitializeComponent();
        Tours = new(MainPage.MyAgency.Tours);
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Tours = new(MainPage.MyAgency.Tours);
        OnPropertyChanged(nameof(Tours));
    }
    private async void Add_Tour_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTour());
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Tour selectedTour)
        {
            await Navigation.PushAsync(new EditTour(selectedTour));
        }
    }
}