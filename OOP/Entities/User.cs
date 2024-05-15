using SQLite;

namespace OOP.Entities
{
    public class User(string login, string password) : BaseEntity
    {
        public User() : this("", "") { }
        public string Login { get; set; } = login;
        public string Password { get; set; } = password;
        [Ignore]
        public string FullName { get; set; }
        public virtual bool UpdateInfo(string oldPassword, string newLogin, string newPassword)
        {
            if (oldPassword == Password)
            {
                Login = newLogin;
                Password = newPassword;
                return true;
            }
            return false;
        }
        public virtual List<Review> GetReviews(List<Review> reviews)
        {
            return reviews.Where(review => review.ClientId == ID).ToList();
        }
    }
}
