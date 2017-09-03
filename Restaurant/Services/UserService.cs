using System;
using System.Collections.Generic;
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
                return _context.Users.SingleOrDefault(u => u.Id == Id);
            }
        }
    }
}