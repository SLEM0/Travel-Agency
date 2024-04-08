using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class TourInfo : ContentPage
{
	public Tour Tour { get; set; }
    readonly int countPeaple;
	public TourInfo(Tour tour, int _countPeaple)
	{
		countPeaple = _countPeaple;
		Tour = tour;
		BindingContext = this;
		InitializeComponent();
	}

    private async void Add_Booking_Button_Clicked(object sender, EventArgs e)
    {
        if (EntryPage.CurrentClient != null)
			EntryPage.CurrentClient.AddBooking(Tour, countPeaple);
		else
		{
            // Обработка ситуации
        }
        await Navigation.PopAsync();
    }
}