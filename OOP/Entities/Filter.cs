namespace OOP.Entities
{
    public class Filter
    {
        static public List<Tour> GetToursByHotel(List<Tour> tours, Hotel hotel)
        {
            return new(tours.Where(t => t.Hotel == hotel));
        }
        static public List<Hotel> GetHotelsByTours(List<Tour> tours)
        {
            return new(tours.Select(t => t.Hotel).Distinct());
        }
    }
}
