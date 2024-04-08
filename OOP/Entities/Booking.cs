namespace OOP.Entities
{
    public class Booking(Client client, Tour tour)
    {
        Client Client { get; } = client;
        public Tour Tour { get; } = tour;
        public bool Status { get; private set; } = false;
        public double TotalPrice()
        {
            double totalPrice = 52;
            return totalPrice;
        }
        public void Pay()
        {
            Status = true;
        }

    }
}