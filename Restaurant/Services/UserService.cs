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
        public static User GetUserById(string userId)
        {
            var Id = int.Parse(userId);

            using (AppDbContext _context = new AppDbContext())
            {
                return _context.Users.Single(u => u.Id == Id);
            }
        }

        public static User GetUserById(int userId)
        {
            using (AppDbContext _context = new AppDbContext())
            {
                return _context.Users.Single(u => u.Id == userId);
            }
        }

        public static List<User> getUsers()
        {
            using (var _context = new AppDbContext())
            {
                return _context.Users.ToList();
            }
        }

        public static void DeleteUser(User user)
        {
            using (var _context = new AppDbContext())
            {
                _context.Entry(user).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }
    }
}