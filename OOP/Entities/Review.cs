namespace OOP.Entities
{
    public class Review(Client client, string text, int rating, Tour tour)
    {
        public Tour Tour { get; } = tour;
        public Client Client { get; } = client;
        public string Text { get; } = text;
        public int Rating { get; } = rating;
        public List<Reply> Reply { get; } = [];
        public DateTime Date { get; } = DateTime.Now;
        public void AddAdminReplyToReview(string text)
        {
            Reply reply = new(text, true);
            Reply.Add(reply);
        }
        public void AddReplyToReview(string text)
        {
            Reply reply = new(text, false);
            Reply.Add(reply);
        }
    }
}