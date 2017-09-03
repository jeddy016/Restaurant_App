using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class OrderHistoryViewModel
    {
        public List<Order> Orders { get; set; }
    }
}