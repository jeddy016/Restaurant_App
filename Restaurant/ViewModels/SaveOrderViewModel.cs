using System.Collections.Generic;

namespace Restaurant.Models
{
    public class SaveOrderViewModel
    {
        public int Id { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}