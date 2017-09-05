using System.ComponentModel.DataAnnotations;

namespace Restaurant.Interfaces
{
    public interface IMenuItem
    {
         int Id { get; set; }
         string Name { get; set; }
         decimal Price { get; set; }

         [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Quantity must be a number")]
         int Quantity { get; set; }

         bool OnMenu { get; set; }
    }
}
