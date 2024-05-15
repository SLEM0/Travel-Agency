using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Entities
{
    public class Admin : User
    {
        public Admin()
        {
            Login = "admin";
            Password = "12345678";
            FullName = "Администратор";
        }
        public override List<Review> GetReviews(List<Review> reviews)
        {
            return reviews;
        }
    }
}
