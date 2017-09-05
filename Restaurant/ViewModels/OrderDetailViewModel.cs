using System.Collections.Generic;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class OrderDetailViewModel
    {
        public Order Order { get; set; }
        public List<MenuItem> OrderedItems { get; set; }
    }
}