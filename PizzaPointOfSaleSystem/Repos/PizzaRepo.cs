using PizzaPointOfSaleSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPointOfSaleSystem.Repos
{
    public class PizzaRepo
    {
        public List<Pizza> GetAll()
        {
            List<Pizza> list = new List<Pizza>();
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rgarn\\source\\repos\\CIS-1280-Spring-2023\\PizzaPointOfSaleSystem\\PizzaPointOfSaleSystem\\Data\\PizzaPointOfSaleDB.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM Pizza;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pizza pizza = new Pizza();
                        pizza.Id = reader.GetInt32(0);
                        pizza.TypeOfCrust = reader.GetString(1);
                        pizza.Size = reader.GetString(2);
                        list.Add(pizza);
                    }
                }
                reader.Close();
            }
            return list;
        }
    }
}
