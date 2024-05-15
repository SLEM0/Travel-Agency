using SQLite;

namespace OOP.Entities
{
    [Table("Review")]
    public class Review : BaseEntity
    {
        public int HotelId { get; set; }
        public int ClientId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        [Ignore]
        public List<Reply> Reply { get; set; }
        private readonly IDbService _dbService;
        [Ignore]
        public Client Client { get; set; }
        public Review() : this(new SQLiteService(), new(), "", 0, new())
        {
            // Этот конструктор без параметров не делает ничего, но он требуется для работы с SQLite
        }
        public Review(IDbService dbService, Client client, string text, int rating, int hotelId)
        {
            _dbService = dbService;
            Text = text;
            Rating = rating;
            Reply = [];
            Client = client;
            ClientId = client.ID;
            HotelId = hotelId;
        }
        public void AddReplyToReview(User user, string text)
        {
            Reply reply = new(text, false, ID, user.FullName);
            Reply.Add(reply);
            _dbService.AddEntity(reply);
        }
    }
}