using System.Collections.ObjectModel;
using OOP.Entities;

namespace OOP;

public partial class ToursList : ContentPage
{
    private readonly Agency _agency;
    public ObservableCollection<Tour> Tours { get; set; }

    public ToursList(Agency agency)
    {
        _agency = agency;
        InitializeComponent();
        Tours = new(_agency.Tours);
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Tours = new(_agency.Tours);
        OnPropertyChanged(nameof(Tours));
    }
    private async void Add_Tour_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTour(_agency));
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Tour selectedTour)
        {
            await Navigation.PushAsync(new EditTour(_agency,selectedTour));
        }
    }
}