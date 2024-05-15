using SQLite;

namespace OOP.Entities
{
    [Table("Tour")]
    public class Tour : BaseEntity
    {
        public Tour() : this(new SQLiteService(), new(), 0, new(), new(), "", "", new(), 0)
        {
            // Этот конструктор без параметров не делает ничего, но он требуется для работы с SQLite
        }
        public Tour(
        IDbService dbService,
        Hotel hotel,
        int places,
        DateTime beginDate,
        DateTime endDate,
        string departure,
        string eat,
        Room room,
        double price)
        {
            _dbService = dbService;
            Hotel = hotel;
            AvailablePlaces = places;
            BeginDate = beginDate;
            EndDate = endDate;
            Departure = departure;
            Eat = eat;
            Room = room;
            Price = price;
            HotelId = hotel.ID;
            RoomId = room.ID;
        }
        private readonly IDbService _dbService;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Departure { get; set; }
        public int HotelId {  get; set; }
        public int AvailablePlaces { get; set; }
        public string Eat { get; set; }
        public int RoomId { get; set; }
        public double Price { get; set; }
        [Ignore]
        public Hotel Hotel { get; set; }
        [Ignore]
        public Room Room { get; set; }
        public void UpdateInfo(int places, DateTime beginDate, DateTime endDate, string departure, string eat, double price, Room room)
        {
            AvailablePlaces = places;
            BeginDate = beginDate;
            EndDate = endDate;
            Departure = departure;
            Eat = eat;
            Price = price;
            Room = room;
            _dbService.UpdateEntity(this);
        }
    }
}