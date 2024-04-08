namespace OOP.Entities
{
    public class Hotel(List<Room> rooms, string country, string curort, int category, string name, string description, List<string> eat)
    {
        public List<Room> Rooms { get; } = rooms;
        public string Country { get; private set; } = country;
        public string Curort { get; private set; } = curort;
        public int Category { get; private set; } = category;
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;
        public List<string> Eat { get; private set; } = eat;
        public void UpdateInfo(string country, string curort, int category, string name, string description, List<string> eat)
        {
            Country = country;
            Curort = curort;
            Category = category;
            Name = name;
            Description = description;
            Eat = eat;
        }
        public void AddRoom(string name, int countPeaple)
        {
            Rooms.Add(new(name, countPeaple));
        }
        public void RemoveRooms()
        {
            Rooms.RemoveAll(room => room.Name == null);
        }
    }
}