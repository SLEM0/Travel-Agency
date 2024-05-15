using SQLite;

namespace OOP.Entities
{
    [Table("Booking")]
    public class Booking(Client client, Tour tour, int countPeaple) : BaseEntity
    {
        public Booking() : this(new(), new(), 0)
        {
            // Этот конструктор без параметров не делает ничего, но он требуется для работы с SQLite
        }
        public int ClientId { get; set; } = client.ID;
        public int TourId { get; set; } = tour.ID;
        public string Status { get; set; } = "Не подтверждён";
        public int CountPeaple { get; set; } = countPeaple;
        [Ignore]
        public Tour Tour { get; set; } = tour;
        [Ignore]
        public Client Client { get; set; } = client;
        public void ChangeStatus()
        {
            if (Status == "Не подтверждён")
                Status = "Подтверждён";
            else
                Status = "Не подтверждён";
        }
    }
}