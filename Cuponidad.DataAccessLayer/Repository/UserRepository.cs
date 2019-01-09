using Cuponidad.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuponidad.DataAccessLayer.Repository
{
    public class UserRepository
    {
        static CuponContext context = new CuponContext();
        public static User Insert(User user)
        {
            if (context.Users.Any(o => o.Email == user.Email)) throw new Exception("Email is already exists");
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
        public static User VerifyLogin(string Email, string Password)
        {
            User user;
            user = context.Users.Where(s => s.Email == Email && s.Password == Password).FirstOrDefault<User>();
            return user;
        }
        public static User VerifyEmail(string Email)
        {
            User user;
            user = context.Users.Where(s => s.Email == Email).FirstOrDefault<User>();
            return user;
        }
        public static void UpdateTotalAmount(int UserID, decimal totalAmount)
        {
            User user = new User();
            user = context.Users
                        .Where(a => a.UserID == UserID)
                        .FirstOrDefault();
            user.TotalAmount = totalAmount;
            context.SaveChanges();
        }
        public static decimal ReadTotalAmount(int UserID)
        {
            User user = new User();
            user = context.Users
                        .Where(a => a.UserID == UserID)
                        .FirstOrDefault();
            return user.TotalAmount;
        }

    }
}
