using System.Collections.Generic;
using System.Linq;

namespace PizzaPointOfSaleSystem.Models
{
    public class Pizza
    {
        public int Id { get; set; } 
        public string TypeOfCrust { get; set; }
        public string Size { get; set; }
        public List<Topping> Toppings { get; set; }

        public override string ToString()
        {
            string text = $"{Size} {TypeOfCrust} with ";
            foreach (var topping in Toppings)
            {
                text += topping.ToString() +", " ;
            }
            text = text.Substring(0,text.Length-2) + '.';
            return text;
        }
    }
}
