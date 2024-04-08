namespace OOP.Entities
{
    public class Agency
    {
        static Hotel myHotel1 = new(
            new List<Room>([new("STANDART ROOM", 3), new("DELUXE ROOM", 3)]),
            "Египет", "Хургада", 3, "Elysees Hotel", "xz",
            new List<string>(["AI", "BB", "HB"]));
        static Hotel myHotel2 = new(
            new List<Room>([new("Room without Air Conditions", 3), new Room("Room with Air Conditions", 3)]),
            "Турция", "Alanya", 3, "Kleopatra Aytur Apart Hotel", "xz-xz-xz",
            new List<string>(["BB", "RO"]));
        static Hotel myHotel3 = new(
            new List<Room>([new("STANDART ROOM", 2), new("APART ROOM", 4)]),
            "Египет", "Шарм-эль-шейх", 4, "Naama Blue", "xz-xz",
            new List<string>(["AI", "HB"]));
        static Hotel myHotel4 = new(
            new List<Room>([new("villa", 4), new("super", 3)]),
            "Турция", "Alanya", 4, "Smile Hotel", "xz-xz-xz-xz",
            new List<string>(["BB"]));
        static Hotel myHotel5 = new(
            new List<Room>([new("STANDART ROOM", 2), new("DELUXE ROOM", 3), new("SINGLE ROOM", 1)]),
            "Индонезия", "Kuta", 5, "Bakung Beach Resort", "xz-xz-xz-xz-xz",
            new List<string>(["AI", "BB", "HB"]));
        static Tour myTour1 = new(myHotel1, 40, new(2024, 4, 8), new(2024, 4, 15), "Minsk", "AI", myHotel1.Rooms[0]);
        static Tour myTour2 = new(myHotel1, 50, new(2024, 4, 8), new(2024, 4, 10), "Polotsk", "BB", myHotel1.Rooms[0]);
        static Tour myTour3 = new(myHotel1, 60, new(2024, 4, 8), new(2024, 4, 18), "Minsk", "AI", myHotel1.Rooms[1]);
        static Tour myTour4 = new(myHotel2, 55, new(2024, 4, 8), new(2024, 4, 19), "Minsk", "RO", myHotel2.Rooms[0]);
        static Tour myTour5 = new(myHotel2, 50, new(2024, 4, 8), new(2024, 4, 14), "Minsk", "RO", myHotel2.Rooms[1]);
        public List<Tour> Tours { get; } = [myTour1, myTour2, myTour3, myTour4, myTour5];
        public List<Hotel> Hotels { get; } = [myHotel1, myHotel2, myHotel3, myHotel4, myHotel5];
        public List<Review> Reviews { get; }
        public Agency()
        {
            Reviews = Tours.SelectMany(tour => tour.Reviews).ToList();
        }
        public void AddTour(Hotel hotel, int places, DateTime beginDate, DateTime endDate, string departure, string eat, Room room)
        {
            Tour newTour = new(hotel, places, beginDate, endDate, departure, eat, room);
            Tours.Add(newTour);
        }

        public void AddHotel(List<Room> rooms, string country, string curort, int category, string name, string description, List<string> eat)
        {
            Hotel newHotel = new(rooms, country, curort, category, name, description, eat);
            Hotels.Add(newHotel);
        }
        public void AddHotel(Hotel hotel)
        {
            Hotels.Add(hotel);
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
            int maxDay)
        {
            List<Tour> foundTours = Tours.Where(tour =>
                countries.Contains(tour.Hotel.Country) &&
                curorts.Contains(tour.Hotel.Curort) &&
                tour.Hotel.Category >= minCategory &&
                departure.Contains(tour.Departure) &&
                eat.Contains(tour.Eat) &&
                tour.AvailablePlaces >= countPeople &&
                tour.BeginDate >= minDate && tour.BeginDate <= maxDate &&
                (tour.EndDate - tour.BeginDate).Days >= minDay && (tour.EndDate - tour.BeginDate).Days <= maxDay
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
        public List<Review> GetAllReviews()
        {
            return Tours.SelectMany(tour => tour.Reviews).ToList();
        }
        public List<Review> GetClientReviews(Client? client)
        {
            return Tours.SelectMany(tour => tour.Reviews).Where(review => review.Client == client).ToList();
        }
        public void RemoveTour(Tour tour)
        {
            Tours.Remove(tour);
        }
        public void RemoveHotel(Hotel hotel)
        {
            List<Tour> toursCopy = new(Tours);
            foreach (var tour in toursCopy)
            {
                if (tour.Hotel == hotel)
                    Tours.Remove(tour);
            }
            Hotels.Remove(hotel);
        }
    }
}