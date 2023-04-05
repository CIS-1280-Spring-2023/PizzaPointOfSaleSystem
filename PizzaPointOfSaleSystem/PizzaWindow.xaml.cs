using PizzaPointOfSaleSystem.Models;
using PizzaPointOfSaleSystem.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PizzaPointOfSaleSystem
{
    /// <summary>
    /// Interaction logic for PizzaWindow.xaml
    /// </summary>
    public partial class PizzaWindow : Window
    {
        ToppingsRepo toppingsRepo = new ToppingsRepo();
        List<Topping> toppings = new List<Topping>();

        public PizzaWindow()
        {
            InitializeComponent();

            cmbCrust.Items.Clear();
            cmbCrust.Items.Add("Hand tossed");
            cmbCrust.Items.Add("Thin");
            cmbCrust.Items.Add("Deep Dish");

            cmbSize.Items.Clear();
            cmbSize.Items.Add("Large");
            cmbSize.Items.Add("Medium");
            cmbSize.Items.Add("Small");



            toppings = toppingsRepo.GetAll();

            int yPos = 140;
            foreach(var topping in toppings)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Tag = topping;
                checkBox.Content = topping.Name;
                checkBox.HorizontalAlignment = HorizontalAlignment.Left;
                checkBox.Margin = new Thickness(100, yPos, 0, 0);
                checkBox.VerticalAlignment = VerticalAlignment.Top;
                grid.Children.Add(checkBox);
                yPos += 20;
            }
        }
    }
}
