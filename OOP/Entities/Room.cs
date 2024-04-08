namespace OOP.Entities
{
    public class Room(string name, int countPeaple)
    {
        public string? Name { get; private set; } = name;
        public int CountPeaple { get; private set; } = countPeaple;
        bool IsAvailable {  get; } = true;
        public void PrepareToRemove()
        {
            Name = null;
        }
        public void UpdateInfo(string name, int countPeaple)
        {
            Name = name;
            CountPeaple = countPeaple;
        }
    }
}