using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Interfaces
{
    public interface IMenuItem
    {
         int Id { get; set; }
         string Name { get; set; }
         decimal Price { get; set; }
         bool onMenu { get; set; }
         [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Quantity must be a number")]
         int Quantity { get; set; }
    }
}
