using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP
{
    public partial class MainPage : ContentPage
    {
        private readonly Agency _agency;
        private readonly AgencyEntry _agencyEntry;
        public List<int> Lst30 { get; set; } = Enumerable.Range(1, 30).ToList();
        public List<int> Lst5 { get; set; } = Enumerable.Range(1, 5).ToList();
        public List<string> Eat { get; set; } = ["UAI", "AI", "FB", "HB", "BB", "RO"];
        public ObservableCollection<string>? Countries { get; set; }
        public ObservableCollection<string>? Curorts { get; set; }
        public ObservableCollection<string>? Departure {  get; set; }
        List<string>? CurrentDeparture;
        List<string>? CurrentCountries;
        List<string>? CurrentCurorts;
        List<string>? CurrentEat;

        public MainPage(AgencyEntry agencyEntry, Agency agency)
        {
            _agency = agency;
            _agencyEntry = agencyEntry;
            InitializeComponent();
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            BindingContext = this;
            base.OnAppearing();
            Countries = new(_agency.GetCountriesList());
            Curorts = new(_agency.GetCurortsList());
            Departure = new(_agency.GetDepartureList());
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
            double maxPrice; string? maxPriceString;
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
            if (MaxPrice.Text != null)
                maxPriceString = MaxPrice.Text;
            else
                maxPriceString = null;
            if (maxPriceString == null || maxPriceString == "")
                maxPriceString = _agency.MaxPrice().ToString();
            if (countPeapleString != null && double.TryParse(maxPriceString, out double _))
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
                if (maxPriceString == null)
                    maxPrice = _agency.Tours.Max(tour => tour.Price);
                else
                    maxPrice = Double.Parse(maxPriceString);
                if ((CurrentDeparture == null || CurrentDeparture.Count == 0) && Departure != null)
                    CurrentDeparture = new(Departure);
                if ((CurrentCountries == null || CurrentCountries.Count == 0) && Countries != null)
                    CurrentCountries = new(Countries);
                if ((CurrentCurorts == null || CurrentCurorts.Count == 0) && Curorts != null)
                    CurrentCurorts = new(Curorts);
                if ((CurrentEat == null || CurrentEat.Count == 0) && Eat != null)
                    CurrentEat = new(Eat);
                if (CurrentDeparture != null && CurrentCountries != null && CurrentCurorts != null && CurrentEat != null)
                {
                    List<Tour> tours = _agency.FindTour(
                                countPeaple,
                                CurrentDeparture,
                                CurrentCountries,
                                CurrentCurorts,
                                minCategory,
                                CurrentEat,
                                MinDate.Date,
                                MaxDate.Date,
                                minNights,
                                maxNights,
                                maxPrice);
                    if (tours.Count == 0)
                        await Navigation.PushAsync(new Nothing("По вашему запросу ничего не найдено",
                            "попробуйте изменить критерии поиска и мы найдем подходящие туры", "nopalm.png"));
                    else
                        await Navigation.PushAsync(new FilterPage(_agencyEntry, tours, countPeaple));
                    CurrentCountries = null;
                    CurrentCurorts = null;
                    CurrentEat = null;
                    CurrentDeparture = null;
                }
            }
            else
            {
                if (countPeapleString == null)
                {
                    _ = DisplayAlert("Внимание", "Чтобы начать поиск заполните поле \"Количество человек\"", "OK");
                }
                else
                {
                    _ = DisplayAlert("Ошибка", "Введите корректное значение в поле \"Максимальная стоимость\"", "OK");
                }
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
