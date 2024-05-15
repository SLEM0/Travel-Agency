using SQLite;

namespace OOP.Entities
{
    [Table("Reply")]
    public class Reply(string text, bool isAdmin, int reviewId, string name) : BaseEntity
    {
        public Reply() : this("", false, 0, "")
        {
            // Этот конструктор без параметров не делает ничего, но он требуется для работы с SQLite
        }
        public int ReviewId { get; set; } = reviewId;
        public string Text { get; set; } = text;
        public DateTime Date { get; set; } = DateTime.Today;
        public bool IsAdmin { get; set; } = isAdmin;
        public string Name { get; set; } = name;
    }
}