using SQLite;

namespace OOP.Entities
{
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int ID { get; set; }
    }
}
