namespace OOP.Entities
{
    public class Tour(Hotel hotel, int places, DateTime beginDate, DateTime endDate, string departure, string eat, Room room)
    {
        public DateTime BeginDate { get; private set; } = beginDate;
        public DateTime EndDate { get; private set; } = endDate;
        public string Departure { get; private set; } = departure;
        public List<Review> Reviews { get; } = [];
        public Hotel Hotel { get; set; } = hotel;
        public int AvailablePlaces { get; set; } = places;
        public string Eat { get; private set; } = eat;
        public Room Room { get; set; } = room;
        public void AddReview(Client client, string text, int rating)
        {
            Review newReview = new(client, text, rating, this);
            Reviews.Add(newReview);
        }
        public void UpdateInfo(int places, DateTime beginDate, DateTime endDate, string departure, string eat)
        {
            AvailablePlaces = places;
            BeginDate = beginDate;
            EndDate = endDate;
            Departure = departure;
            Eat = eat;
        }
    }
}