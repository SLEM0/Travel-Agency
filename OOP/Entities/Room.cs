using SQLite;

namespace OOP.Entities
{
    [Table("Room")]
    public class Room(IDbService dbService, string name, int countPeaple, int HotelId) : BaseEntity
    {
        public Room() : this(new SQLiteService(), "", 0, 0)
        {
            // Этот конструктор без параметров не делает ничего, но он требуется для работы с SQLite
        }
        public string? Name { get; set; } = name;
        public int CountPeaple { get; set; } = countPeaple;
        public int HotelId { get; set; } = HotelId;
        private readonly IDbService _dbService = dbService;
        //public int HotelId { get; set; } = hotelId;
        //bool IsAvailable {  get; } = true;
        //public void PrepareToRemove()
        //{
        //    Name = null;
        //}
        public void UpdateInfo(string name, int countPeaple)
        {
            Name = name;
            CountPeaple = countPeaple;
            _dbService.UpdateEntity(this);
        }
    }
}