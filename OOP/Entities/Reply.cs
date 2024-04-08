namespace OOP.Entities
{
    public class Reply(string text, bool isAdmin)
    {
        public string Text { get; } = text;
        public DateTime Date { get; } = DateTime.Now;
        bool IsAdmin { get; } = isAdmin;
    }
}