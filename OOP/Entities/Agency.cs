using System.Net;

namespace OOP.Entities
{
    public class Agency
    {
        private readonly IDbService _dbService;
        public List<Tour> Tours { get; private set; } = [];
        public List<Hotel> Hotels { get; private set; } = [];
        public Agency(IDbService dbService)
        {
            _dbService = dbService;
            _dbService.CreateTable<Room>();
            _dbService.CreateTable<Hotel>();
            _dbService.CreateTable<Tour>();
            LoadData();
        }
        public void AddTour(Hotel hotel, int places, DateTime beginDate, DateTime endDate, string departure, string eat, Room room, double price)
        {
            Tour newTour = new(_dbService, hotel, places, beginDate, endDate, departure, eat, room, price);
            Tours.Add(newTour);
            _dbService.AddEntity(newTour);
        }

        public void AddHotel(List<Room> rooms, string country, string curort, int category, string name, string description)
        {
            Hotel newHotel = new(_dbService, rooms, country, curort, category, name, description);
            Hotels.Add(newHotel);
            _dbService.AddEntity(newHotel);
            foreach (Room r in newHotel.Rooms)
            {
                r.HotelId = newHotel.ID;
                _dbService.AddEntity(r);
            }
        }
        public void AddHotel(Hotel hotel)
        {
            Hotels.Add(hotel);
            _dbService.AddEntity(hotel);
            foreach (Room r in hotel.Rooms)
            {
                r.HotelId = hotel.ID;
                _dbService.AddEntity(r);
            }
        }
        public List<Tour> FindTour(
            int countPeople,
            List<string> departure,
            List<string> countries,
            List<string> curorts,
            int minCategory,
            List<string> eat,
            DateTime minDate,
            DateTime maxDate,
            int minDay,
            int maxDay,
            double maxPrice)
        {
            if (Tours.Count == 0)
                return [];
            List<Tour> foundTours = Tours.Where(tour =>
                countries.Contains(tour.Hotel.Country) &&
                curorts.Contains(tour.Hotel.Curort) &&
                tour.Hotel.Category >= minCategory &&
                departure.Contains(tour.Departure) &&
                eat.Contains(tour.Eat) &&
                tour.AvailablePlaces >= countPeople &&
                tour.BeginDate >= minDate && tour.BeginDate <= maxDate &&
                (tour.EndDate - tour.BeginDate).Days >= minDay && (tour.EndDate - tour.BeginDate).Days <= maxDay &&
                tour.Price <= maxPrice
            ).ToList();
            return foundTours;
        }
        public List<string> GetCountriesList()
        {
            List<string> countries = Hotels.Select(h => h.Country).Distinct().ToList();
            countries.Sort();
            return countries;
        }
        public List<string> GetCurortsList()
        {
            List<string> curorts = Hotels.Select(h => h.Curort).Distinct().ToList();
            curorts.Sort();
            return curorts;
        }
        public List<string> GetDepartureList()
        {
            List<string> departure = Tours.Select(t =>  t.Departure).Distinct().ToList();
            departure.Sort();
            return departure;
        }
        public void RemoveTour(Tour tour)
        {
            Tours.Remove(tour);
            _dbService.DeleteEntity(tour);
        }
        public void RemoveHotel(Hotel hotel)
        {
            List<Tour> toursCopy = new(Tours);
            foreach (var tour in toursCopy)
            {
                if (tour.Hotel == hotel)
                {
                    Tours.Remove(tour);
                    _dbService.DeleteEntity(tour);
                }
            }
            Hotels.Remove(hotel);

            _dbService.DeleteEntity(hotel);
            foreach (Room r in hotel.Rooms)
            {
                r.HotelId = hotel.ID;
                _dbService.DeleteEntity(r);
            }
        }
        public double MaxPrice()
        {
            if (Tours.Count == 0)
                return 0;
            return Tours.Max(tour => tour.Price);
        }
        private void LoadData()
        {
            Hotels = (List<Hotel>)_dbService.GetAllEntities<Hotel>();
            foreach (var hotel in Hotels)
            {
                hotel.Rooms = ((List<Room>)_dbService.GetAllEntities<Room>()).Where(r => r.HotelId == hotel.ID).ToList();
            }
            Tours = (List<Tour>)_dbService.GetAllEntities<Tour>();
            foreach (var tour in Tours)
            {
                tour.Hotel = Hotels.FirstOrDefault(h => h.ID == tour.HotelId);
                if (tour.Hotel != null)
                {
                    List<Room> Rooms = tour.Hotel.Rooms;
                    tour.Room = Rooms.FirstOrDefault(r => r.ID == tour.RoomId);
                }
            }
        }
    }
}