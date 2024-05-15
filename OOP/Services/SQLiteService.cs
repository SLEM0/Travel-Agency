using SQLite;
using OOP.Entities;

namespace OOP
{
    public class SQLiteService : IDbService
    {
        private readonly SQLiteConnection? _database;

        public SQLiteService()
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dataBasePath = Path.Combine(folderPath, "new.db");
           // dataBasePath = "C:\\OOP.db";
            _database = new SQLiteConnection(dataBasePath);
        }

        public void AddEntity<T>(T entity)
        {
            _database.Insert(entity);
        }
        public void DeleteEntity<T>(T entity)
        {
            _database.Delete(entity);
        }
        public void UpdateEntity<T>(T entity)
        {
            _database.Update(entity);
        }

        public IEnumerable<T> GetAllEntities<T>() where T : class, new()
        {
            return _database.Table<T>().ToList();
        }

        private bool TableExists(string tableName)
        {
            return _database?.GetTableInfo(tableName).Any() ?? false;
        }
        public void CreateTable<T>()
        {
            if (!TableExists(typeof(T).Name))
            {
                _database.CreateTable<T>();
            }
        }
        //public IEnumerable<Room> GetIdEntities(int id)
        //{
        //    return _database.Table<Room>().Where(r => r.HotelId == id).ToArray();
        //}
    }
}