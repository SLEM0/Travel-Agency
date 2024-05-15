namespace OOP.Entities
{
    public class AgencyEntry
    {
        private readonly Admin _admin;
        private readonly IDbService _dbService;
        public delegate void LoginEventHandler();
        public event LoginEventHandler? LoginEvent;
        public event LoginEventHandler? ClientLoginEvent;
        public event LoginEventHandler? InvalidEvent;
        public List<Client> Clients { get; private set; } = [];
        public List<Review> Reviews { get; private set; } = [];
        private readonly Agency _agency;
        public User? CurrentUser { get; private set; }
        public AgencyEntry(IDbService dbService, Agency agency, Admin admin)
        {
            _agency = agency;
            _dbService = dbService;
            _admin = admin;
            _dbService.CreateTable<Client>();
            _dbService.CreateTable<Review>();
            _dbService.CreateTable<Reply>();
            LoadData();
        }

        public void Register(string password, string firstName, string lastName, string email)
        {
            Client? client = Clients.Find(c => c.Login == email);
            if (client != null)
            {
                Console.WriteLine("There is already a user with this login");
            }
            else
            {
                Client newClient = new(_dbService, password, firstName, lastName, email);
                Clients.Add(newClient);
                _dbService.AddEntity(newClient);
            }
        }
        public void Logout()
        {
            CurrentUser = null;
        }

        public bool Login(string login, string password)
        {
            if (login == _admin.Login && password == _admin.Password)
            {
                CurrentUser = new Admin();
                LoginEvent?.Invoke();
                return true;
            }
            else
            {
                Client? client = Clients.Find(c => c.Login == login && c.Password == password);
                if (client != null)
                {
                    CurrentUser = client;
                    ClientLoginEvent?.Invoke();
                    return true;
                }
                else
                {
                    InvalidEvent?.Invoke();
                }
            }
            return false;
        }

        //public void ChangeCredentials(string login, string password)
        //{
        //    AdminLogin = login;
        //    AdminPassword = password;
        //}
        private void LoadData()
        {
            Clients = (List<Client>)_dbService.GetAllEntities<Client>();
            foreach (var client in Clients)
            {
                client.Bookings = ((List<Booking>)_dbService.GetAllEntities<Booking>()).Where(b => b.ClientId == client.ID).ToList();
                client.FullName = client.FirstName + " " + client.LastName;
                foreach (var booking in client.Bookings)
                {
                    booking.Tour = _agency.Tours.FirstOrDefault(t => t.ID == booking.TourId);
                    booking.Client = client;
                }
            }
            Reviews = (List<Review>)_dbService.GetAllEntities<Review>();
            foreach (var review in Reviews)
            {
                review.Client = Clients.FirstOrDefault(c => c.ID == review.ClientId);
                review.Reply = ((List<Reply>)_dbService.GetAllEntities<Reply>()).Where(r => r.ReviewId == review.ID).ToList();
                
            }
        }
        public List<Review> GetUserReviews()
        {
            return CurrentUser.GetReviews(Reviews);
        }
        public List<Review> GetHotelReviews(int hotelId)
        {
            return Reviews.Where(review => review.HotelId ==  hotelId).ToList();
        }
        public void AddReview(Client client, int hotelId, string text, int rating)
        {
            Review newReview = new(_dbService, client, text, rating, hotelId);
            _dbService.AddEntity(newReview);
            Reviews.Add(newReview);
        }
        public List<Booking> AllBooking()
        {
            if (Clients.Count == 0)
                return [];
            else
                return Clients.SelectMany(client => client.Bookings).ToList();
        }
    }
}