using SQLite;

namespace OOP.Entities
{
    [Table("Client")]
    public class Client : User
    {
        public Client() : this(new SQLiteService(), "", "", "", "")
        {
            // Этот конструктор без параметров не делает ничего, но он требуется для работы с SQLite
        }
        public Client(IDbService dbService, string password, string firstName, string lastName, string login)
        {
            _dbService = dbService;
            Bookings = [];
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            FullName = firstName + " " + lastName;
            _dbService.CreateTable<Booking>();
        }
        private readonly IDbService _dbService;
        //List<Review> Reviews { get; } = [];
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Ignore]
        public List<Booking> Bookings { get; set; }
        //int? Phone { get; }
        //string? Passport { get; }
        public void AddBooking(Tour tour, int countPeaple)
        {
            Booking newBooking = new(this, tour, countPeaple);
            tour.AvailablePlaces -= countPeaple;
            Bookings.Add(newBooking);
            _dbService.AddEntity(newBooking);
            _dbService.UpdateEntity(tour);
        }

        public void RemoveBooking(Booking booking)
        {
            _dbService.DeleteEntity(booking);
            booking.Tour.AvailablePlaces += booking.CountPeaple;
            _dbService.UpdateEntity(booking.Tour);
            Bookings.Remove(booking);
        }

        public override bool UpdateInfo(string password, string firstName, string lastName)
        {
            if (password == Password)
            {
                FirstName = firstName;
                LastName = lastName;
                _dbService.UpdateEntity(this);
                return true;
            }
            return false;
        }
        public bool UpdatePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == Password)
            {
                Password = newPassword;
                _dbService.UpdateEntity(this);
                return true;
            }
            return false;
        }
    }
}