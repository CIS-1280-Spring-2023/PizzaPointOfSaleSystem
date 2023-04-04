using System.Collections.Generic;

namespace PizzaPointOfSaleSystem.Models
{
    public class Pizza
    {
        public int Id { get; set; } 
        public string TypeOfCrust { get; set; }
        public string Size { get; set; }
        public List<Topping> Toppings { get; set; }
    }
}
