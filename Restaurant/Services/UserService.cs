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

        public static void Save(User user)
        {
            using (var _context = new AppDbContext())
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public static string GenerateServerNumber()
        {
            using (var _context = new AppDbContext())
            {
                var newestServer = _context.Users.OrderByDescending(u=>u.ServerNumber).First();
                var newestServerNumber = int.Parse(newestServer.ServerNumber);

                if (newestServerNumber < 9999)
                {
                    return int.Parse(newestServer.ServerNumber) + 1 + "";
                }

                return "1000";
            }
        }
    }
}