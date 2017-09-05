using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class UserService
    {
        public static User ValidateLogin(User login)
        {
            using (var Db = new AppDbContext())
            {
                return Db.Users.SingleOrDefault(s => s.ServerNumber == login.ServerNumber && s.Password == login.Password);
            }
        }

        public static User GetUserById(string userId)
        {
            var id = int.Parse(userId);

            using (AppDbContext Db = new AppDbContext())
            {
                return Db.Users.Single(u => u.Id == id);
            }
        }

        public static User GetUserById(int userId)
        {
            using (AppDbContext Db = new AppDbContext())
            {
                return Db.Users.Single(u => u.Id == userId);
            }
        }

        public static List<User> getUsers()
        {
            using (var Db = new AppDbContext())
            {
                return Db.Users.ToList();
            }
        }

        public static void Delete(User user)
        {
            using (var Db = new AppDbContext())
            {
                Db.Entry(user).State = EntityState.Deleted;
                Db.SaveChanges();
            }
        }

        public static void Save(User user)
        {
            using (var Db = new AppDbContext())
            {
                if (user.Id == 0)
                {
                    Db.Users.Add(user);
                }
                else
                {
                    var userInDb = Db.Users.Find(user.Id);
                    userInDb.FirstName = user.FirstName;
                    userInDb.LastName = user.LastName;
                }

                Db.SaveChanges();
            }
        }

        public static string GenerateServerNumber()
        {
            using (var Db = new AppDbContext())
            {
                var newestServer = Db.Users.OrderByDescending(u=>u.ServerNumber).First();
                var newestServerNumber = int.Parse(newestServer.ServerNumber);

                if (newestServerNumber < 9999)
                {
                    return int.Parse(newestServer.ServerNumber) + 1 + "";
                }

                return "1000";
            }
        }

        public static void UpdatePassword(User user)
        {
            using (var Db = new AppDbContext())
            {
                var userInDb = Db.Users.Find(user.Id);

                userInDb.Password = user.Password;

                Db.SaveChanges();
            }
        }
    }
}