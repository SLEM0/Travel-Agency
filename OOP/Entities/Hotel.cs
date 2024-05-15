using SQLite;

namespace OOP.Entities
{
    [Table("Hotel")]
    public class Hotel : BaseEntity
    {
        public Hotel() : this(new SQLiteService(), [], "", "", 0, "", "")
        {
            // Этот конструктор без параметров не делает ничего, но он требуется для работы с SQLite
        }
        public Hotel(IDbService dbService,
            List<Room> rooms,
            string country,
            string curort,
            int category,
            string name,
            string description)
        {
            Country = country;
            Curort = curort;
            Category = category;
            Name = name;
            Description = description;
            Rooms = rooms;
            _dbService = dbService;
            //LoadData();
        }
        private readonly IDbService _dbService;
        public string Country { get; set; }
        public string Curort { get; set; } 
        public int Category { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        [Ignore]
        public List<Room> Rooms { get; set; }
        public void UpdateInfo(string country, string curort, int category, string name, string description)
        {
            Country = country;
            Curort = curort;
            Category = category;
            Name = name;
            Description = description;
            _dbService.UpdateEntity(this);
        }
        public void AddRoom(string name, int countPeaple)
        {
            Room newRoom = new(_dbService, name, countPeaple, ID);
            if (ID != 0)
                _dbService.AddEntity(newRoom);
            Rooms.Add(newRoom);
        }
        public void RemoveRoom(Room room)
        {
            _dbService.DeleteEntity(room);
            Rooms.Remove(room);
            //Rooms.RemoveAll(room => room.Name == null);
            //_dbService.UpdateEntity(this);
        }
        //private void LoadData()
        //{
        //    List<Room> Rooms1 = ((List<Room>)_dbService.GetAllEntities<Room>());
        //    Rooms = Rooms1.Where(r => r.HotelId == ID).ToList();
        //}
    }
}