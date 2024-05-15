using OOP.Entities;

namespace OOP
{
    public interface IDbService
    {
        void CreateTable<T>();
        void AddEntity<T>(T entity);
        void DeleteEntity<T>(T entity);
        void UpdateEntity<T>(T entity);
        IEnumerable<T> GetAllEntities<T>() where T : class, new();
        //IEnumerable<Room> GetIdEntities(int id);
    }
}
