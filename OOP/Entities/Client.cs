namespace OOP.Entities
{
    public class Client(string password, string firstName, string lastName, string email)
    {
        public List<Booking> Bookings { get; } = [];
        List<Review> Reviews { get; } = [];
        public string Password { get; private set; } = password;
        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;
        public string Email { get; } = email;
        int? Phone { get; }
        string? Passport { get; }
        public void AddBooking(Tour tour, int countPeaple)
        {
            Booking newBooking = new(this, tour);
            tour.AvailablePlaces -= countPeaple;
            Bookings.Add(newBooking);
        }

        public void RemoveBooking(Booking booking)
        {
            Bookings.Remove(booking);
        }

        public bool UpdateInfo(string password, string firstName, string lastName)
        {
            if (password == Password)
            {
                FirstName = firstName;
                LastName = lastName;
                return true;
            }
            return false;
        }
        public bool UpdatePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == Password)
            {
                Password = newPassword;
                return true;
            }
            return false;
        }
    }
}