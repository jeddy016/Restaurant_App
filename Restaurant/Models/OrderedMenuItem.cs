
namespace Restaurant.Models
{
    public class OrderedMenuItem
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}