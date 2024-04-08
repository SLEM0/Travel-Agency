using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP
{
    public partial class MainPage : ContentPage
    {
        public List<int> Lst30 { get; set; } = Enumerable.Range(1, 30).ToList();
        public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
        public List<string> Eat { get; set; } = ["UAI", "AI", "FB", "HB", "BB", "RO"];
        public static Agency MyAgency {  get; set; } = new Agency();
        public static AgencyEntry MyEntry { get; set; } = new AgencyEntry();
        public ObservableCollection<string>? Countries { get; set; }
        public ObservableCollection<string>? Curorts { get; set; }
        public ObservableCollection<string>? Departure {  get; set; }
        List<string>? CurrentDeparture;
        List<string>? CurrentCountries;
        List<string>? CurrentCurorts;
        List<string>? CurrentEat;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            BindingContext = this;
            base.OnAppearing();
            Countries = new(MyAgency.GetCountriesList());
            Curorts = new(MyAgency.GetCurortsList());
            Departure = new(MyAgency.GetDepartureList());
            OnPropertyChanged(nameof(Countries));
            OnPropertyChanged(nameof(Curorts));
            OnPropertyChanged(nameof(Departure));
            CurrentCountries = null;
            CurrentCurorts = null;
            CurrentDeparture = null;
        }

        private async void Ok_Button_Clicked(object sender, EventArgs e)
        {
            int countPeaple; string? countPeapleString;
            int minCategory; string? minCategoryString;
            int minNights; string? minNightsString;
            int maxNights; string? maxNightsString;
            if (people.SelectedItem != null)
                countPeapleString = people.SelectedItem.ToString();
            else
                countPeapleString = null;
            if (category.SelectedItem != null)
                minCategoryString = category.SelectedItem.ToString();
            else
                minCategoryString = null;
            if (MinNights.SelectedItem != null)
                minNightsString = MinNights.SelectedItem.ToString();
            else
                minNightsString = null;
            if (MaxNights.SelectedItem != null)
                maxNightsString = MaxNights.SelectedItem.ToString();
            else
                maxNightsString = null;
            if (countPeapleString != null)
            {
                countPeaple = Int32.Parse(countPeapleString);
                if (minCategoryString == null)
                    minCategory = 1;
                else
                    minCategory = Int32.Parse(minCategoryString);
                if (minNightsString == null)
                    minNights = 1;
                else
                    minNights = Int32.Parse(minNightsString);
                if (maxNightsString == null)
                    maxNights = 30;
                else
                    maxNights = Int32.Parse(maxNightsString);
                if (CurrentDeparture == null && Departure != null)
                    CurrentDeparture = new(Departure);
                if (CurrentCountries == null && Countries != null)
                    CurrentCountries = new(Countries);
                if (CurrentCurorts == null && Curorts != null)
                    CurrentCurorts = new(Curorts);
                if (CurrentEat == null && Eat != null)
                    CurrentEat = new(Eat);
                if (CurrentDeparture != null && CurrentCountries != null && CurrentCurorts != null && CurrentEat != null)
                {
                    List<Tour> tours = MyAgency.FindTour(
                                countPeaple,
                                CurrentDeparture,
                                CurrentCountries,
                                CurrentCurorts,
                                minCategory,
                                CurrentEat,
                                MinDate.Date,
                                MaxDate.Date,
                                minNights,
                                maxNights);
                    await Navigation.PushAsync(new FilterPage(tours, countPeaple));
                    CurrentCountries = null;
                    CurrentCurorts = null;
                    CurrentEat = null;
                    CurrentDeparture = null;
                }
            }
            else
            {
                // Обработка ситуации
            }
        }
        void OnCollectionViewSelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            CurrentDeparture = new List<string>(e.CurrentSelection.Select(item => item?.ToString() ?? string.Empty));
        }
        void OnCollectionViewSelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            CurrentCountries = new List<string>(e.CurrentSelection.Select(item => item?.ToString() ?? string.Empty));
        }
        void OnCollectionViewSelectionChanged3(object sender, SelectionChangedEventArgs e)
        {
            CurrentCurorts = new List<string>(e.CurrentSelection.Select(item => item?.ToString() ?? string.Empty));
        }
        void OnCollectionViewSelectionChanged4(object sender, SelectionChangedEventArgs e)
        {
            CurrentEat = new List<string>(e.CurrentSelection.Select(item => item?.ToString() ?? string.Empty));
        }
    }

}
