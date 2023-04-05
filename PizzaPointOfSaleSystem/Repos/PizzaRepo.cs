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
        const string CONNECTIONSTRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rgarn\\source\\repos\\CIS-1280-Spring-2023\\PizzaPointOfSaleSystem\\PizzaPointOfSaleSystem\\Data\\PizzaPointOfSaleDB.mdf;Integrated Security=True";

        public List<Pizza> GetAll()
        {
            List<Pizza> list = new List<Pizza>();
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
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

                        //Get toppings and add them to pizza
                        SqlCommand toppinigsCmd = new SqlCommand("SELECT ToppingId As Id, Name FROM PizzaToppingCrossref LEFT JOIN Topping ON PizzaToppingCrossref.ToppingId = Topping.Id WHERE PizzaId = @Id");
                        toppinigsCmd.Parameters.AddWithValue("Id", pizza.Id);
                        pizza.Toppings = new List<Topping>();
                        SqlDataReader toppingsReader = toppinigsCmd.ExecuteReader();
                        if (toppingsReader.HasRows)
                        {
                            while (toppingsReader.Read())
                            {
                                Topping topping = new Topping();
                                topping.Id = toppingsReader.GetInt32(0);
                                topping.Name = toppingsReader.GetString(1);
                                pizza.Toppings.Add(topping);
                            }                            
                        }
                        list.Add(pizza);
                    }
                }
                reader.Close();
            }
            return list;
        }
    }
}
