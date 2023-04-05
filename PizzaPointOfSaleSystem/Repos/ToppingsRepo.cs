using PizzaPointOfSaleSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPointOfSaleSystem.Repos
{
    public class ToppingsRepo
    {
        const string CONNECTIONSTRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rgarn\\source\\repos\\CIS-1280-Spring-2023\\PizzaPointOfSaleSystem\\PizzaPointOfSaleSystem\\Data\\PizzaPointOfSaleDB.mdf;Integrated Security=True";

        public List<Topping> GetAll()
        {
            List<Topping> toppings = new List<Topping>();
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM Topping;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Topping topping = new Topping();
                        topping.Id = reader.GetInt32(0);
                        topping.Name = reader.GetString(1);
                        toppings.Add(topping);
                    }
                }
                reader.Close();
            }
            return toppings;
        }
    }
}
